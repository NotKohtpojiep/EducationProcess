namespace EducationProcess.ApiClient.Models.FixedDisciplines.Requests
{
    public class FixedDisciplineRequest
    {
        public int FixedDisciplineId { get; set; }
        public int FixingEmployeeId { get; set; }
        public int SemesterDisciplineId { get; set; }
        public int GroupId { get; set; }
        public bool? IsAgreed { get; set; }
        public bool? IsWatched { get; set; }
        public int FixerEmployeeId { get; set; }
        public string CommentByFixingEmployee { get; set; }
        public string CommentByFixerEmployee { get; set; }
    }
}