using System;
using System.Data;

namespace InterviewProject.Code_Challenge
{
    public class Challenge2
    {
        private static string[] TransactionType =  {"Credit", "Debit"};
        public static DataTable GetTransactionsTable(int transactions)
        {
            DataTable table = new DataTable();
            string[] columns = new string[]{"Date","Time","Amount","Transaction Type"};

            foreach(string column in columns)
            {
                table.Columns.Add(column);
            }

            for(int i =0; i < transactions; i ++)
            {
                Random random = new Random();
                DateTime date = RandomDay();

                DataRow row = table.NewRow();
                row[columns[0]] = date.Date;
                row[columns[1]] = date.TimeOfDay;
                row[columns[2]] = random.Next(10000);
                row[columns[3]] = TransactionType[random.Next(0, TransactionType.Length-1)];

                table.Rows.Add(row);
            }
            

            return table;
        }

        public void GenerateData()
        {

        }

        private static DateTime RandomDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;           
            start = start.AddDays(gen.Next(range));
            start = start.AddMinutes(gen.Next(241));
            return start;
        }
    }
}