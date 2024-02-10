using Laboratorium_4.Models;
using System.Collections.Generic;

public interface IProductService
{
    IEnumerable<ProductModel> GetAllProducts();
    ProductModel GetProductById(int productId);
    void AddProduct(ProductModel model);
    void UpdateProduct(int productId, ProductModel updatedProduct);
    void DeleteProduct(int productId);
}