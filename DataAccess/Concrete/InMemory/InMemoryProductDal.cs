using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{
                    ProductId=1, 
                    CategoryId=1,
                    ProductName="Bardak",
                    UnitPrice=15,
                    UnitInStock=15 },
                new Product{
                    ProductId=2,
                    CategoryId=1,
                    ProductName="Kamera",
                    UnitPrice=500,
                    UnitInStock=3 },
                new Product{
                    ProductId=3,
                    CategoryId=2,
                    ProductName="Telefon",
                    UnitPrice=1500,
                    UnitInStock=2},
                new Product{
                    ProductId=4,
                    CategoryId=2,
                    ProductName="Klavye",
                    UnitPrice=150,
                    UnitInStock=65},
                new Product{
                    ProductId=5,
                    CategoryId=2,
                    ProductName="Fare",
                    UnitPrice=1,
                    UnitInStock=85},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /*Product productToDelete;
            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }*/
            //Linq ile daha basit bir şekilde foreach ve içerisinde yaptığımızı brada yapabiliyoruz.
            //Her p için pnin IDsi, paametre ile gönderdiğim ID ile eşitse, birbirine eşitle.
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün ID sine sahip olan listedeli ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
