# Unity Utils

A collection of several utility functions and useful features.

## Table of Contents

> 1. [Installation](#1-installation)
> 2. [Features](#2-features)<br>
> 2.1 [Design Patterns](#21-design-patterns)<br>
> 2.2 [Editor Attributes](#22-editor-attributes)<br>
> 2.3 [Type Extensions](#23-type-extensions)<br>

## 1. Installation

### Dependencies

- [Unity](https://unity.com/releases/editor/archive) 6+

### Install Package via Git URL

- Open Unity's Package Manager by navigating to `Window > Package Manager`
- Add a new package and select *Install package from git URL...*
- Paste `https://github.com/justgif/Unity-Utils.git` into the URL and click *Install*
- To target a previous release, append `#*.*.*` with a specific version number to the end of the URL. For example, `https://github.com/justgif/Unity-Utils.git#0.1.0`.

[Back to Top](#table-of-contents)

## 2. Features

### 2.1 Design Patterns

#### Singleton

- Generic `Singleton<T>` that can derive from any `MonoBehaviour` class.
- Includes lazy initialization, if a singleton of type `T` does not exist when called, a new game object with component `T` will be created with default values.
- Alternatively, the `TryGetInstance()` method will **only** get the instance if it already exists, and will not create a new instance.
- If a duplicate instance is detected upon initialization, the newer instance will automatically destroy itself, ensuring only the oldest instance exists.
- Includes an optional setting to allow the singleton to persist across multiple scenes, with persistence being modifiable during runtime.
- Custom colored <span style="color:#2ecc71">**Singleton**</span> debug prefix for easy console identification.

[Back to Top](#table-of-contents)

### 2.2 Editor Attributes

#### [MethodButton]

- Place attribute above any method in a `MonoBehaviour` derived class to draw a button in the Inspector for that class that invokes the method upon being clicked.
- By default, the button will only invoke the method while the game is running. This can be overriden by setting the `RequiresGameRunning` property to `false`.
- Optionally, the `[MethodHeader]` attribute can be added above a method that includes a `[MethodButton]` attribute to create a new group in the Inspector, similar to Unity's `[Header]` attribute for types.
- Includes a warning message in the console log with an easily identifiable <span style="color:#d4ac0d">**Method Button**</span> prefix if the user attempts to click a `[MethodButton]` that can only be invoked in play mode while outside of play mode.

Example:

```
[MethodButton]
private void Method1()
{
    // This button will only be clickable while in play mode.
}

[MethodHeader("Alternative Method Button")]

[MethodButton(RequiresGameRunning = false)]
private void Method2()
{
    // This button will be clickable at all times.
    // It is also distinctly seperated from Method1 in the Inspector due to having its own [MethodHeader] attribute.
}
```

#### [ReadOnly]

- Include attribute with any serialized or public field to have its value shown in Unity's Inspector, but prevent modification.
- Still allows the value to be modified within code, but prevents it from being modified within the Inspector.
- Note that the built-in C# `readonly` keyword completely prevents fields from appearing in Unity's Inspector.

Example:

```
[SerializeField, ReadOnly]
private string m_ReadOnlyString = "Read Only";
```

#### [RequiredField]

- Include attribute with any serialized or public field to display an error in the Inspector when the field is left blank.
- Any field with the `[RequiredField]` attribute that is left blank will be drawn with a red background.
- Any objects in the scene that have blank fields with the `[RequiredField]` attribute will also be highlighted red in the Scene Hierarchy.
- Currently, can be used to detect if a string is left empty or if an object reference is missing.

Example:

```
[SerializeField, RequiredField]
private string m_SomeString;

[SerializeField, RequiredField]
private GameObject m_SomeGameObject;
```
#### [Vector2Range]

- Attribute can be used with both `Vector2` and `Vector2Int` types to draw a double-sided min-max slider in the Inspector for the X and Y vector values.
- Attribute takes parameters for the absolute minimum and maximum slider values.
- When initializing the vector, default values can still be provided, which will be reflected in the slider.

Example:

```
[SerializeField, Vector2Range(0, 10)]
private Vector2 m_Vector2Range = new(2.5, 7.5);

[SerializeField, Vector2Range(0, 10)]
private Vector2Int m_Vector2IntRange = new(2, 8);
```

[Back to Top](#table-of-contents)

### 2.3 Type Extensions

Several extension methods are provided for various built-in C# types and common Unity types. The full collection can be found in [/Runtime/Extensions/](https://github.com/justgif/Unity-Utils/tree/main/Runtime/Extensions).

C# Types:

- `IEnumerable`
- `IEnumerator`
- `IList`
- `float`
- `int`
- `string`

Unity Types:

- `GameObject`
- `LayerMask`
- `Object`
- `Transform`
- `Vector2`
- `Vector2Int`
- `Vector3`

[Back to Top](#table-of-contents)
