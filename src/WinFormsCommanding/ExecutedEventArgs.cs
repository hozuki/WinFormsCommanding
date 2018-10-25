using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    public sealed class ExecutedEventArgs : EventArgs {

        public ExecutedEventArgs([CanBeNull] object parameter) {
            Parameter = parameter;
        }

        [CanBeNull]
        public object Parameter { get; }

    }
}
