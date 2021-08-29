using System;
using System.Windows.Data;
using System.Windows.Threading;

namespace EducationProcess.HandyDesktop.UserControls
{
    public partial class LeftMainContent
    {
        public LeftMainContent()
        {
            InitializeComponent();

            Dispatcher.BeginInvoke(new Action(() =>
            {
                ListBoxDemo.Items.GroupDescriptions?.Add(new PropertyGroupDescription("HeadSideMenu.Name"));
            }), DispatcherPriority.Background);
        }
    }
}
