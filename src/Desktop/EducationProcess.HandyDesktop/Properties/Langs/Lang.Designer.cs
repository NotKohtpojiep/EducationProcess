using System.Globalization;
using System.Resources;

namespace EducationProcess.HandyDesktop.Properties.Langs
{
    public class Lang
    {
        private static ResourceManager _resourceMan;
        private static CultureInfo _resourceCulture;

        internal Lang() { }

        public static ResourceManager ResourceManager
        {
            get
            {
                if (_resourceMan is null)
                {
                    var temp = new ResourceManager("EducationProcess.HandyDesktop.Properties.Langs.Lang", typeof(Lang).Assembly);
                    _resourceMan = temp;
                }
                return _resourceMan;
            }
        }

        public static CultureInfo Culture
        {
            get => _resourceCulture;
            set => _resourceCulture = value;
        }

        public static string About => ResourceManager.GetString(nameof(About), _resourceCulture);
    }
}
