using API.Models;
using API.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    interface ICompanyService
    {
        ResultDTO<Company> GetDetails(int id);
        ResultDTO<Company> GetCompanies();
    }
}
