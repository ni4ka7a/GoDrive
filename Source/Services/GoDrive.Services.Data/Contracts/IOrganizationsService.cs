﻿namespace GoDrive.Services.Data.Contracts
{
    using System.Linq;
    using GoDrive.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetALl();

        IQueryable<Organization> GetById(int id);
    }
}
