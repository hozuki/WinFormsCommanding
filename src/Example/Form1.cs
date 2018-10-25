using System;
using System.Windows.Forms;
using System.Windows.Forms.Input;

namespace Example {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            InitializeCommands();
        }

        private void InitializeCommands() {
            /*
             * How to use ICommand and other stuff:
             *
             * 1. Create an ICommand.
             * 2. Create a CommandBinding on this ICommand.
             * 3. Create an ICommandSource which uses this ICommand.
             * 4. Listen to CommandBinding's events.
             *
             * Step 3 and 4 can be in arbitrary order.
             *
             */

            var binding = new CommandBinding(_command1);

            binding.Executed += (s, e) => {
                var paramStr = e.Parameter == null ? "(null)" : e.Parameter.ToString();
                MessageBox.Show($"This is command 1.{Environment.NewLine}Command parameter: {paramStr}");
            };

            binding.QueryCanExecute += (s, e) => {
                e.CanExecute = _command1Enabled;
            };

            btnInvoke1.CreateCommandSourceBuilder().WithCommandBinding(binding).Build();
            btnInvoke1Param.CreateCommandSourceBuilder().WithCommandBinding(binding).WithCommandParameter(1234).Build();
            mnuFileInvoke1.CreateCommandSourceBuilder().WithCommandBinding(binding).Build();

            binding = new CommandBinding(_toggleCommand1);

            binding.Executed += (s, e) => {
                _command1Enabled = !_command1Enabled;
                CommandManager.Instance.InvalidateRequerySuggested();
            };

            btnToggle1.CreateCommandSourceBuilder().WithCommandBinding(binding).Build();

            binding = new CommandBinding(_command2);

            binding.Executed += (s, e) => {
                MessageBox.Show("This is command 2.");
                _delegateCommand.Execute(null);
            };

            btnInvoke2.CreateCommandSourceBuilder().WithCommandBinding(binding).Build();

            binding = new CommandBinding(_exitCommand);

            binding.Executed += (s, e) => {
                Close();
            };

            mnuFileExit.CreateCommandSourceBuilder().WithCommandBinding(binding).Build();
        }

        private readonly ICommand _command1 = new RoutedUICommand("Ctrl+1");
        private readonly ICommand _toggleCommand1 = new RoutedCommand();
        private readonly ICommand _command2 = new RoutedCommand();
        private readonly ICommand _exitCommand = new RoutedUICommand("Alt+X");
        private readonly ICommand _delegateCommand = new DelegateCommand(_ => {
            MessageBox.Show("Hello from a DelegateCommand.");
        });

        private bool _command1Enabled = true;

    }
}
