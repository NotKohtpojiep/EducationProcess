using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime;
using System.Windows;
using HandyControl.Data;
using HandyControl.Tools;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Properties.Langs;

namespace EducationProcess.HandyDesktop
{
    public partial class App
    {
        public App()
        {
            var cachePath = $"{AppDomain.CurrentDomain.BaseDirectory}Cache";
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
            ProfileOptimization.SetProfileRoot(cachePath);
            ProfileOptimization.StartProfile("Profile");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShutdownMode = ShutdownMode.OnMainWindowClose;
            GlobalData.Init();
            ConfigHelper.Instance.SetLang(GlobalData.Config.Lang);
            LangProvider.Culture = new CultureInfo(GlobalData.Config.Lang);

            if (GlobalData.Config.Skin != SkinType.Default)
            {
                UpdateSkin(GlobalData.Config.Skin);
            }

            ConfigHelper.Instance.SetWindowDefaultStyle();
            ConfigHelper.Instance.SetNavigationWindowDefaultStyle();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            GlobalData.Save();
        }

        internal void UpdateSkin(SkinType skin)
        {
            var skins0 = Resources.MergedDictionaries[0];
            skins0.MergedDictionaries.Clear();
            skins0.MergedDictionaries.Add(ResourceHelper.GetSkin(skin));
            skins0.MergedDictionaries.Add(ResourceHelper.GetSkin(typeof(App).Assembly, "Resources/Themes", skin));

            var skins1 = Resources.MergedDictionaries[1];
            skins1.MergedDictionaries.Clear();
            skins1.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/HandyControl;component/Themes/Theme.xaml")
            });
            skins1.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/EducationProcess.HandyDesktop;component/Resources/Themes/Theme.xaml")
            });

            Current.MainWindow?.OnApplyTemplate();
        }
    }
}
