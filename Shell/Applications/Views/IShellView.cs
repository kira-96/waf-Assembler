using System.Waf.Applications;

namespace Shell.Applications.Views
{
    internal interface IShellView : IView
    {
        void Show();

        void Close();
    }
}
