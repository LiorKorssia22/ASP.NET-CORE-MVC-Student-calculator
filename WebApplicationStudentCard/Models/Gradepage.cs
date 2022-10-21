namespace WebApplicationStudentCard.Models
{
    public class Gradepage
    {
        //Professions
        public int Math { get; set; }
        public int English { get; set; }
        public int History { get; set; }
        public int Civics { get; set; }
        public int Literature { get; set; }

        //Psychometric adjustment scores + grade point average
        public int Avgtotal { get; set; }
        public int Psychometric { get; set; }
        public int Totalscore { get; set; }
        public string? Study { get; set; }


        //Score calculations - low, high, average
        public int Total { get; set; }
        public int Avg { get; set; }
        public string? Grade { get; set; }
        public int Lowest { get; set; }
        public int Highest { get; set; }
    }
}
