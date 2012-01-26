using System;
using System.Collections.Generic;
using System.Linq;
using DoddleReport;
using DoddleReport.Writers;

namespace DoodleReportTest
{
    public static class ProductRepository
    {
        public static List<Product> GetAll()
        {
            var rand = new Random();
            return Enumerable.Range(1, 1000)
                             .Select(i => new Product
                             {
                                 Id = i,
                                 Name = "Product " + i,
                                 Description = "This is an example description showing long text in some of the items, now I am just rambling",
                                 Price = rand.NextDouble() * 100,
                                 OrderCount = rand.Next(1000),
                                 LastPurchase = DateTime.Now.AddDays(rand.Next(1000)),
                                 UnitsInStock = rand.Next(0, 2000)
                             })
                             .ToList();
        }

        public static void ReportData()
        {
            int totalProducts = 0;
            int totalOrders = 0;

            // Get the data for the report (any IEnumerable or LINQ query will work)
            var query = ProductRepository.GetAll();

            // Create the report and turn our query into a ReportSource
            var report = new Report(query.ToReportSource());

            // Customize the Text Fields
            report.TextFields.Title = "Products Report";
            report.TextFields.SubTitle = "This is a sample report showing how Doddle Report works";
            report.TextFields.Footer = "Copyright 2011 &copy; The Doddle Project";
            report.TextFields.Header = string.Format(@"
                Report Generated: {0}
                Total Products: {1}
                Total Orders: {2}
                Total Sales: {3:c}", DateTime.Now, totalProducts, totalOrders, totalProducts * totalOrders);

            // Render hints allow you to pass additional hints to the reports as they are being rendered
            report.RenderHints.BooleanCheckboxes = true;

            // Customize the data fields
            report.DataFields["Id"].Hidden = true;
            report.DataFields["Price"].DataFormatString = "{0:c}";
            report.DataFields["LastPurchase"].DataFormatString = "{0:d}";

            //  Write now!
            var writer = new HtmlReportWriter();
            writer.WriteReport(report, HttpContext.Response.OutputStream);
        }
    }
}