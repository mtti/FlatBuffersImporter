[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-333.svg?style=flat-square&logo=unity)](https://unity.com/)

A [FlatBuffers](https://google.github.io/flatbuffers/) importer for Unity. Automatically compiles FlatBuffers schema files (with the `.fbs` extension) to C#. Includes the FlatBuffers .NET library as well as schema compiler binaries for Windows, Linux and Mac (only Mac has been tested though).

The included FlatBuffers library and schema compiler correspond to FlatBuffers release `23.3.3`. At the time of updating this library, newer versions of FlatBuffers didn't work because of [flatbuffers#7899](https://github.com/google/flatbuffers/issues/7899).

Based on [iBicha/FlatBuffersImporter](https://github.com/iBicha/FlatBuffersImporter).

## Usage

After installing this package, simply create an `.fbs` file somewhere under your `Assets` directory and it will be automatically compiled into C# with the same name as the schema file, ie. `Assets/schema.fbs` will generate a `Assets/schema.cs` file. Note that the generated file is not removed automatically if you delete the schema file, and needs to be cleaned up manually.

Note that the `.cs` file will only be generated if the schema compiler outputs anything. If the schema file is empty, for example, no C# file will be generated.

Be sure to add the `FlatBuffers` assembly definition as a dependency to the assembly that the C# code was generated to.

On Mac, the `flatc-mac` binary will initially fail to run and you'll need to manually allow it in security settings because the binary is not signed.

## Installation

This library is implemented as a Unity package, but is currently unavailable from a registry and should be installed as a Git dependency.

### As a Git dependency

Add to `manifest.json`, under `dependencies`:

```
"com.mattihiltunen.fbs": "https://github.com/mtti/FlatBuffersImporter.git",
```

### As an embedded Git submodule

```
git submodule add git@github.com:mtti/FlatBuffersImporter.git Packages/com.mattihiltunen.fbs
```

You can also add the `manifest.json` entry as above to document the dependency to this library.

## License

* Copyright &copy;2021 Matti Hiltunen. Licensed under the Apache License, version 2 (see LICENSE for details).
* [iBicha/FlatBuffersImporter](https://github.com/iBicha/FlatBuffersImporter) Copyright &copy;2018 Brahim Hadriche. Licensed under the MIT License.
* FlatBuffers Copyright 2014 Google Inc. All rights reserved. Licensed under the Apache License, version 2.
