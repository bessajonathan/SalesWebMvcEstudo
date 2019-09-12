using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.ViewModels
{
    public class DepartmentsViewModel
    {
        public List<Department> Departments { get; set; }
        public Seller Seller { get; set; }
    }
}
