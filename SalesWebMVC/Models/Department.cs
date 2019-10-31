using System;
using SalesWebMVC.Models;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Seller> sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void AddSeller(Seller seller)
        {
            sellers.Add(seller);
        }

        public double TotalSales(DateTime initial,DateTime final)
        {
            return sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
