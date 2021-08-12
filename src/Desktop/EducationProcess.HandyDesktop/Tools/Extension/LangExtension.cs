using EducationProcess.HandyDesktop.Properties.Langs;

namespace EducationProcess.HandyDesktop.Tools.Extension
{
    public class LangExtension : HandyControl.Tools.Extension.LangExtension
    {
        public LangExtension()
        {
            Source = LangProvider.Instance;
        }
    }
}
