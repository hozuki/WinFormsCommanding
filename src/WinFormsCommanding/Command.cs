using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    /// <inheritdoc cref="DisposableBase"/>
    /// <inheritdoc cref="ICommand"/>
    /// <summary>
    /// Ths base class for commands.
    /// This class must be inherited.
    /// </summary>
    public abstract class Command : DisposableBase, ICommand {

        /// <summary>
        /// Creates a new <see cref="Command"/>.
        /// </summary>
        protected Command() {
            CommandManager.Instance.RegisterCommand(this);
        }

        /// <summary>
        /// Gets or sets the name of this <see cref="Command"/>.
        /// </summary>
        [NotNull]
        public string Name {
            get => _name;
            set => _name = value ?? string.Empty;
        }

        /// <summary>
        /// Gets or sets the description of this <see cref="Command"/>.
        /// </summary>
        [NotNull]
        public string Description {
            get => _description;
            set => _description = value ?? string.Empty;
        }

        public event EventHandler CanExecuteChanged;

        public event EventHandler CanRevertChanged;

        public event EventHandler CanRecordChanged;

        public void Execute(object parameter) {
            if (!_canExecute) {
                return;
            }

            ExecuteInternal(parameter);
        }

        public void Revert(object parameter) {
            if (!_canRevert) {
                return;
            }

            RevertInternal(parameter);
        }

        public bool CanExecuteNow => _canExecute;

        public bool CanRevertNow => _canRevert;

        public bool CanRecordNow => _canRecord;

        public bool CanExecute(object parameter) {
            var b = CanExecuteInternal(parameter);

            if (b != _canExecute) {
                _canExecute = b;

                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            return b;
        }

        public bool CanRevert(object parameter) {
            var b = CanRevertInternal(parameter);

            if (b != _canRevert) {
                _canRevert = b;

                CanRevertChanged?.Invoke(this, EventArgs.Empty);
            }

            return b;
        }

        public bool CanRecord(object parameter) {
            var b = CanRecordInternal(parameter);

            if (b != _canRecord) {
                _canRecord = b;

                CanRecordChanged?.Invoke(this, EventArgs.Empty);
            }

            return b;
        }

        /// <summary>
        /// Default value of <see cref="System.Windows.Input.ICommand.CanExecute"/>-related values.
        /// </summary>
        internal const bool DefaultCanExecute = true;
        /// <summary>
        /// Default value of <see cref="ICommand.CanRevert"/>-related values.
        /// </summary>
        internal const bool DefaultCanRevert = false;
        /// <summary>
        /// Default value of <see cref="ICommand.CanRecord"/>-related values.
        /// </summary>
        internal const bool DefaultCanRecord = false;

        protected override void Dispose(bool disposing) {
            CommandManager.Instance.UnregisterCommand(this);

            base.Dispose(disposing);
        }

        /// <summary>
        /// When overridden in child classes, performs the internal <see cref="Execute"/> call.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        protected abstract void ExecuteInternal([CanBeNull] object parameter);

        /// <summary>
        /// When overridden in child classes, performs the internal <see cref="Revert"/> call.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        protected abstract void RevertInternal([CanBeNull] object parameter);

        /// <summary>
        /// When overridden in child classes, performs the internal <see cref="CanExecute"/> call.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns></returns>
        protected abstract bool CanExecuteInternal([CanBeNull] object parameter);

        /// <summary>
        /// When overridden in child classes, performs the internal <see cref="CanRevert"/> call.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns></returns>
        protected abstract bool CanRevertInternal([CanBeNull] object parameter);

        /// <summary>
        /// When overridden in child classes, performs the internal <see cref="CanRecord"/> call.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns></returns>
        protected abstract bool CanRecordInternal([CanBeNull] object parameter);

        private bool _canExecute = DefaultCanExecute;

        private bool _canRevert = DefaultCanRevert;

        private bool _canRecord = DefaultCanRecord;

        private string _name = string.Empty;

        private string _description = string.Empty;

    }
}
