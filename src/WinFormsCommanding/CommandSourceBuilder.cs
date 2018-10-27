using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    /// <inheritdoc />
    /// <summary>
    /// Template implementation for <see cref="ICommandSourceBuilder"/>.
    /// </summary>
    public abstract class CommandSourceBuilder : ICommandSourceBuilder {

        public ICommandSourceBuilder WithCommand(ICommand command) {
            CommandSource.Command = command;

            return this;
        }

        public ICommandSourceBuilder WithCommandParameter(object commandParameter) {
            CommandSource.CommandParameter = commandParameter;

            return this;
        }

        public ICommandSource Build() {
            return CommandSource;
        }

        /// <summary>
        /// When overwritten in child classes, creates the initial <see cref="ICommandSource"/>.
        /// </summary>
        /// <returns>Created <see cref="ICommandSource"/>.</returns>
        [NotNull]
        protected abstract ICommandSource CreateCommandSource();

        [NotNull]
        private ICommandSource CommandSource => _commandSource ?? (_commandSource = CreateCommandSource());

        [CanBeNull]
        private ICommandSource _commandSource;

    }
}
