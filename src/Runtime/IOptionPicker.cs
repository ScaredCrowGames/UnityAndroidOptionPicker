using System;

namespace OptionPicker
{
    public interface IOptionPicker
    {
        /// <summary>
        /// Displays a picker dialog with given options.
        /// </summary>
        /// <param name="options">List of string options to pick from.</param>
        /// <param name="header">Title for the dialog.</param>
        /// <param name="confirmButtonText">Text for the confirm button.</param>
        /// <param name="wrapSelectorWheel">Whether the selector wheel wraps around when reaching the end.</param>
        /// <param name="callback">Callback with the index of the selected option.</param>
        void Show(string[] options, string header, string confirmButtonText, bool wrapSelectorWheel, Action<int> callback);
    }
}