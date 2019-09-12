﻿using SalesWebMvc.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SalesStatus Satus { get; set; }

        [Required]
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus satus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Satus = satus;
            Seller = seller;
        }
    }
}
