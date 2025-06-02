using System;
using UnityEngine;

namespace OptionPicker
{
#if UNITY_ANDROID
    public class AndroidOptionPicker : IOptionPicker
    {
        private AndroidJavaObject _activity;
        private string[] _options;

        public AndroidOptionPicker()
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }

        public void Show(string[] options, string header, string confirmButtonText, bool wrapSelectorWheel, Action<int> callback)
        {
            _options = options;

            _activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                try
                {
                    AndroidJavaObject numberPicker = new AndroidJavaObject("android.widget.NumberPicker", _activity);
                    numberPicker.Call("setMinValue", 0);
                    numberPicker.Call("setMaxValue", options.Length - 1);
                    numberPicker.Call("setDisplayedValues", options);
                    numberPicker.Call("setWrapSelectorWheel", wrapSelectorWheel);

                    AndroidJavaObject layout = new AndroidJavaObject("android.widget.LinearLayout", _activity);
                    layout.Call("setOrientation", 1);
                    layout.Call("addView", numberPicker);

                    AndroidJavaObject dialogBuilder = new AndroidJavaObject("android.app.AlertDialog$Builder", _activity);
                    dialogBuilder.Call<AndroidJavaObject>("setView", layout);
                    dialogBuilder.Call<AndroidJavaObject>("setTitle", header);
                    dialogBuilder.Call<AndroidJavaObject>("setPositiveButton", confirmButtonText, new DialogClickListener(this, numberPicker, callback));

                    AndroidJavaObject alertDialog = dialogBuilder.Call<AndroidJavaObject>("create");
                    alertDialog.Call("show");
                }
                catch (Exception e)
                {
                    Debug.LogError("Error showing dialog: " + e.Message);
                }
            }));
        }

        class DialogClickListener : AndroidJavaProxy
        {
            private AndroidOptionPicker _pickerDialog;
            private AndroidJavaObject _numberPicker;
            private Action<int> _callback;

            public DialogClickListener(AndroidOptionPicker pickerDialog, AndroidJavaObject numberPicker, Action<int> callback)
                : base("android.content.DialogInterface$OnClickListener")
            {
                _pickerDialog = pickerDialog;
                _numberPicker = numberPicker;
                _callback = callback;
            }

            public void onClick(AndroidJavaObject dialog, int which)
            {
                int selectedValueIndex = _numberPicker.Call<int>("getValue");
                _callback?.Invoke(selectedValueIndex);
                
                string selectedValue = _pickerDialog._options[selectedValueIndex];
            }
        }
    }
#endif
}