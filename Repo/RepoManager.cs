using Contracts;
using Entities;

namespace Repo
{
    public class RepoManager : IRepoManager
    {
        private RepoContext _context;
        private ICompanyRepo _companyRepo;
        private IEmployeeRepo _employeeRepo;

        private IProjectRepo _projectRepo;
        private IOrgRepo _orgRepo;
        private ISponsorRepo _sponsorRepo;
        private IInvestmentRepo _investmentRepo;
        public RepoManager(RepoContext context)
        {
            _context = context;
        }

        public ICompanyRepo Company
        {
            get
            {
                if (_companyRepo == null)
                    _companyRepo = new CompanyRepo(_context);
                return _companyRepo;
            }
        }

        public IEmployeeRepo Employee
        {
            get
            {
                if (_employeeRepo == null)
                    _employeeRepo = new EmployeeRepo(_context);
                return _employeeRepo;
            }
        }

        public IProjectRepo Project
        {
            get
            {
                if (_projectRepo == null)
                    _projectRepo = new ProjectRepo(_context);
                return _projectRepo;
            }
        }

        public IOrgRepo Organization
        {
            get
            {
                if (_orgRepo == null)
                    _orgRepo = new OrgRepo(_context);
                return _orgRepo;
            }
        }

        public ISponsorRepo Sponsor
        {
            get
            {
                if (_sponsorRepo == null)
                    _sponsorRepo = new SponsorRepo(_context);
                return _sponsorRepo;
            }
        }

        public IInvestmentRepo Investment
        {
            get
            {
                if (_investmentRepo == null)
                    _investmentRepo = new InvestmentRepo(_context);
                return _investmentRepo;
            }
        }

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}

