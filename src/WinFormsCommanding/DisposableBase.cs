namespace System.Windows.Forms.Input {
    /// <inheritdoc cref="IDisposable"/>
    /// <summary>
    /// A class implementing Disposable Pattern. This class must be inherited.
    /// </summary>
    public abstract class DisposableBase : IDisposable {

        /// <summary>
        /// Class finalizer.
        /// </summary>
        ~DisposableBase() {
            if (IsDisposed) {
                return;
            }

            Dispose(true);

            _isDisposed = false;

            Disposed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// The event which will be fired when object is disposed, by user or by CLR.
        /// </summary>
        public event EventHandler<EventArgs> Disposed;

        /// <summary>
        /// Gets a <see cref="bool"/> indicating whether this object is disposed.
        /// An <see cref="ObjectDisposedException"/> should be thrown when usage of a disposed object is used.
        /// </summary>
        public bool IsDisposed => _isDisposed;

        public void Dispose() {
            if (IsDisposed) {
                return;
            }

            Dispose(true);

            if (!KeepFinalizer) {
                GC.SuppressFinalize(this);
            }

            _isDisposed = true;

            Disposed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Perform actual disposing task. This method must be overridden.
        /// </summary>
        /// <param name="disposing">If this method is called by user (in <see cref="Dispose"/>) then <see langword="true"/>;
        /// otherwise (in <see cref="Finalize"/>) then <see langword="false"/>.</param>
        protected virtual void Dispose(bool disposing) {
        }

        /// <summary>
        /// Ensures that this instance is not disposed. Otherwise this method throws an <see cref="ObjectDisposedException"/>.
        /// </summary>
        protected void EnsureNotDisposed() {
            if (IsDisposed) {
                throw new ObjectDisposedException("this");
            }
        }

        protected virtual bool KeepFinalizer { get; } = false;

        private bool _isDisposed;

    }
}
