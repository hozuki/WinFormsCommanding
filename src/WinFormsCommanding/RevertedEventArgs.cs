using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    public sealed class RevertedEventArgs : EventArgs {

        public RevertedEventArgs([CanBeNull] object parameter) {
            Parameter = parameter;
        }

        [CanBeNull]
        public object Parameter { get; }

    }
}
