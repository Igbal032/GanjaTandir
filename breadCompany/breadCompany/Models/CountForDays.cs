//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace breadCompany.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CountForDays
    {
        public int Id { get; set; }
        public int SubsidiaryId { get; set; }
        public int MonthId { get; set; }
        public Nullable<int> Year { get; set; }
        public string MarketName { get; set; }
        public Nullable<int> Day1 { get; set; }
        public Nullable<int> Day2 { get; set; }
        public Nullable<int> Day3 { get; set; }
        public Nullable<int> Day4 { get; set; }
        public Nullable<int> Day5 { get; set; }
        public Nullable<int> Day6 { get; set; }
        public Nullable<int> Day7 { get; set; }
        public Nullable<int> Day8 { get; set; }
        public Nullable<int> Day9 { get; set; }
        public Nullable<int> Day10 { get; set; }
        public Nullable<int> Day11 { get; set; }
        public Nullable<int> Day12 { get; set; }
        public Nullable<int> Day13 { get; set; }
        public Nullable<int> Day14 { get; set; }
        public Nullable<int> Day15 { get; set; }
        public Nullable<int> Day16 { get; set; }
        public Nullable<int> Day17 { get; set; }
        public Nullable<int> Day18 { get; set; }
        public Nullable<int> Day19 { get; set; }
        public Nullable<int> Day20 { get; set; }
        public Nullable<int> Day21 { get; set; }
        public Nullable<int> Day22 { get; set; }
        public Nullable<int> Day23 { get; set; }
        public Nullable<int> Day24 { get; set; }
        public Nullable<int> Day25 { get; set; }
        public Nullable<int> Day26 { get; set; }
        public Nullable<int> Day27 { get; set; }
        public Nullable<int> Day28 { get; set; }
        public Nullable<int> Day29 { get; set; }
        public Nullable<int> Day30 { get; set; }
        public Nullable<int> Day31 { get; set; }
        public Nullable<double> PriceOfOne { get; set; }
        public Nullable<int> TotalCount { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<decimal> SumInOneMonth { get; set; }
    
        public virtual Months Months { get; set; }
        public virtual Subsidiary Subsidiary { get; set; }
    }
}
