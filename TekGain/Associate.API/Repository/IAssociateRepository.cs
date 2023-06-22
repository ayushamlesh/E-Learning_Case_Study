
namespace Associate.API.Repository
{
    public interface IAssociateRepository
    {
        List<TekGain.DAL.Entities.Associate> GetAllAssociate();
        bool AddAssociate(TekGain.DAL.Entities.Associate associate);
        TekGain.DAL.Entities.Associate? GetAssociateById(int id);
        bool UpdateAssociateAddress(int id, string addr);
    }
}