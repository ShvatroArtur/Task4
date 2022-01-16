using EntityDataBase;
using DAL.ModelDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CilentRepository : AbstractRepository, IModelRepository<ClientObject, Client>
    {
        Client ToEntity(ClientObject source)
        {
            return new Client()
            {
                Name = source.Name
            };
        }

        ClientObject ToObject(Client source)
        {
            return new ClientObject()
            {
                Name = source.Name
            };
        }

        public Client GetEntity(ClientObject source)
        {
            var entity = this.applicationContext.Clients.FirstOrDefault(x => x.Name == source.Name);
            return entity;
        }

        public Client GetEntityNameById(int id)
        {
            var entity = this.applicationContext.Clients.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public void Add(ClientObject item)
        {
            var entity = this.ToEntity(item);
            this.applicationContext.Clients.Add(entity);
        }

        public void Remove(ClientObject item)
        {
            var entity = this.applicationContext.Clients.FirstOrDefault(x => x.Id == item.Id);
            if (entity != null)
            {
                this.applicationContext.Clients.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(ClientObject item)
        {
            var entity = this.applicationContext.Clients.FirstOrDefault(x => x.Id == item.Id);
            if (entity != null)
            {
                entity.Name = item.Name;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<ClientObject> Items
        {
            get
            {
                return this.applicationContext.Clients.Select(x => this.ToObject(x));
            }
        }

        public void SaveChanges()
        {
            this.applicationContext.SaveChanges();
        }
    }
}
