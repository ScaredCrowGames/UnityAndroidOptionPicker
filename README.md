# Android native Option Picker Dialog for Unity

A simple, lightweight native Android option picker implemented using Unity's `AndroidJavaObject` bridge. Unlike Unity UI-based pickers, this uses the native Android `AlertDialog` and `NumberPicker` to present a list of options in a clean, consistent, and mobile-native experience.

---
## Table of Contents
- [Installation](#installation)
- [Samples](#samples)
- [How to use](#how-to-use)
- [Contact us](#contact-us)
- [Related repositories](#related-repositories)

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
3. Get it from [Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/native-mobile-option-picker-322382)

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

## Related repositories
Here are some related projects you might find useful:
- [Android time picker](https://github.com/ScaredCrowGames/UnityAndroidTimePicker) – Native Android time picker for Unity
- [Android date picker](https://github.com/ScaredCrowGames/UnityAndroidDatePicker) – Native Android date picker for Unity
