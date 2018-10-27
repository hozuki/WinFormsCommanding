namespace System.Windows.Forms.Input {
    /// <inheritdoc cref="DisposableBase"/>
    /// <inheritdoc cref="ICommandSource"/>
    /// <summary>
    /// Template implementation for <see cref="ICommandSource"/>.
    /// </summary>
    public abstract class CommandSource : DisposableBase, ICommandSource {

        protected CommandSource() {
            CommandManager.Instance.RegisterCommandSource(this);
        }

        public abstract ICommand Command { get; set; }

        public abstract object CommandParameter { get; set; }

        protected override void Dispose(bool disposing) {
            CommandManager.Instance.UnregisterCommandSource(this);

            base.Dispose(disposing);
        }

    }
}
