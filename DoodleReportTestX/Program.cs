using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DoodleReportTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the data for the report (any IEnumerable or LINQ query will work)
            
            ProductRepository.ReportData();

            Console.ReadLine();
        }



    }        

}
