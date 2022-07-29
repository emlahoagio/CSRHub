using Entities.Models;

namespace Contracts
{
    public interface IInvestmentRepo
    {
        Task<IEnumerable<Investment>> GetAll(bool trackChanges);
        void CreateTransaction(Investment investment);
    }
}

