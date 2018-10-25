# Simple Commanding for Windows Forms

This repository introduces command pattern similar to WPF into Windows Forms.

[![AppVeyor](https://img.shields.io/appveyor/ci/hozuki/winformscommanding.svg)](https://ci.appveyor.com/project/hozuki/winformscommanding)
[![GitHub contributors](https://img.shields.io/github/contributors/hozuki/winformscommanding.svg)](https://github.com/hozuki/winformscommanding/graphs/contributors)
[![Libraries.io for GitHub](https://img.shields.io/librariesio/github/hozuki/winformscommanding.svg)](https://github.com/hozuki/winformscommanding)

## Why?

WPF has its implementation of command pattern, which is a powerful way to manage program logic.
However, due to design decisions, Windows Forms does not naturally support this.
There are projects like [Prism](https://github.com/PrismLibrary/Prism) reimplemented it for WPF-ish environments.
Some commercial libraries have their own implementation, for example [WinForms MVVM](https://documentation.devexpress.com/WindowsForms/113965/Build-an-Application/WinForms-MVVM/Concepts/Commands) of DevExpress.
But still, there is no general, open-sourced version for Windows Forms.
Therefore, here I introduce a WPF-like commanding for Windows Forms.

## Functionalities

- `ICommand`, `CommandBinding` and `ICommandSource` similar to what they are in WPF.
- Basic command types: `DelegateCommand`, `RoutedCommand` (limited) and `RoutedUICommand` (limited).
- Operations: execute, revert
- Usability management
- `RoutedUICommand` can bind to common controls:
  - `Button`, `CheckBox`, `RadioButton`
  - `MenuItem`
  - `ToolStripButton`, `ToolStripSplitButton`, `ToolStripOverflowButton`
  - `ToolStripMenuItem`

## Example

There is example can be found at [Form1.cs](src/Example/Form1.cs). Here is a glance of a part of it:

```csharp
private void InitializeCommands() {
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
}

private readonly ICommand _command1 = new RoutedUICommand("Ctrl+1");
private bool _command1Enabled = true;
```

## License 

MIT
