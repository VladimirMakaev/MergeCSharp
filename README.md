# MergeCSharp
An MSBuild task that merges specified cs files in a project into a single cs file

It was developed as a solution to have multifile project for submitting solutions to https://www.codingame.com/

## Usage
```
dotnet publish
```


In your target csproj
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <UsingTask TaskName="MergeCSharp.Merge" AssemblyFile="{PATH_TO_FOLDER}\MergeCSharp\src\MergeCSharp\bin\Debug\netstandard2.0\publish\MergeCSharp.dll" />

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <Target Name="PostBuild" AfterTargets="PostBuildEvent">
    <Merge InputFiles="@(Compile)" OutDir="$(OutDir)"></Merge>
  </Target>
</Project>
```