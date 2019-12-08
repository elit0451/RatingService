using System;

namespace Collector
{
    public static class DataNormalizer
    {
        public static Questionnaire Normalize(int grade, string desc, string country, string gender, int age)
        {
            Gender g;
            AgeGroup ageGroup;

            if (grade > 10)
                grade = 10;
            else if (grade < 0)
                grade = 0;

            if (country.Length > 2)
                country = country.Substring(0, 1).ToUpper() + country.Substring(1).ToLower();

            if (gender.ToUpper() == "MALE" || gender.ToUpper() == "M")
                g = Gender.Male;
            else if (gender.ToUpper() == "FEMALE" || gender.ToUpper() == "F")
                g = Gender.Female;
            else
                g = Gender.None;

            if (age < 18)
                ageGroup = AgeGroup.None;
            else if (age >= 18 && age <= 24)
                ageGroup = AgeGroup.Youth;
            else if (age >= 25 && age <= 64)
                ageGroup = AgeGroup.Adulthood;
            else
                ageGroup = AgeGroup.Seniority;

            Questionnaire questionnaire = new Questionnaire(grade, desc, country, g, ageGroup);
            return questionnaire;
        }
    }
}