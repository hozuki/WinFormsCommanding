using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    public sealed class QueryCanExecuteEventArgs : EventArgs {

        public QueryCanExecuteEventArgs([CanBeNull] object parameter) {
            Parameter = parameter;
        }

        [CanBeNull]
        public object Parameter { get; }

        public bool CanExecute { get; set; } = Command.DefaultCanExecute;

    }
}
