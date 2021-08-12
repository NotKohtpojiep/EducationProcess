using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using HandyControl.Tools;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Tools;
using EducationProcess.HandyDesktop.UserControl;
using EducationProcess.HandyDesktop.ViewModel;

namespace EducationProcess.HandyDesktop
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            DataContext = ViewModelLocator.Instance.Main;
            NonClientAreaContent = new NonClientAreaContent();
            ControlMain.Content = new MainWindowContent();

            GlobalShortcut.Init(new List<KeyBinding>
            {
                new(ViewModelLocator.Instance.Main.GlobalShortcutInfoCmd, Key.I, ModifierKeys.Control | ModifierKeys.Alt),
                new(ViewModelLocator.Instance.Main.GlobalShortcutWarningCmd, Key.E, ModifierKeys.Control | ModifierKeys.Alt)
            });

            Dialog.SetToken(this, MessageToken.MainWindow);
            WindowAttach.SetIgnoreAltF4(this, true);

            Messenger.Default.Send(AssemblyHelper.CreateInternalInstance($"UserControl.{MessageToken.ContributorsView}"), MessageToken.LoadShowContent);
        }
    }
}
