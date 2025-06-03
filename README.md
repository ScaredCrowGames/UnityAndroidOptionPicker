# Android native Option Picker Dialog for Unity

A simple, lightweight native Android option picker implemented using Unity's `AndroidJavaObject` bridge. Unlike Unity UI-based pickers, this uses the native Android `AlertDialog` and `NumberPicker` to present a list of options in a clean, consistent, and mobile-native experience.

---
## Table of Contents
- [Installation](#installation)
- [Samples](#samples)
- [How to use](#how-to-use)
- [Contact us](#contact-us)

## Installation

1. Use the Package Manager:

Window > Package Manager > Install package from git URL...
```link
https://github.com/scaredcrowgames/androidoptionpicker.git?path=src
```

2. Or add this to your Unity project's `Packages/manifest.json`:

```json
"com.scaredcrowgames.androidoptionpicker": "https://github.com/scaredcrowgames/androidoptionpicker.git?path=src"
```

## Samples
The package includes:

📁 Samples/ contains OptionPickerDemo.unity and scripts

Import it from Package Manager > Samples

## How to use

1. Copy the `AndroidOptionPickerDialog.cs` script into your Unity project.
2. Make sure your project is targeting Android.
3. Call it like this:

```csharp
var picker = new AndroidOptionPickerDialog();
picker.Show(
    new string[] { "Easy", "Medium", "Hard" },
    "Select Difficulty",
    "OK",
    (selectedIndex) => {
        Debug.Log("User selected index: " + selectedIndex);
    }
);
```

## Contact us
> [!TIP]
> All discussions, requests and bug reports can be left in the corresponding [Discord channel](https://discord.gg/NZrN52A7NU) or here in Discussions
