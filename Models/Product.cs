﻿namespace Task1mvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public string Image {  get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
