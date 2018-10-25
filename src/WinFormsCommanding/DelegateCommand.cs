using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    /// <inheritdoc />
    /// <summary>
    /// A simple implementation of <see cref="ICommand"/>.
    /// </summary>
    public class DelegateCommand : Command {

        /// <inheritdoc />
        /// <summary>
        /// Creates a new <see cref="T:System.Windows.Forms.Input.DelegateCommand" />.
        /// </summary>
        /// <param name="onExecuted">Callback when the command is executed.</param>
        public DelegateCommand([NotNull] Action<object> onExecuted)
            : this(onExecuted, null) {
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a new <see cref="T:System.Windows.Forms.Input.DelegateCommand" />.
        /// </summary>
        /// <param name="onExecuted">Callback when the command is executed.</param>
        /// <param name="onCanExecute">Callback when checking whether the command can be executed. Assigning a <see langword="null" /> value will always enable executing the command.</param>
        public DelegateCommand([NotNull] Action<object> onExecuted, [CanBeNull] Predicate<object> onCanExecute)
            : this(onExecuted, onCanExecute, onExecuted, null) {
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates a new <see cref="T:System.Windows.Forms.Input.DelegateCommand" />.
        /// </summary>
        /// <param name="onExecuted">Callback when the command is executed.</param>
        /// <param name="onCanExecute">Callback when checking whether the command can be executed. Assigning a <see langword="null" /> value will always enable executing the command.</param>
        /// <param name="onReverted">Callback when the command is reverted. If the value is <see langword="null" />, this callback will not be called.</param>
        /// <param name="onCanRevert">Callback when checking whether the command can be reverted. Assigning a <see langword="null" /> value will always enable reverting the command.</param>
        /// <param name="onCanRecord">Callback when checking whether the command can be recorded. Assigning a <see langword="null" /> value will always enable recording the command.</param>
        public DelegateCommand([NotNull] Action<object> onExecuted, [CanBeNull] Predicate<object> onCanExecute,
            [CanBeNull] Action<object> onReverted, [CanBeNull] Predicate<object> onCanRevert = null,
            [CanBeNull] Predicate<object> onCanRecord = null) {
            if (onExecuted == null) {
                throw new ArgumentNullException(nameof(onExecuted));
            }

            _onExecuted = onExecuted;
            _onCanExecute = onCanExecute;

            _onReverted = onReverted;
            _onCanRevert = onCanRevert;
            _onCanRecord = onCanRecord;
        }

        protected override void ExecuteInternal(object parameter) {
            _onExecuted(parameter);
        }

        protected override void RevertInternal(object parameter) {
            _onReverted?.Invoke(parameter);
        }

        protected override bool CanExecuteInternal(object parameter) {
            if (_onCanExecute == null) {
                return DefaultCanExecute;
            } else {
                return _onCanExecute(parameter);
            }
        }

        protected override bool CanRevertInternal(object parameter) {
            if (_onCanRevert == null) {
                return DefaultCanRevert;
            } else {
                return _onCanRevert(parameter);
            }
        }

        protected override bool CanRecordInternal(object parameter) {
            if (_onCanRecord == null) {
                return DefaultCanRecord;
            } else {
                return _onCanRecord(parameter);
            }
        }

        [NotNull]
        private readonly Action<object> _onExecuted;

        [CanBeNull]
        private readonly Predicate<object> _onCanExecute;

        [CanBeNull]
        private readonly Action<object> _onReverted;

        [CanBeNull]
        private readonly Predicate<object> _onCanRevert;

        [CanBeNull]
        private readonly Predicate<object> _onCanRecord;

    }
}
