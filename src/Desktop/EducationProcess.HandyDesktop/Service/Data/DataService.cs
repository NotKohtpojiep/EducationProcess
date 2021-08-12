using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using EducationProcess.HandyDesktop.Data;
using Newtonsoft.Json;

namespace EducationProcess.HandyDesktop.Service
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

        internal List<HeadSideMenuModel> GetDemoInfo(string title)
        {
            HeadSideMenuModel model1 = new HeadSideMenuModel()
            {
                Name = "Model1",
                ImgPath = "",
                IsNew = true,
                SideMenuList = new List<SideMenuModel>()
            };

            HeadSideMenuModel model2 = new HeadSideMenuModel()
            {
                Name = "Model2",
                ImgPath = "",
                IsNew = false,
                SideMenuList = new List<SideMenuModel>()
            };
            return new List<HeadSideMenuModel> { model1, model2 };
        }
    }
}
