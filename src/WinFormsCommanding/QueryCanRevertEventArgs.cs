using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    public sealed class QueryCanRevertEventArgs : EventArgs {

        public QueryCanRevertEventArgs([CanBeNull] object parameter) {
            Parameter = parameter;
        }

        [CanBeNull]
        public object Parameter { get; }

        public bool CanRevert { get; set; } = Command.DefaultCanRevert;

    }
}
