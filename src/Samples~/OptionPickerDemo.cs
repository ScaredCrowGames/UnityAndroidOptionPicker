using UnityEngine;
using UnityEngine.UI;

namespace OptionPicker.Samples
{
    public class OptionPickerDemo : MonoBehaviour
    {
        // Recommended to use TextMeshPro instead
        [SerializeField] private Text _statusText;
        [SerializeField] private Button _buttonVertical;
        [SerializeField] private Button _buttonVerticalWrap;

        private IOptionPicker _picker;

        private string _header = "Options";
        private string[] _options = new[] { "Option 1", "Option 2", "Option 3", "Option 4", "Option 5" };
        private string _confirmButtonText = "Confirm";

        private void Start()
        {
            _buttonVertical.onClick.AddListener(OnVerticalButtonClicked);
            _buttonVerticalWrap.onClick.AddListener(OnVerticalWrapButtonClicked);

#if UNITY_EDITOR
            _picker = new UnityOptionPicker();
#elif UNITY_ANDROID
            _picker = new AndroidOptionPicker();
#endif
        }

        private void OnVerticalButtonClicked()
            => _picker?.Show(_options, _header, _confirmButtonText, false, OnOptionSelected);

        private void OnVerticalWrapButtonClicked()
            => _picker?.Show(_options, _header, _confirmButtonText, true, OnOptionSelected);

        private void OnOptionSelected(int index)
        {
            _statusText.text = _options[index];

            Debug.Log($"Option with index of {index} selected: {_options[index]}");
        }
    }

#if UNITY_EDITOR
    class UnityOptionPicker : IOptionPicker
    {
        public void Show(string[] options, string header, string confirmButtonText, bool wrapSelectorWheel, System.Action<int> callback)
        {
            callback?.Invoke(0);
        }
    }
#endif
}