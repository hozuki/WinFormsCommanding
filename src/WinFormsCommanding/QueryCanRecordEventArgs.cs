using JetBrains.Annotations;

namespace System.Windows.Forms.Input {
    public sealed class QueryCanRecordEventArgs : EventArgs {

        public QueryCanRecordEventArgs([CanBeNull] object parameter) {
            Parameter = parameter;
        }

        [CanBeNull]
        public object Parameter { get; }

        public bool CanRecord { get; set; } = Command.DefaultCanRecord;

    }
}
