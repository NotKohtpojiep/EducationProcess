using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using HandyControl.Tools;

namespace EducationProcess.HandyDesktop.Properties.Langs
{
    public class LangProvider : INotifyPropertyChanged
    {
        internal static LangProvider Instance { get; } = ResourceHelper.GetResource<LangProvider>("Lang");

        private static string _cultureInfoStr;

        public static CultureInfo Culture
        {
            get => Lang.Culture;
            set
            {
                if (value == null) return;
                if (Equals(_cultureInfoStr, value.EnglishName)) return;
                Lang.Culture = value;
                _cultureInfoStr = value.EnglishName;

                Instance.UpdateLangs();
            }
        }

        public static string GetLang(string key) => Lang.ResourceManager.GetString(key, Culture);

        public static void SetLang(DependencyObject dependencyObject, DependencyProperty dependencyProperty, string key) =>
            BindingOperations.SetBinding(dependencyObject, dependencyProperty, new Binding(key)
            {
                Source = Instance,
                Mode = BindingMode.OneWay
            });

        private void UpdateLangs()
        {
            OnPropertyChanged(nameof(About));
            OnPropertyChanged(nameof(Contributors));
            OnPropertyChanged(nameof(EducationPlan));
            OnPropertyChanged(nameof(Other));
            OnPropertyChanged(nameof(EducationPlanMenu));
            OnPropertyChanged(nameof(EducationPlanDisciplineMenu));
            OnPropertyChanged(nameof(Menu));
            OnPropertyChanged(nameof(DisciplinesMenu));
            OnPropertyChanged(nameof(Disciplines));
            OnPropertyChanged(nameof(Discipline));
            OnPropertyChanged(nameof(FixingDisciplineMenu));
            OnPropertyChanged(nameof(SuggestionDisciplineMenu));
            
        }
        public string About => Lang.About;
        public string Contributors => Lang.Contributors;
        public string EducationPlan => Lang.EducationPlan;
        public string Other => Lang.Other;
        public string EducationPlanMenu => Lang.EducationPlanMenu;
        public string EducationPlanDisciplineMenu => Lang.EducationPlanDisciplineMenu;
        public string Menu => Lang.Menu;
        public string DisciplinesMenu => Lang.DisciplinesMenu;
        public string Disciplines => Lang.Disciplines;
        public string Discipline => Lang.Discipline;
        public string FixingDisciplineMenu => Lang.FixingDisciplineMenu;
        public string SuggestionDisciplineMenu => Lang.SuggestionDisciplineMenu;


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class LangKeys
    {
        public static string About = nameof(About);
        public static string Contributors = nameof(Contributors);
        public static string EducationPlan = nameof(EducationPlan);
        public static string Other = nameof(Other);
        public static string EducationPlanMenu = nameof(EducationPlanMenu);
        public static string EducationPlanDisciplineMenu = nameof(EducationPlanDisciplineMenu);
        public static string Menu = nameof(Menu);
        public static string DisciplinesMenu = nameof(DisciplinesMenu);
        public static string Disciplines = nameof(Disciplines);
        public static string Discipline = nameof(Discipline);
        public static string FixingDisciplineMenu => nameof(FixingDisciplineMenu);
        public static string SuggestionDisciplineMenu => nameof(SuggestionDisciplineMenu);
    }
}
