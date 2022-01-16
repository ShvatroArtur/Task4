using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ModelDAL;
using EntityDataBase;

namespace DAL.Repository
{
    public class SaleInfoRepository : AbstractRepository, IModelRepository<SaleInfoObject, SaleInfo>
    {
        SaleInfo ToEntity(SaleInfoObject source)
        {
            return new SaleInfo()
            {
                DateSale = source.DateSale,
                ManagerId = source.ManagerId,
                ClientId = source.ClientId,
                ProductId = source.ProductId
            };
        }

        SaleInfoObject ToObject(SaleInfo source)
        {
            return new SaleInfoObject()
            {
                DateSale = source.DateSale,
                ManagerId = source.ManagerId,
                ClientId = source.ClientId,
                ProductId = source.ProductId
            };
        }

        public SaleInfo GetEntity(SaleInfoObject source)
        {
            
            var maxId = this.applicationContext.SaleInfos.Max(x=>x.Id);
            var entity = this.applicationContext.SaleInfos.FirstOrDefault(x => x.Id == maxId);
            return entity;
        }

        public SaleInfo GetEntityNameById(int id)
        {
            var entity = this.applicationContext.SaleInfos.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public void Add(SaleInfoObject item)
        {
            var entity = this.ToEntity(item);
            applicationContext.SaleInfos.Add(entity);
        }

        public void Remove(SaleInfoObject item)
        {
            var entity = this.applicationContext.SaleInfos.FirstOrDefault(x => x.Id == item.Id);
            if (entity != null)
            {
                applicationContext.SaleInfos.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(SaleInfoObject item)
        {
            var entity = this.applicationContext.SaleInfos.FirstOrDefault(x => x.Id == item.Id);
            if (entity != null)
            {
                entity.DateSale = item.DateSale;
                entity.ManagerId = item.ManagerId;
                entity.ClientId = item.ClientId;
                entity.ProductId = item.ProductId;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<SaleInfoObject> Items
        {
            get
            {
                var listSaleInfoObject = new List<SaleInfoObject>();
                foreach (var saleInfo in this.applicationContext.SaleInfos.Select(x => x))
                {
                    listSaleInfoObject.Add(ToObject(saleInfo));
                }

                return listSaleInfoObject;
            }
        }

        public void SaveChanges()
        {
            applicationContext.SaveChanges();
        }
    }
}
