using API.Models;
using API.Models.Results;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CompanyService: ICompanyService
    {
        CompanyRepository _repo;

        public CompanyService()
        {
            _repo = new CompanyRepository();
        }

        public ResultDTO<Company> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public ResultDTO<Company> GetDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
