using System;
using System.Windows.Controls;

namespace PersonalPro
{
    /// <summary>
    /// Interaction logic for SwitchView.xaml
    /// </summary>
    public partial class SwitchView : UserControl
    {
        public SwitchView()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }
        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }
    }

    public static class Switcher
    {
        public static SwitchView pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }

    public interface ISwitchable
    {
        void UtilizeState(object state);
    }
}
