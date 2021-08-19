using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using EducationProcess.HandyDesktop.Data;
using Newtonsoft.Json;

namespace EducationProcess.HandyDesktop.Services
{
    public class DataService
    {
        internal List<AvatarModel> GetContributorDataList()
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", "request");
            var list = new List<AvatarModel>();
            try
            {
                var json = client.DownloadString(new Uri("https://api.github.com/repos/NotKohtpojiep/EducationProcess/contributors"));
                var objList = JsonConvert.DeserializeObject<List<dynamic>>(json);
                list.AddRange(objList.Select(item => new AvatarModel
                {
                    DisplayName = item.login,
                    AvatarUri = item.avatar_url,
                    Link = item.html_url
                }));
            }
            catch (Exception e)
            {
                HandyControl.Controls.MessageBox.Error(e.Message, "Error");
            }

            return list;
        }

        internal List<SideMenuModel> GetDemoInfo(string title)
        {
            HeadSideMenuModel model1 = new HeadSideMenuModel()
            {
                Name = "EducationPlan",
                ImgPath = "",
                IsNew = true,
            };

            HeadSideMenuModel model2 = new HeadSideMenuModel()
            {
                Name = "Disciplines",
                ImgPath = "",
                IsNew = false,
            };


            List<SideMenuModel> sideMenuModels = new List<SideMenuModel>()
            {
                new SideMenuModel()
                {
                    ImgPath = "",
                    Name = "EducationPlanMenu",
                    TargetCtlName = "EducationPlanMainCtl",
                    IsVisible = true,
                    HeadSideMenu = model1
                },
                new SideMenuModel()
                {
                    ImgPath = "",
                    Name = "DisciplinesMenu",
                    TargetCtlName = "DisciplinesMenuView",
                    IsVisible = true,
                    HeadSideMenu = model2
                },
                new SideMenuModel()
                {
                    ImgPath = "",
                    Name = "FixingDisciplineMenu",
                    TargetCtlName = "ChainDisciplineView",
                    IsVisible = true,
                    HeadSideMenu = model2
                }
            };

            return sideMenuModels;
        }
    }
}
