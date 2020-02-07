using System.ComponentModel.Composition;
using System.Windows;
using SimplePlugin.Applications.Views;

namespace WafApp.Presentation.Views
{
    [Export(typeof(IPluginView))]
    public partial class PluginWindow : Window, IPluginView
    {
        public PluginWindow()
        {
            InitializeComponent();
        }
    }
}
