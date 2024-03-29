﻿using SalesWebMvc.Models;
using System.Collections.Generic;

namespace SalesWebMvc.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
