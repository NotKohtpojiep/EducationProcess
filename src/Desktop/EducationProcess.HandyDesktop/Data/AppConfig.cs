using System;
using HandyControl.Data;

namespace EducationProcess.HandyDesktop.Data
{
    internal class AppConfig
    {
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}AppConfig.json";

        public string Lang { get; set; } = "ru";

        public SkinType Skin { get; set; }
    }
}
