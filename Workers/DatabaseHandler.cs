using DAL.ModelDAL;
using DAL.Repository;
using EntityDataBase;

namespace Workers
{
    class DatabaseHandler
    {
        private IModelRepository<ManagerObject, Manager> _managerRepository;
        private IModelRepository<ClientObject, Client> _clientRepository;
        private IModelRepository<ProductObject, Product> _productRepository;
        private IModelRepository<SaleInfoObject, SaleInfo> _saleInfoRepository;
        private Logger _logger;

        public DatabaseHandler()
        {
            _managerRepository = new ManagerRepository();
            _clientRepository = new CilentRepository();
            _productRepository = new ProductRepository();
            _saleInfoRepository = new SaleInfoRepository();
            _logger = new Logger();
        }

        public void AddToDatabase(Journal journal)
        {
           lock (this)
           {        
                var newManager = new ManagerObject { Name = journal.ManagerName };
                var manager = _managerRepository.GetEntity(newManager);
                if (manager == null)
                {
                    _managerRepository.Add(newManager);
                    _managerRepository.SaveChanges();
                    manager = _managerRepository.GetEntity(newManager);
                    _logger.RecordInFileLog("Manager", manager.Name, manager.Id.ToString());
                }

                var newClient = new ClientObject { Name = journal.ClientName };
                var client = _clientRepository.GetEntity(newClient);
                if (client == null)
                {
                    _clientRepository.Add(newClient);
                    _clientRepository.SaveChanges();
                    client = _clientRepository.GetEntity(newClient);
                    _logger.RecordInFileLog("Client", client.Name, client.Id.ToString());
                }


                var newProduct = new ProductObject { Name = journal.ProductName, Cost = journal.ProductCost };
                var product = _productRepository.GetEntity(newProduct);
                if (product == null)
                {
                    _productRepository.Add(newProduct);
                    _productRepository.SaveChanges();
                    product = _productRepository.GetEntity(newProduct);
                    _logger.RecordInFileLog("Product", product.Name, product.Id.ToString());
                }

                var newsaleInfo = new SaleInfoObject
                {
                    DateSale = journal.SaleDate,
                    ManagerId = manager.Id,
                    ClientId = client.Id,
                    ProductId = product.Id
                };
                _saleInfoRepository.Add(newsaleInfo);
                _saleInfoRepository.SaveChanges();
                var saleInfo = _saleInfoRepository.GetEntity(newsaleInfo);
                _logger.RecordInFileLog("SaleInfo", saleInfo.Id.ToString(), saleInfo.ManagerId.ToString(), saleInfo.ClientId.ToString(), saleInfo.ProductId.ToString());
           }
        }
    }
}
