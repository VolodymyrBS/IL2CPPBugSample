# IL2CPPBugSample

[Unity Form Thread](https://forum.unity.com/threads/il2cpp-does-not-generate-constructor-for-generic-classes-that-have-struct-as-parameter.997274/)

## To Reproduce
- Clone project on Windows
- Have dotnet.exe available in your path
- Install Unity UWP support
- Open project in Unity
- Press "Unity Csproj / Generate DLLs"
- Click File / Build Settings
- Select Universal Windows Platform
- Chose Any Device, x64, Local Machine, Debug
- Build
- Run the generated UWP project in Debug mode
- Press the "Working" button, then a "non-working" button