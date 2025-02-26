using Lab1.Repositories;
using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Repositories
{
	public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts()
        {
            List<Product> listProducts = new List<Product>();
            try
            {
                using MyStoreDbContext db = new MyStoreDbContext();
                listProducts = db.Products.Include(p => p.Category).ToList();
            }
            catch (Exception ex) { }
            return listProducts;
        }

        public void SaveProduct(Product p)
        {
            try
            {
                using MyStoreDbContext db = new MyStoreDbContext();
                db.Products.Add(p);
                db.SaveChanges();   //Update Database
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product p)
        {
            try
            {
                using MyStoreDbContext db = new MyStoreDbContext();
                db.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(Product p)
        {
            try
            {
                using MyStoreDbContext db = new MyStoreDbContext();
                Product? p1 = db.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                db.Products.Remove(p1);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product GetProductById (int id)
        {
            using MyStoreDbContext db = new MyStoreDbContext();
            return db.Products.Include(p => p.Category).FirstOrDefault(c => c.ProductId.Equals(id));
        }
    }
}
