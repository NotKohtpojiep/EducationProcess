using System.Windows;
using System.Windows.Media.Imaging;

namespace EducationProcess.HandyDesktop.UserControls
{
    public partial class LessonCell
    {
        public LessonCell()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty NoteProperty = DependencyProperty.Register(
            "Note", typeof(string), typeof(LessonCell), new PropertyMetadata(default(string)));

        public string Note
        {
            get => (string) GetValue(NoteProperty);
            set => SetValue(NoteProperty, value);
        }

        public static readonly DependencyProperty DisciplineProperty = DependencyProperty.Register(
            "Discipline", typeof(string), typeof(LessonCell), new PropertyMetadata(default(string)));

        public string Discipline
        {
            get => (string) GetValue(DisciplineProperty);
            set => SetValue(DisciplineProperty, value);
        }

        public static readonly DependencyProperty FixedForProperty = DependencyProperty.Register(
            "FixedFor", typeof(string), typeof(LessonCell), new PropertyMetadata(default(string)));

        public string FixedFor
        {
            get => (string) GetValue(FixedForProperty);
            set => SetValue(FixedForProperty, value);
        }

        public static readonly DependencyProperty AudienceProperty = DependencyProperty.Register(
            "Audience", typeof(string), typeof(LessonCell), new PropertyMetadata(default(string)));

        public string Audience
        {
            get => (string) GetValue(AudienceProperty);
            set => SetValue(AudienceProperty, value);
        }
    }
}
