﻿using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Windows.Input;
using Shell.Applications.Views;

namespace Shell.Applications.ViewModels
{
    [Export]
    internal class ShellViewModel : ViewModel<IShellView>
    {
        private readonly DelegateCommand exitCommand;


        [ImportingConstructor]
        public ShellViewModel(IShellView view)
            : base(view)
        {
            exitCommand = new DelegateCommand(Close);
        }


        public string Title { get; } = ApplicationInfo.ProductName;

        public ICommand ExitCommand => exitCommand;


        public void Show()
        {
            ViewCore.Show();
        }

        private void Close()
        {
            ViewCore.Close();
        }
    }
}
