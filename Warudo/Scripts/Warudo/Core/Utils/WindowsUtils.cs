#if UNITY_STANDALONE_WIN
using System;
using System.Runtime.InteropServices;

namespace Warudo.Core.Utils {
    /// <see>https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-messagebox</see>
    public static class WindowsUtils {
        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();

        public static IntPtr GetWindowHandle() {
            return GetActiveWindow();
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr hwnd, String lpText, String lpCaption, uint uType);

        /// <summary>
        /// Shows Error alert box with OK button.
        /// </summary>
        /// <param name="text">Main alert text / content.</param>
        /// <param name="caption">Message box title.</param>
        public static void Alert(string text, string caption) {
            try {
                MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000000L | 0x00000010L));
            } catch (Exception) {
                // ignored
            }
        }
        
        public static ConfirmType Confirm(string text, string caption) {
            try {
                var result = MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000000L | 0x00000003L | 0x00000030L));
                return result switch {
                    6 => ConfirmType.Yes,
                    7 => ConfirmType.No,
                    2 => ConfirmType.Cancel,
                    _ => ConfirmType.Cancel
                };
            } catch (Exception) {
                // ignored
            }
            return ConfirmType.Cancel;
        }

        public enum ConfirmType {
            Yes,
            No,
            Cancel
        }
    }
}

#endif
