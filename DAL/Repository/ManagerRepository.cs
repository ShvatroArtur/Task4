using DAL.ModelDAL;
using EntityDataBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class ManagerRepository : AbstractRepository, IModelRepository<ManagerObject, Manager>
    {
        Manager ToEntity(ManagerObject source)
        {
            return new Manager()
            {
                Name = source.Name
            };
        }

        ManagerObject ToObject(Manager source)
        {
            return new ManagerObject()
            {
                Name = source.Name
            };
        }

        public Manager GetEntity(ManagerObject source)
        {
            var entity = this.applicationContext.Managers.FirstOrDefault(x => x.Name == source.Name);
            return entity;
        }

        public Manager GetEntityNameById(int id)
        {
            var entity = this.applicationContext.Managers.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public void Add(ManagerObject item)
        {
            var entity = this.ToEntity(item);
            this.applicationContext.Managers.Add(entity);
        }

        public void Remove(ManagerObject item)
        {
            var entity = this.applicationContext.Managers.FirstOrDefault(x => x.Id == item.Id);
            if (entity != null)
            {
                applicationContext.Managers.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(ManagerObject item)
        {
            var entity = this.applicationContext.Managers.FirstOrDefault(x => x.Name == item.Name);
            if (entity != null)
            {
                entity.Name = item.Name;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<ManagerObject> Items
        {    
            get
            {
                var listManagerObject = new List<ManagerObject>();
                foreach (var manager in this.applicationContext.Managers.Select(x=>x))
                {
                    listManagerObject.Add(ToObject(manager));
                }

                return listManagerObject;
            }
        }
       
        
        public void SaveChanges()
        {
            this.applicationContext.SaveChanges();
        }
    }
}

