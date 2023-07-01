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

        public TekGain.DAL.Entities.Associate GetAssociateById(int id)
        {
            try
            {
                var associate = _context.Associates.Find(id);
                if (associate != null)
                {
                    return associate;
                }
                else
                {
                    throw new ServiceException("Invalid Associate Id");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving associate by ID");
                throw;
            }
        }


        public List<TekGain.DAL.Entities.Associate> GetAllAssociate()
        {
            try
            {
                var associate = _context.Associates.ToList();
                if (associate != null)
                {
                    return associate;
                }
                else
                {
                    throw new ServiceException("NO Associate Available");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving associate by ID");
                throw;
            }
        }

        public bool AddAssociate(TekGain.DAL.Entities.Associate associate)
        {
            try
            {
                var existingAssociate = _context.Associates.FirstOrDefault(a => a.Email == associate.Email);
                if (existingAssociate != null)
                {
                    return false; // Associate with the same email already exists
                }

                _context.Associates.Add(associate);
                _context.SaveChanges();

                _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Added Associate - {associate}");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding associate");
                throw;
            }
        }

        public bool UpdateAssociateAddress(int id, string addr)
        {
            try
            {
                var associate = _context.Associates.Find(id);
                if (associate == null)
                {
                    return false; // Associate with the given ID does not exist
                }

                associate.Address = addr;
                _context.SaveChanges();

                _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Updated Associate - {associate}");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating associate address");
                throw;
            }
        }

    
    }
}