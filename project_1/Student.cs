using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public enum Gender { male, female, other };
    public enum UniversityCourse { first, second, third, fourth };
    public class Student
    {
        string passNumber;
        string firstName;
        string lastName;
        int age;
        string groupName;
        DateTime doi;
        bool scholarship;
        Gender sex;
        UniversityCourse course;
        string imagePath;

        public Student()
        {

        }

        public string PassNumber { get => passNumber; set => passNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public DateTime Doi { get => doi; set => doi = value; }
        public bool Scholarship { get => scholarship; set => scholarship = value; }
        public Gender Sex { get => sex; set => sex = value; }
        public UniversityCourse Course { get => course; set => course = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }

        public override string ToString()
        {
            return $"№{PassNumber} {FirstName} {LastName}, Sex {Sex} Age {Age}, Group {GroupName}, DOI {Doi}, {(Scholarship? "have scholarship" : "do not have scholarship")}," +
                $"UniversityCourse {Course} \n {ImagePath}";
        }
    }
}
