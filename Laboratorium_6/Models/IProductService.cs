using Laboratorium_6.Models;
using System.Collections.Generic;

public interface IProductService
{
    void AddProduct(ProductModel model);
    void UpdateProduct(ProductModel updatedProduct);
    void DeleteProduct(int productId);
    IEnumerable<ProductModel> GetAllProducts();
    ProductModel? GetProductById(int productId);
}