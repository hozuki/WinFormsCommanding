using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    /// <summary>
    /// Command binding for commands.
    /// </summary>
    /// <remarks>
    /// Events only raise when <see cref="Command"/> is an instance of <see cref="RoutedCommand"/>.
    /// Otherwise, it only acts as a command wrapper.
    /// </remarks>
    public sealed class CommandBinding {

        // ReSharper disable once NotNullMemberIsNotInitialized
        /// <summary>
        /// Creates a new <see cref="CommandBinding"/>.
        /// </summary>
        /// <param name="command">The <see cref="ICommand"/> to bind.</param>
        public CommandBinding([NotNull] ICommand command) {
            Command = command;
        }

        /// <summary>
        /// Gets or sets the command in this <see cref="CommandBinding"/>.
        /// </summary>
        [NotNull]
        public ICommand Command {
            get => _command;
            set {
                if (value == null) {
                    throw new ArgumentNullException(nameof(value));
                }

                var oldCommand = _command;

                if (oldCommand == value) {
                    return;
                }

                (oldCommand as RoutedCommand)?.DetachFromCurrentCommandBinding();

                if (value is RoutedCommand newCommand) {
                    newCommand.DetachFromCurrentCommandBinding();
                    newCommand.AttachToCommandBinding(this);
                }

                _command = value;
            }
        }

        /// <summary>
        /// Occurs before <see cref="Executed"/>.
        /// </summary>
        public event EventHandler<ExecutedEventArgs> PreviewExecuted;

        /// <summary>
        /// Occurs when the attached command is executed.
        /// </summary>
        public event EventHandler<ExecutedEventArgs> Executed;

        /// <summary>
        /// Occurs before <see cref="Reverted"/>.
        /// </summary>
        public event EventHandler<RevertedEventArgs> PreviewReverted;

        /// <summary>
        /// Occurs when the attached command is reverted.
        /// </summary>
        public event EventHandler<RevertedEventArgs> Reverted;

        /// <summary>
        /// Occurs when querying whether the attached command can be executed.
        /// </summary>
        public event EventHandler<QueryCanExecuteEventArgs> QueryCanExecute;

        /// <summary>
        /// Occurs when querying whether the attached command can be reverted.
        /// </summary>
        public event EventHandler<QueryCanRevertEventArgs> QueryCanRevert;

        /// <summary>
        /// Occurs when querying whether the attached command can be recorded.
        /// </summary>
        public event EventHandler<QueryCanRecordEventArgs> QueryCanRecord;

        /// <summary>
        /// Raises <see cref="PreviewExecuted"/> event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        internal void RaisePreviewExecuted([NotNull] object sender, [NotNull] ExecutedEventArgs e) {
            PreviewExecuted?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises <see cref="Executed"/> event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        internal void RaiseExecuted([NotNull] object sender, [NotNull] ExecutedEventArgs e) {
            Executed?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises <see cref="PreviewReverted"/> event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        internal void RaisePreviewReverted([NotNull] object sender, [NotNull] RevertedEventArgs e) {
            PreviewReverted?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises <see cref="Reverted"/> event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        internal void RaiseReverted([NotNull] object sender, [NotNull] RevertedEventArgs e) {
            Reverted?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises <see cref="QueryCanExecute"/> event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        internal void RaiseQueryCanExecute([NotNull] object sender, [NotNull] QueryCanExecuteEventArgs e) {
            QueryCanExecute?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises <see cref="QueryCanRevert"/> event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        internal void RaiseQueryCanRevert([NotNull] object sender, [NotNull] QueryCanRevertEventArgs e) {
            QueryCanRevert?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises <see cref="QueryCanRecord"/> event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        internal void RaiseQueryCanRecord([NotNull] object sender, [NotNull] QueryCanRecordEventArgs e) {
            QueryCanRecord?.Invoke(sender, e);
        }

        [NotNull]
        private ICommand _command;

    }
}
