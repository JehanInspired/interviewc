using System.Collections.Generic;
using System.Data;
using System.Linq;
using InterviewProject.Code_Challenge;
using NUnit.Framework;

namespace InterviewProject
{
    public class Tests
    {        
        [Test]
        public void Challenge1Test()
        {
            List<Student> students = Challenge1.GetStudentData(1000);

            //Output a list of the students that are over 14 years old      

            //Output a list of students who are enrolled in Maths

            //Output a list of students names who are enrolled in History and are 18 ye ars old        
            
        }

        [Test]
        public void Challenge2Test()
        {
            DataTable transActionsTable = Challenge2.GetTransactionsTable(1000);

            //Output a list of Transactions completed today

            //Output a list of Transactions with an amount over 5000

            //Create a new Object type with the following properties and then output a list of these items
            //Date, Time, Amount, Transaction Type
        }

        [Test]
        public void Challenge3Test()
        {
            int[] intArray = Challange3.GenerateArray(10);

            //Add the items in the array together and output the result
        }
    }
}