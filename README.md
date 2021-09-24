[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-333.svg?style=flat-square&logo=unity)](https://unity.com/)

A [FlatBuffers](https://google.github.io/flatbuffers/) importer for Unity. Automatically compiles FlatBuffers schema files (with the `.fbs` extension) to C#. Includes the FlatBuffers .NET library as well as schema compiler binaries for Windows, Linux and Mac (only Windows has been tested though).

Based on [iBicha/FlatBuffersImporter](https://github.com/iBicha/FlatBuffersImporter).

## Usage

After installing this package, simply create an `.fbs` file somewhere under your `Assets` directory and it will be automatically compiled into C# with the same name as the schema file, ie. `Assets/schema.fbs` will generate a `Assets/schema.cs` file. Not that the generated file is not removed automatically if you delete the schema file, and needs to be cleaned up manually.

Be sure to add the `FlatBuffers` assembly definition as a dependency to the assembly that the C# code was generated to.

## Installation

This library is implemented as a Unity package, but is currently unvailable from a registry and should be installed as a Git dependency.

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
