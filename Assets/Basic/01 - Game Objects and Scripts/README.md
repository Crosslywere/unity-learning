# Game Objects and Scripts

The goal of this is to learn about game objects heirarchies

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
