using System;
using System.Collections.Generic;
using System.Linq;
using DAL.ModelDAL;
using EntityDataBase;

namespace DAL.Repository
{
    public class ProductRepository : AbstractRepository, IModelRepository<ProductObject, Product>
    {
        Product ToEntity(ProductObject source)
        {
            return new Product()
            {
                Name = source.Name,
                Cost = source.Cost
            };
        }

        ProductObject ToObject(Product source)
        {
            return new ProductObject()
            {
                Name = source.Name,
                Cost = source.Cost
            };
        }

        public Product GetEntity(ProductObject source)
        {
            var entity = this.applicationContext.Products.FirstOrDefault(x => x.Name == source.Name && x.Cost == source.Cost);
            return entity;
        }

        public Product GetEntityNameById(int id)
        {
            var entity = this.applicationContext.Products.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public void Add(ProductObject item)
        {
            var entity = this.ToEntity(item);
            applicationContext.Products.Add(entity);
        }

        public void Remove(ProductObject item)
        {
            var entity = this.applicationContext.Products.FirstOrDefault(x => x.Id == item.Id);
            if (entity != null)
            {
                applicationContext.Products.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(ProductObject item)
        {
            var entity = this.applicationContext.Products.FirstOrDefault(x => x.Id == item.Id);
            if (entity != null)
            {
                entity.Name = item.Name;
                entity.Cost = item.Cost;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<ProductObject> Items
        {
            get
            {
                return this.applicationContext.Products.Select(x => this.ToObject(x));
            }
        }

        public void SaveChanges()
        {
            applicationContext.SaveChanges();
        }
    }
}
