# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.3.2] - 2024-12-16

### Added

- `[RequiredField]` attribute that displays an error indicator in the inspector and scene hierarchy if the attached field is left empty
    - Currently functions for empty strings and missing Object references

## [0.3.1] - 2024-12-01

### Added

- `Singleton` persistence can now be modified during runtime

### Changed

- `Singleton` persistence now defaults to `false`
- `Singleton` now logs the name of its game object if destroying itself due to an instance already existing

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
