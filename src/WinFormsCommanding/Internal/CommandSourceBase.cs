namespace System.Windows.Forms.Input.Internal {
    /// <inheritdoc cref="DisposableBase"/>
    /// <inheritdoc cref="ICommandSource"/>
    /// <summary>
    /// Template implementation for <see cref="ICommandSource"/>.
    /// </summary>
    internal abstract class CommandSourceBase : DisposableBase, ICommandSource {

        protected CommandSourceBase() {
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
