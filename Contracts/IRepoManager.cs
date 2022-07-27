﻿namespace Contracts
{
    public interface IRepoManager
    {
        ICompanyRepo Company { get; }
        IEmployeeRepo Employee { get; }
        ISponsorRepo Sponsor { get;}
        IOrgRepo Organization { get; }
        IProjectRepo Project { get; }
        Task SaveAsync();
    }
}

