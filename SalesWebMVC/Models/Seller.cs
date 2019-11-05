using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime birthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "${0:F2}")]
        public double baseSalary { get; set; }

        [Display(Name = "Department")]
        public Department department { get; set; }

        [Display(Name = "Department")]
        public int departmentid { get; set; }
        public ICollection<SalesRecord> sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.birthDate = birthDate;
            this.baseSalary = baseSalary;
            this.department = department;
        }


        public void AddSales(SalesRecord sr)
        {
            sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return sales.Where(sr => sr.date >= initial && sr.date <= final).Sum(sr => sr.amount);
        }
    }
}
