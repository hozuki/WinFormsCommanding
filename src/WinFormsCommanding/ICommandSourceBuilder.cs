using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    /// <summary>
    /// A builder that builds <see cref="ICommandSource"/> from other inputs.
    /// </summary>
    public interface ICommandSourceBuilder {

        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Current <see cref="ICommandSourceBuilder"/>.</returns>
        [NotNull]
        ICommandSourceBuilder WithCommand([NotNull] ICommand command);

        /// <summary>
        /// Sets the command parameter.
        /// </summary>
        /// <param name="commandParameter">The command parameter.</param>
        /// <returns>Current <see cref="ICommandSourceBuilder"/>.</returns>
        [NotNull]
        ICommandSourceBuilder WithCommandParameter([CanBeNull] object commandParameter);

        /// <summary>
        /// Confirms all configurations and builds target <see cref="ICommandSource"/>.
        /// </summary>
        /// <returns>Built <see cref="ICommandSource"/>.</returns>
        [NotNull]
        ICommandSource Build();

    }
}
