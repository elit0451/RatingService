namespace Collector
{
    public enum AgeGroup 
    {
        Youth,
        Adulthood,
        Seniority,
        None
    }

    public enum Gender
    {
        Male,
        Female,
        None
    }
    public class Questionnaire
    {
        public int Grade { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public AgeGroup AgeGr { get; set; }

        public Questionnaire(int grade, string desc, string country, Gender gender, AgeGroup ageGroup)
        {
            Grade = grade;
            Description = desc;
            Country = country;
            Gender = gender;
            AgeGr = ageGroup;
        }

        public override string ToString()
        {
            return Grade 
                    + ", " + Description
                    + ", " + Country
                    + ", " + Gender
                    + ", " + AgeGr;
        }
    }
}