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
            HeadSideMenuModel educationPlanHeadModel = new HeadSideMenuModel()
            {
                Name = "EducationPlan",
                ImgPath = "",
                IsNew = false
            };

            HeadSideMenuModel disciplineHeadModel = new HeadSideMenuModel()
            {
                Name = "Disciplines",
                ImgPath = "",
                IsNew = false
            };

            HeadSideMenuModel lessonHeadModel = new HeadSideMenuModel()
            {
                Name = "Lessons",
                ImgPath = "",
                IsNew = false
            };

            // Руководитель УМО
            List<SideMenuModel> umoHeadViewCollection = new List<SideMenuModel>()
            {
                new SideMenuModel()
                {
                    ImgPath = "",
                    Name = "EducationPlanMenu",
                    TargetCtlName = "EducationPlanMainCtl",
                    IsVisible = true,
                    HeadSideMenu = educationPlanHeadModel
                },
                new SideMenuModel()
                {
                    ImgPath = "",
                    Name = "DisciplinesMenu",
                    TargetCtlName = "DisciplinesMenuView",
                    IsVisible = true,
                    HeadSideMenu = disciplineHeadModel
                },
                new SideMenuModel()
                {
                    ImgPath = "",
                    Name = "FixingDisciplineMenu",
                    TargetCtlName = "ChainDisciplineView",
                    IsVisible = true,
                    HeadSideMenu = disciplineHeadModel
                }
            };

            // Преподаватель
            List<SideMenuModel> teacherViewCollection = new List<SideMenuModel>()
            {
                new SideMenuModel()
                {
                    ImgPath = "",
                    Name = "SuggestionDisciplineMenu",
                    TargetCtlName = "CheckDisciplineSuggestionView",
                    IsVisible = true,
                    HeadSideMenu = disciplineHeadModel
                },
                new SideMenuModel()
                {
                    ImgPath = "",
                    Name = "ConfirmLesson",
                    TargetCtlName = "ConfirmLessonView",
                    IsVisible = true,
                    HeadSideMenu = lessonHeadModel
                },
                new SideMenuModel()
                {
                    ImgPath = "",
                    Name = "MySchedule",
                    TargetCtlName = "TeacherScheduleView",
                    IsVisible = true,
                    HeadSideMenu = lessonHeadModel
                },
                
            };

            return teacherViewCollection;
        }
    }
}
