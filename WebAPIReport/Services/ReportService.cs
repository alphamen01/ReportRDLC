using AspNetCore.Reporting;
using ReportDatos.Dtos;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WebAPIReport.Services
{
    public interface IReportService
    {
        byte[] GenerateReportAsync(string reportName, string reportType);
    }

    public class ReportService : IReportService
    {
        public byte[] GenerateReportAsync(string reportName, string reportType)
        {
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("WebAPIReport.dll",string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcFilePath);

            /*
            List<UserDto> userList = new List<UserDto>();

            var user1 = new UserDto { FirstName = "jp", LastName = "kkk", Email = "lesg.2233@gmail.com", Phone = "999000111" };
            var user2 = new UserDto { FirstName = "ja", LastName = "kkk", Email = "lesg.2233@gmail.com", Phone = "999000111" };
            var user3 = new UserDto { FirstName = "js", LastName = "kkk", Email = "lesg.2233@gmail.com", Phone = "999000111" };
            var user4 = new UserDto { FirstName = "jd", LastName = "kkk", Email = "lesg.2233@gmail.com", Phone = "999000111" };
            var user5 = new UserDto { FirstName = "jf", LastName = "kkk", Email = "lesg.2233@gmail.com", Phone = "999000111" };

            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);
            userList.Add(user4);
            userList.Add(user5);

            report.AddDataSource("dsUsers", userList);*/

            List<CourseDto> courses = new List<CourseDto>();

            var course1 = new CourseDto { Id = 1, Name = "C#", Description = "Programacion", Teacher = "Luis Sanchez", Uri = "https://www.youtube.com/watch?v=893q_oMLM2I" };
            var course2 = new CourseDto { Id = 2, Name = "GO", Description = "Programacion", Teacher = "Luis Sanchez", Uri = "https://www.youtube.com/watch?v=893q_oMLM2I" };
            var course3 = new CourseDto { Id = 3, Name = "F#", Description = "Programacion", Teacher = "Luis Sanchez", Uri = "https://www.youtube.com/watch?v=893q_oMLM2I" };
            var course4 = new CourseDto { Id = 4, Name = "C++", Description = "Programacion", Teacher = "Luis Sanchez", Uri = "https://www.youtube.com/watch?v=893q_oMLM2I" };
            var course5 = new CourseDto { Id = 5, Name = "JAVA", Description = "Programacion", Teacher = "Luis Sanchez", Uri = "https://www.youtube.com/watch?v=893q_oMLM2I" };
            var course6 = new CourseDto { Id = 6, Name = "PHP", Description = "Programacion", Teacher = "Luis Sanchez", Uri = "https://www.youtube.com/watch?v=893q_oMLM2I" };

            courses.Add(course1);
            courses.Add(course2);
            courses.Add(course3);
            courses.Add(course4);
            courses.Add(course5);
            courses.Add(course6);

            report.AddDataSource("dsCourse", courses);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var result = report.Execute(GetRenderType(reportType), 1, parameters);

            return result.MainStream;

        }

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;

            switch (reportType.ToUpper())
            {
                default:
                case "PDF": renderType = RenderType.Pdf;
                    break;
                case "XLS": renderType = RenderType.Excel;
                    break;
                case "WORD": renderType = RenderType.Word;
                    break;

            }
            return renderType;
        }
    }
}
