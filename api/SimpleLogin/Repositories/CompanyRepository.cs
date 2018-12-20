using API.Models;
using API.Models.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class CompanyRepository : BaseRepository<Company>
    {
        public override string Table { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

        public override Company FromDataRow(DataRow dr)
        {
            throw new NotImplementedException();
        }

        public override Company FromFilter(List<KeyValuePair<string, string>> filters)
        {
            throw new NotImplementedException();
        }

        public override UpdateDTO<Company> Insert(FilterDTO filters)
        {
            throw new NotImplementedException();
        }

        public override UpdateDTO<Company> Update(FilterDTO filters)
        {
            throw new NotImplementedException();
        }
    }
}
