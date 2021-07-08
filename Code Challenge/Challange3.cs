using System;
using System.Collections.Generic;

namespace InterviewProject.Code_Challenge
{
    public class Challange3
    {
        public static int[] GenerateArray(int upperLimit)
        {
            Random random = new Random();
            int entries = random.Next(upperLimit);

            List<int> items = new List<int>();
            for(int i =0; i < entries; i++)
            {
                items.Add(random.Next(1000));
            }

            return items.ToArray();
        }
    }
}