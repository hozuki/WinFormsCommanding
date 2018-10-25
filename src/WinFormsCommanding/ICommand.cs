using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    /// <inheritdoc />
    /// <summary>
    /// The base command interface.
    /// In addition to <see cref="System.Windows.Input.ICommand"/>, this interface also supports reverting
    /// and operation history.
    /// </summary>
    public interface ICommand : System.Windows.Input.ICommand {

        /// <summary>
        /// Occurs when <see cref="CanRevert"/> returns a different value.
        /// </summary>
        event EventHandler CanRevertChanged;

        /// <summary>
        /// Occurs when <see cref="CanRecord"/> returns a different value.
        /// </summary>
        event EventHandler CanRecordChanged;

        /// <summary>
        /// Revert this command.
        /// </summary>
        /// <param name="parameter">The command parameter applied to this command.</param>
        void Revert([CanBeNull] object parameter);

        /// <summary>
        /// Returns whether this command can be reverted.
        /// </summary>
        /// <param name="parameter">The command parameter applied to this command.</param>
        /// <returns><see langword="true"/> if this command can be reverted, otherwise <see langword="false"/>.</returns>
        bool CanRevert([CanBeNull] object parameter);

        /// <summary>
        /// Returns whether this command can be recorded to operation history. Reserved for future use.
        /// </summary>
        /// <param name="parameter">The command parameter applied to this command.</param>
        /// <returns><see langword="true"/> if this command can be recorded, otherwise <see langword="false"/>.</returns>
        bool CanRecord([CanBeNull] object parameter);

        /// <summary>
        /// Gets whether this command can be executed.
        /// Getting this property does not reevaluate command status.
        /// </summary>
        bool CanExecuteNow { get; }

        /// <summary>
        /// Gets whether this command can be reverted.
        /// Getting this property does not reevaluate command status.
        /// </summary>
        bool CanRevertNow { get; }

        /// <summary>
        /// Gets whether this command can be recorded to operation history.
        /// Getting this property does not reevaluate command status.
        /// </summary>
        bool CanRecordNow { get; }

    }
}
