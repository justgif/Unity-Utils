# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.3.0] - 2024-12-01

### Added

- Generic `Singleton` class to create singleton instances of any class

## [0.2.0] - 2024-11-30

### Added

- Several extension methods for the following types:
    - Enumerable
    - Enumerator
    - Float
    - GameObject
    - Int
    - LayerMask
    - List
    - Object
    - String
    - Transform
    - Vector2
    - Vector3

### Changed

- Modified package name and root namespace from `UnityUtils` to `Utils`

## [0.1.0] - 2024-11-30

### Added

- `[MethodButton]` attribute to invoke class methods from clickable buttons in the inspector
- `[MethodHeader]` attribute to display a header above `[MethodButton]` buttons in the inspector
- `[ReadOnly]` attribute to make a field read-only in the inspector, while keeping it editable in the script
- `[Vector2Range]` attribute to convert serialized `Vector2` and `Vector2Int` fields into a min-max range slider in the inspector
