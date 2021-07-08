using System;
using System.Collections.Generic;

namespace InterviewProject.Code_Challenge
{
    public class Challenge1
    {
        public static string[] Courses = new string[]{"Maths","History","Geography"};
        public static List<Student> GetStudentData(int numberOfRows)
        {
            List<Student> data = new List<Student>();

            for(int i =0; i< numberOfRows; i++)
            {
                Random random = new Random();

                Student s = new Student(){
                    Name = Faker.Name.First(),
                    Surname = Faker.Name.Last(),
                    Age = random.Next(13,19),
                    Course = Courses[random.Next(0,2)]
                };

                data.Add(s);
            }

            return data;
        }
    }

    public class Student
    {
        public string Name {get;set;}
        public string Surname {get;set;}
        public int Age {get;set;}
        public string Course {get;set;}
    }

   
}