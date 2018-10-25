using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    // ReSharper disable once InconsistentNaming
    /// <inheritdoc />
    /// <summary>
    /// A <see cref="RoutedCommand"/> for controls.
    /// </summary>
    public class RoutedUICommand : RoutedCommand {

        /// <summary>
        /// Creates a new <see cref="RoutedUICommand"/>.
        /// </summary>
        public RoutedUICommand() {
            ShortcutKeys = Keys.None;
        }

        /// <summary>
        /// Creates a new <see cref="RoutedUICommand"/> with shortcut keys.
        /// </summary>
        /// <param name="shortcutKeys">Shortcut keys.</param>
        public RoutedUICommand(Keys shortcutKeys) {
            ShortcutKeys = shortcutKeys;
        }

        /// <summary>
        /// Creates a new <see cref="RoutedUICommand"/> with shortcut keys.
        /// </summary>
        /// <param name="shortcutKeys">Shortcut keys.</param>
        public RoutedUICommand(Shortcut shortcutKeys) {
            ShortcutKeys = ShortcutMapper.Map(shortcutKeys);
        }

        /// <summary>
        /// Creates a new <see cref="RoutedUICommand"/> with shortcut keys.
        /// </summary>
        /// <param name="shortcutKeys">Readable shortcut keys string.</param>
        public RoutedUICommand([NotNull] string shortcutKeys) {
            ShortcutKeys = ShortcutMapper.ParseShortcutKeys(shortcutKeys);
        }

        /// <summary>
        /// Gets the shortcut keys for this <see cref="RoutedUICommand"/>.
        /// </summary>
        public Keys ShortcutKeys { get; }

        /// <summary>
        /// Gets or sets the default value of whether automatically setting shortcut keys on supported controls.
        /// </summary>
        public static bool DefaultSetShortcutKeys { get; set; } = true;

        /// <summary>
        /// Gets or sets the default value of whether automatically setting shortcut display strings on supported controls.
        /// </summary>
        public static bool DefaultSetShortcutText { get; set; } = true;

        /// <summary>
        /// Sets whether automatically setting shortcut key(s) on supported controls.
        /// </summary>
        public bool SetShortcutKeys { internal get; set; } = DefaultSetShortcutKeys;

        /// <summary>
        /// Sets whether automatically setting shortcut display string on supported controls.
        /// </summary>
        public bool SetShortcutText { internal get; set; } = DefaultSetShortcutText;

    }
}
