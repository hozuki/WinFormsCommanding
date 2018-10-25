using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    /// <summary>
    /// A command source that can execute commands.
    /// </summary>
    public interface ICommandSource {

        /// <summary>
        /// Gets or sets the command to execute.
        /// </summary>
        [CanBeNull]
        ICommand Command { get; set; }

        /// <summary>
        /// Gets or sets the command parameter associated with this <see cref="ICommandSource"/>.
        /// </summary>
        [CanBeNull]
        object CommandParameter { get; set; }

    }
}
