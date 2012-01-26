using System;

namespace DoodleReportTest
{
    public class Product
    {
        protected internal Product()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int OrderCount { get; set; }
        public DateTime LastPurchase { get; set; }
        public int UnitsInStock { get; set; }
    }
}