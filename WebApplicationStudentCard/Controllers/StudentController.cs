using Microsoft.AspNetCore.Mvc;
using WebApplicationStudentCard.Models;

namespace WebApplicationStudentCard.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(new Gradepage());
        }

        [HttpPost]
        public IActionResult Index(Gradepage gradepage)
        {
           //Score calculations - low, high, average
            var listlow = new[] { gradepage.Math, gradepage.English, gradepage.History, gradepage.Civics, gradepage.Literature };
            int min = listlow.Min();

            var listhigh = new[] { gradepage.Math, gradepage.English, gradepage.History, gradepage.Civics, gradepage.Literature };
            int max = listhigh.Max();

            gradepage.Total = gradepage.Math + gradepage.English + gradepage.History + gradepage.Civics + gradepage.Literature;
            gradepage.Avg = gradepage.Total / 5;

            gradepage.Lowest = min;
            gradepage.Highest = max;

            if (gradepage.Avg >= 65)
			{
                gradepage.Grade = "pass";
            }
			else
			{
                gradepage.Grade = "fail";
            }
            
           //Psychometric adjustment scores + grade point average
            gradepage.Avgtotal = (int)(gradepage.Avg * 9.39 - 324.36);

            gradepage.Totalscore = (int)((gradepage.Avgtotal + gradepage.Psychometric) * 0.52 -43.19);

            if (gradepage.Totalscore >= 450 && gradepage.Totalscore <= 549)
            {
                gradepage.Study = "Cinema, Middle East, communication, political science.";
            }
            else if (gradepage.Totalscore >= 550 && gradepage.Totalscore <= 649)
            {
                gradepage.Study = "Mathematics, chemistry, biology, physical therapy, mechanical engineering";
            }
            else if (gradepage.Totalscore >= 650 && gradepage.Totalscore <= 800)
            {
                gradepage.Study = "Physics, psychology, industrial engineering and management, biomedical engineering, dentistry, computer science, computer engineering.";
            }
            else if (gradepage.Totalscore <= 449)
            {
                gradepage.Study = "The lowest matching score is 450, you must improve until you reach this score, good luck! :)";
            }
            else
            {
                gradepage.Study = "Error! wrong input";
            }

            return View(gradepage);
        }
    }
}
