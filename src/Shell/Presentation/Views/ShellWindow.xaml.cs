﻿using System.ComponentModel.Composition;
using System.Windows;
using Shell.Applications.Views;

namespace Shell.Presentation.Views
{
    [Export(typeof(IShellView))]
    public partial class ShellWindow : Window, IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }
    }
}
