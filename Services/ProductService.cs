using AppMVC.Models;

namespace AppMVC.Services
{
    public class ProductService: List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]{
                new ProductModel() {Id = 1, Name ="Iphone X", Price =1000},
                new ProductModel() {Id = 2, Name ="Iphone Xs", Price =1000},
                new ProductModel() {Id = 3, Name ="Iphone Xs Max", Price =1000}
            });
        }
    }
}