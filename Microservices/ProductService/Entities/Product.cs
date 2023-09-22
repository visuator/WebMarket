﻿namespace ProductService.Entities
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}