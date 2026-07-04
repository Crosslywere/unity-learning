# Game Objects and Scripts

[The source article](https://catlikecoding.com/unity/tutorials/basics/game-objects-and-scripts/)

The goal of this is to learn about
1. Building a clock with simple objects
2. Writing a C# script
3. Rotating the clock's arms to show the time
4. Animating the arms

## Packages

- Features
  - Engineering

- Unity Packages
  - Code Coverage
  - Custom NUnit
  - Editor Coroutines
  - JetBrains Rider Editor
  - Profile Analyzer
  - Settings Manager
  - Sysroot Base
  - Sysroot Linux x64
  - Test Framework
  - Visual Studio Code Editor
  - Visual Studio Editor

## Setting up the Color Space

Configured in `Edit > Project Settings > Player > Other Settings`. Under **Rendering** set `Color Space` to `Linear`

## Building a Simple Clock

The clock is a real time clock that uses the `System.DateTime` to manipulate the second minute and hour hands of the clock.

### Notes

- Ensure Handle position is in `Pivot` mode and not `Center` mode. This ensures correct rotation about the pivot point.
- `Transform.localRotation` is a `Quaternion` but rotation can also be manipulated by `Transform.localEulerAngles` as a `Vector3`.
