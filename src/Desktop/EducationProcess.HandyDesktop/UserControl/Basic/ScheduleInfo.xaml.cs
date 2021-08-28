using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;
using EducationProcess.HandyDesktop.Data.Models;

namespace EducationProcess.HandyDesktop.UserControl
{
    public partial class ScheduleInfo
    {
        public ScheduleInfo()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ScheduleInfoCollectionProperty = DependencyProperty.Register(
            "ScheduleInfoCollection", typeof(ObservableCollection<ScheduleForDayModel>), typeof(ScheduleInfo), new PropertyMetadata(default(ObservableCollection<ScheduleForDayModel>)));

        public ObservableCollection<ScheduleForDayModel> ScheduleInfoCollection
        {
            get => (ObservableCollection<ScheduleForDayModel>) GetValue(ScheduleInfoCollectionProperty);
            set => SetValue(ScheduleInfoCollectionProperty, value);
        }
    }
}
