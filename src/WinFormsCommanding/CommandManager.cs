using System.Collections.Generic;
using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    /// <summary>
    /// Represents a manager for command creation and state maintenance.
    /// </summary>
    public sealed class CommandManager {

        /// <summary>
        /// Creates a new <see cref="CommandManager"/>.
        /// </summary>
        private CommandManager() {
        }

        /// <summary>
        /// Gets the singleton of <see cref="CommandManager"/>.
        /// </summary>
        [NotNull]
        public static CommandManager Instance => _commandManager ?? (_commandManager = new CommandManager());

        /// <summary>
        /// Occurs when a requery of command states is suggested.
        /// </summary>
        public event EventHandler RequerySuggested;

        /// <summary>
        /// Invalidates cached command states, and forces all commands created by this <see cref="CommandManager"/> to requery their states.
        /// </summary>
        public void InvalidateRequerySuggested() {
            var updatedCommands = new HashSet<ICommand>();

            foreach (var command in _createdCommands) {
                if (command is RoutedCommand) {
                    continue;
                }

                command.CanExecute(null);
                updatedCommands.Add(command);
            }

            foreach (var source in _createdCommandSources) {
                if (!(source.Command is RoutedCommand routed)) {
                    continue;
                }

                if (updatedCommands.Contains(routed)) {
                    continue;
                }

                routed.CanExecute(source.CommandParameter);

                updatedCommands.Add(routed);
            }

            RequerySuggested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Hooks to a <see cref="Form"/>, so that <see cref="RequerySuggested"/> will be fired every time the form is activated
        /// or deactivated.
        /// </summary>
        /// <param name="form">The form to hook to.</param>
        public void HookForm([NotNull] Form form) {
            if (form == null) {
                throw new ArgumentNullException(nameof(form));
            }

            form.Activated += OnUpdateCommandListStatus;
            form.Deactivate += OnUpdateCommandListStatus;
        }

        /// <summary>
        /// Unhooks from a <see cref="Form"/>.
        /// </summary>
        /// <param name="form">The form to unhook from.</param>
        public void UnhookForm([NotNull] Form form) {
            if (form == null) {
                throw new ArgumentNullException(nameof(form));
            }

            form.Activated -= OnUpdateCommandListStatus;
            form.Deactivate -= OnUpdateCommandListStatus;
        }

        /// <summary>
        /// Registers a command as managed by this <see cref="CommandManager"/>.
        /// </summary>
        /// <param name="command">The command to register.</param>
        public void RegisterCommand([NotNull] ICommand command) {
            if (command != null && !_createdCommands.Contains(command)) {
                _createdCommands.Add(command);
            }
        }

        /// <summary>
        /// Unregisters a command from this <see cref="CommandManager"/>.
        /// </summary>
        /// <param name="command">The command to unregister.</param>
        public void UnregisterCommand([NotNull] ICommand command) {
            if (command != null && _createdCommands.Contains(command)) {
                _createdCommands.Remove(command);
            }
        }

        /// <summary>
        /// Registers a command source as managed by this <see cref="CommandManager"/>.
        /// </summary>
        /// <param name="commandSource">The command source to register.</param>
        internal void RegisterCommandSource([NotNull] ICommandSource commandSource) {
            if (commandSource != null && !_createdCommandSources.Contains(commandSource)) {
                _createdCommandSources.Add(commandSource);
            }
        }

        /// <summary>
        /// Unregisters a command source from this <see cref="CommandManager"/>.
        /// </summary>
        /// <param name="commandSource">The command source to unregister.</param>
        internal void UnregisterCommandSource([NotNull] ICommandSource commandSource) {
            if (commandSource != null && _createdCommandSources.Contains(commandSource)) {
                _createdCommandSources.Remove(commandSource);
            }
        }

        [NotNull, ItemNotNull]
        private readonly HashSet<ICommand> _createdCommands = new HashSet<ICommand>();

        [NotNull, ItemNotNull]
        private readonly HashSet<ICommandSource> _createdCommandSources = new HashSet<ICommandSource>();

        private void OnUpdateCommandListStatus([NotNull] object sender, [NotNull] EventArgs e) {
            InvalidateRequerySuggested();
        }

        [CanBeNull]
        private static CommandManager _commandManager;

    }
}
