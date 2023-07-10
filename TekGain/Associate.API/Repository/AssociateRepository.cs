using TekGain.DAL;
using TekGain.DAL.ErrorHandler;

namespace Associate.API.Repository
{
    public class AssociateRepository : IAssociateRepository
    {
        // Implement the code here

        private readonly TekGainContext _context;
        private readonly ILogger<AssociateRepository> _logger;

        public AssociateRepository(TekGainContext context, ILogger<AssociateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public List<TekGain.DAL.Entities.Associate> GetAllAssociate()
        {
            return _context.Associates.ToList();
        }
        public bool AddAssociate(TekGain.DAL.Entities.Associate associate)
        {
            bool associateExists = _context.Associates.Any(c => string.Equals(c.Email, associate.Email));

            if (associateExists)
            {
                return false;
            }

            _context.Associates.Add(associate);
            _context.SaveChanges();
            _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Added course-{associate}");
            return true;
        }
        public TekGain.DAL.Entities.Associate? GetAssociateById(int id)
        {
            var a = _context.Associates.FirstOrDefault(c => c.Id == id);
            if (a != null)
            {
                return a;
            }
            else
            {
                throw new ServiceException("Invalid Associate Id");
            }
        }
        public bool UpdateAssociateAddress(int id, string addr)
        {
            var result = _context.Associates.FirstOrDefault(c => c.Id == id);
            if (result == null)
            {
                return false;
            }
            else
            {
                result.Address = addr;
                _context.SaveChanges();
            }

            //_logger.LogInformation($"{DateTime.Now} INFO: Updated Associate address associate-{id}");
            _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Updated Associate address associate-{id}");


            return true;
        }
    }
}