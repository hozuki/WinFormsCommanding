using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    /// <inheritdoc />
    /// <summary>
    /// Represents a routed command.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The real "route" part is implemented by the message mechanism in Windows GUI.
    /// Therefore this class is actually an identifying class for <see cref="CommandBinding"/> and other classes.
    /// </para>
    /// <para>
    /// A <see cref="RoutedCommand"/> can be attached to at most one <see cref="CommandBinding"/>.
    /// </para>
    /// </remarks>
    public class RoutedCommand : Command {

        /// <summary>
        /// Attach this <see cref="RoutedCommand"/> to a <see cref="CommandBinding"/>.
        /// </summary>
        /// <param name="commandBinding">The <see cref="CommandBinding"/> to attach to.</param>
        internal void AttachToCommandBinding([NotNull] CommandBinding commandBinding) {
            if (commandBinding == null) {
                throw new ArgumentNullException(nameof(commandBinding));
            }

            if (_commandBinding != null) {
                throw new InvalidOperationException("A " + nameof(RoutedCommand) + " can only attach to at most one " + nameof(CommandBinding) + ".");
            }

            _commandBinding = commandBinding;
        }

        /// <summary>
        /// Attach this <see cref="RoutedCommand"/> from a <see cref="CommandBinding"/>.
        /// </summary>
        /// <param name="commandBinding">The <see cref="CommandBinding"/> to detach from. It must be the same one which this command was attached to.</param>
        internal void DetachFromCommandBinding([NotNull] CommandBinding commandBinding) {
            if (commandBinding == null) {
                throw new ArgumentNullException(nameof(commandBinding));
            }

            if (_commandBinding != commandBinding) {
                throw new InvalidOperationException("Detach must be called from the original " + nameof(CommandBinding) + ".");
            }

            _commandBinding = null;
        }

        /// <summary>
        /// Detach this <see cref="RoutedCommand"/> from current attached <see cref="CommandBinding"/>.
        /// If currently there is no <see cref="CommandBinding"/> attached to, this method does nothing.
        /// </summary>
        internal void DetachFromCurrentCommandBinding() {
            if (_commandBinding != null) {
                DetachFromCommandBinding(_commandBinding);
            }
        }

        /// <summary>
        /// Gets the <see cref="CommandBinding"/> currently attached to.
        /// </summary>
        [CanBeNull]
        internal CommandBinding CurrentCommandBinding => _commandBinding;

        protected override void ExecuteInternal(object parameter) {
            if (_commandBinding == null) {
                return;
            }

            var e = new ExecutedEventArgs(parameter);

            _commandBinding.RaisePreviewExecuted(this, e);
            _commandBinding.RaiseExecuted(this, e);
        }

        protected override void RevertInternal(object parameter) {
            if (_commandBinding == null) {
                return;
            }

            var e = new RevertedEventArgs(parameter);

            _commandBinding.RaisePreviewReverted(this, e);
            _commandBinding.RaiseReverted(this, e);
        }

        protected override bool CanExecuteInternal(object parameter) {
            if (_commandBinding == null) {
                return DefaultCanExecute;
            }

            var e = new QueryCanExecuteEventArgs(parameter);

            _commandBinding.RaiseQueryCanExecute(this, e);

            return e.CanExecute;
        }

        protected override bool CanRevertInternal(object parameter) {
            if (_commandBinding == null) {
                return DefaultCanRevert;
            }

            var e = new QueryCanRevertEventArgs(parameter);

            _commandBinding.RaiseQueryCanRevert(this, e);

            return e.CanRevert;
        }

        protected override bool CanRecordInternal(object parameter) {
            if (_commandBinding == null) {
                return DefaultCanRecord;
            }

            var e = new QueryCanRecordEventArgs(parameter);

            _commandBinding.RaiseQueryCanRecord(this, e);

            return e.CanRecord;
        }

        [CanBeNull]
        private CommandBinding _commandBinding;

    }
}
