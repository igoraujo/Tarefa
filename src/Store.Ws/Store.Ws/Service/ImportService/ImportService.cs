using StoreWS.UnitOfWork;

namespace StoreWS.Service
{
    public class ImportService : IImportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }               

        public void Example()
        {
            
        }
    }
}