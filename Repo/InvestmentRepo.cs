using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repo
{
    public class InvestmentRepo : RepoBase<Investment>, IInvestmentRepo
    {
        public InvestmentRepo(RepoContext context):base(context)
        {
        }

        public void CreateTransaction(Investment investment) => Create(investment);

        public async Task<IEnumerable<Investment>> GetAll(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();
    }
}