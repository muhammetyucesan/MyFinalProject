using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal //abstract dosyasında yaptığımız internali buraya(yani classa yani concrete deki classa) ekliyoruz ve sonra implement ediyoruz ampulden.  
    {
        List<Product> _products;
        public InMemoryProductDal() //ctor yazup tabtab yaptık constructor oluşturduk.
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 1 ,ProductName="Bardak", UnitPrice= 15 , UnitsInStock = 15 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 } ,
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Bardak",UnitPrice = 15, UnitsInStock = 15 }
            };

        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //       Product productToDelete = null; //referansı yok diye eşit null dedik. = new ... yapmıyoruz yani referans atamaya gerek yok tekrar
            //       foreach (var p in _products)
            //       {
            //           if(product.ProductId == p.ProductId)
            //       {
            //       productToDelete = p;
            //   }

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);  // p takma isim. bu kod yukardaki foreach ve if kısımlarını yapıyor direkt. Kodu basitleştirdik.
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün id sine sahip olan listedeki ürünü bul demek.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);  // p takma isim. bu kod yukardaki foreach ve if kısımlarını yapıyor direkt. Kodu basitleştirdik.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }


        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

    }
}
