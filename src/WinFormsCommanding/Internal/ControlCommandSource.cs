using System.ComponentModel;
using JetBrains.Annotations;

namespace System.Windows.Forms.Input.Internal {
    /// <inheritdoc />
    /// <summary>
    /// An <see cref="ICommandSource" /> that is created from controls.
    /// </summary>
    internal sealed class ControlCommandSource : CommandSource {

        /// <summary>
        /// Creates a new <see cref="ControlCommandSource"/>.
        /// </summary>
        /// <param name="component">The control used to create this <see cref="ControlCommandSource"/>.</param>
        public ControlCommandSource([NotNull] Component component) {
            if (!IsSupportedComponentType(component)) {
                ThrowControlTypeNotSupported(component);
            }

            Control = component;

            SubscribeControl();
        }

        /// <summary>
        /// Creates a new <see cref="ControlCommandSource"/>.
        /// </summary>
        /// <param name="component">The control used to create this <see cref="ControlCommandSource"/>.</param>
        /// <param name="command">The command for this <see cref="ICommandSource"/>.</param>
        public ControlCommandSource([NotNull] Component component, [CanBeNull] ICommand command) {
            if (!IsSupportedComponentType(component)) {
                ThrowControlTypeNotSupported(component);
            }

            Control = component;
            Command = command;

            SubscribeControl();
        }

        public override ICommand Command {
            get => _command;
            set {
                var oldCommand = _command;

                if (oldCommand == value) {
                    return;
                }

                if (oldCommand != null) {
                    oldCommand.CanExecuteChanged -= OnCommandCanExecuteChanged;

                    UnsetShortcutKeys();
                }

                _command = value;

                if (value != null) {
                    value.CanExecuteChanged += OnCommandCanExecuteChanged;
                    // Force firing the event once.
                    OnCommandCanExecuteChanged(this, EventArgs.Empty);

                    SetShortcutKeys();
                    SetShortcutKeysText();
                }
            }
        }

        public override object CommandParameter { get; set; }

        /// <summary>
        /// Gets the control used to create this <see cref="ControlCommandSource"/>.
        /// </summary>
        [NotNull]
        public Component Control { get; }

        protected override void Dispose(bool disposing) {
            UnsubscribeControl();

            base.Dispose(disposing);
        }

        private static bool IsSupportedComponentType([NotNull] Component component) {
            return component is ButtonBase ||
                   component is MenuItem ||
                   component is ToolStripButton ||
                   component is ToolStripSplitButton ||
                   component is ToolStripOverflowButton ||
                   component is ToolStripMenuItem;
        }

        /// <summary>
        /// Subscribes to control interaction events.
        /// </summary>
        private void SubscribeControl() {
            var control = Control;

            switch (control) {
                case ButtonBase button:
                    button.Click += OnControlInteract;
                    break;
                case MenuItem menuItem:
                    menuItem.Click += OnControlInteract;
                    break;
                case ToolStripButton button:
                    button.Click += OnControlInteract;
                    break;
                case ToolStripSplitButton button:
                    button.ButtonClick += OnControlInteract;
                    break;
                case ToolStripOverflowButton button:
                    button.Click += OnControlInteract;
                    break;
                case ToolStripMenuItem menuItem:
                    menuItem.Click += OnControlInteract;
                    break;
                default:
                    ThrowControlTypeNotSupported(control);
                    break;
            }

            var command = Command;

            if (command == null) {
                return;
            }

            var canExecute = command.CanExecuteNow;

            switch (control) {
                case ButtonBase button:
                    button.Enabled = canExecute;
                    break;
                case MenuItem menuItem:
                    menuItem.Enabled = canExecute;
                    break;
                case ToolStripButton button:
                    button.Enabled = canExecute;
                    break;
                case ToolStripSplitButton button:
                    button.Enabled = canExecute;
                    break;
                case ToolStripOverflowButton button:
                    button.Enabled = canExecute;
                    break;
                case ToolStripMenuItem menuItem:
                    menuItem.Enabled = canExecute;
                    break;
                default:
                    ThrowControlTypeNotSupported(control);
                    break;
            }
        }

        /// <summary>
        /// Unsubscribes from control interaction events.
        /// </summary>
        private void UnsubscribeControl() {
            var control = Control;

            switch (control) {
                case ButtonBase button:
                    button.Click -= OnControlInteract;
                    break;
                case MenuItem menuItem:
                    menuItem.Click -= OnControlInteract;
                    break;
                case ToolStripButton button:
                    button.Click -= OnControlInteract;
                    break;
                case ToolStripSplitButton button:
                    button.ButtonClick -= OnControlInteract;
                    break;
                case ToolStripOverflowButton button:
                    button.Click -= OnControlInteract;
                    break;
                case ToolStripMenuItem menuItem:
                    menuItem.Click -= OnControlInteract;
                    break;
                default:
                    ThrowControlTypeNotSupported(control);
                    break;
            }
        }

        private void SetShortcutKeys() {
            if (!(Command is RoutedUICommand command)) {
                return;
            }

            if (!command.SetShortcutKeys) {
                return;
            }

            var shortcutKeys = command.ShortcutKeys;

            if (shortcutKeys == Keys.None) {
                return;
            }

            var control = Control;

            switch (control) {
                case ButtonBase _:
                    break;
                case MenuItem menuItem:
                    menuItem.Shortcut = ShortcutMapper.Map(shortcutKeys);
                    break;
                case ToolStripButton _:
                case ToolStripSplitButton _:
                case ToolStripOverflowButton _:
                    break;
                case ToolStripMenuItem menuItem:
                    menuItem.ShortcutKeys = shortcutKeys;
                    break;
                default:
                    ThrowControlTypeNotSupported(control);
                    break;
            }
        }

        private void SetShortcutKeysText() {
            if (!(Command is RoutedUICommand command)) {
                return;
            }

            if (!command.SetShortcutKeys) {
                return;
            }

            var shortcutKeys = command.ShortcutKeys;

            if (shortcutKeys == Keys.None) {
                return;
            }

            var control = Control;

            switch (control) {
                case ButtonBase _:
                    break;
                case MenuItem _:
                    break;
                case ToolStripButton button:
                    button.AutoToolTip = false;
                    button.ToolTipText = $"{button.Text} ({ShortcutMapper.GetDescription(shortcutKeys)})";
                    break;
                case ToolStripSplitButton button:
                    button.AutoToolTip = false;
                    button.ToolTipText = $"{button.Text} ({ShortcutMapper.GetDescription(shortcutKeys)})";
                    break;
                case ToolStripOverflowButton button:
                    button.AutoToolTip = false;
                    button.ToolTipText = $"{button.Text} ({ShortcutMapper.GetDescription(shortcutKeys)})";
                    break;
                case ToolStripMenuItem menuItem:
                    menuItem.ShortcutKeyDisplayString = ShortcutMapper.GetDescription(shortcutKeys);
                    break;
                default:
                    ThrowControlTypeNotSupported(control);
                    break;
            }
        }

        private void UnsetShortcutKeys() {
            if (!(Command is RoutedUICommand command)) {
                return;
            }

            if (!command.SetShortcutKeys) {
                return;
            }

            var shortcutKeys = command.ShortcutKeys;

            if (shortcutKeys == Keys.None) {
                return;
            }

            var control = Control;

            switch (control) {
                case ButtonBase _:
                    break;
                case MenuItem menuItem:
                    menuItem.Shortcut = Shortcut.None;
                    break;
                case ToolStripButton _:
                case ToolStripSplitButton _:
                case ToolStripOverflowButton _:
                    break;
                case ToolStripMenuItem menuItem:
                    menuItem.ShortcutKeys = Keys.None;
                    break;
                default:
                    ThrowControlTypeNotSupported(control);
                    break;
            }
        }

        private void UnsetShortcutKeysText() {
            if (!(Command is RoutedUICommand command)) {
                return;
            }

            if (!command.SetShortcutText) {
                return;
            }

            var control = Control;

            // TODO: How to implement this?
            throw new NotImplementedException();
        }

        private void OnControlInteract(object sender, EventArgs e) {
            Command?.Execute(CommandParameter);
        }

        /// <summary>
        /// Updates control enabled state when the command's usability is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCommandCanExecuteChanged(object sender, EventArgs e) {
            var command = Command;

            if (command == null) {
                return;
            }

            var canExecute = command.CanExecuteNow;

            switch (Control) {
                case ButtonBase button:
                    button.Enabled = canExecute;
                    break;
                case MenuItem menuItem:
                    menuItem.Enabled = canExecute;
                    break;
                case ToolStripButton button:
                    button.Enabled = canExecute;
                    break;
                case ToolStripSplitButton button:
                    button.Enabled = canExecute;
                    break;
                case ToolStripOverflowButton button:
                    button.Enabled = canExecute;
                    break;
                case ToolStripMenuItem menuItem:
                    menuItem.Enabled = canExecute;
                    break;
                default:
                    throw new NotSupportedException($"The type of control ({Control.GetType().Name}) is not supported.");
            }
        }

        [ContractAnnotation("=> halt")]
        private static void ThrowControlTypeNotSupported([NotNull] Component control) {
            throw new NotSupportedException($"The type of control ({control.GetType().Name}) is not supported.");
        }

        [CanBeNull]
        private ICommand _command;

    }
}
