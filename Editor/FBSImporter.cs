using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace mtti.FlatBuffersImporter.Editor
{
    [ScriptedImporter(1, "fbs")]
    public class FBSImporter : ScriptedImporter
    {
        /// <summary>
        /// Get the path to the FlatBuffers compiler executable.
        /// </summary>
        public static string CompilerPath
        {
            get
            {
                var projectDir = Directory.GetParent(Application.dataPath);

#if UNITY_EDITOR_WIN
                var executable = "flatc.exe";
#elif UNITY_EDITOR_OSX
            var executable = "flatc-mac";
#elif UNITY_EDITOR_LINUX
            var executable = "flatc-linux";
#endif

                return $"{projectDir}/Packages/com.mattihiltunen.fbs/bin/{executable}";
            }
        }

        public override void OnImportAsset(AssetImportContext ctx)
        {
            var compilerPath = CompilerPath;
            var sourcePath = Path.GetFullPath(ctx.assetPath);
            var sourceDir = Path.GetDirectoryName(sourcePath);

            var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = CompilerPath,
                Arguments = $"--csharp --gen-onefile -o . \"{sourcePath}\"",
                UseShellExecute = false,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = sourceDir,
            };
            process.Start();
            var stderr = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                var generatedPath = ctx.assetPath.Replace(".fbs", ".cs");
                AssetDatabase.ImportAsset(
                    generatedPath,
                    ImportAssetOptions.ForceSynchronousImport
                );
            }
            else
            {
                ctx.LogImportError(stderr);
            }
        }
    }
}
