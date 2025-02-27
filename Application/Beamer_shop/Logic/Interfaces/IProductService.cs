﻿using Logic.Models;

namespace Logic.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        List<Product> GetProductAccessories(Product product);
        Product? getProductById(int id);
        List<string> GetProductImages(Product product);
        bool CreateProduct(Product product);
        bool DeleteProduct(Product product);
    }
}