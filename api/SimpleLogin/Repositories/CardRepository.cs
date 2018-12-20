using API.Models;
using API.Models.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class CardRepository : BaseRepository<Card>
    {
        public override string Table { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

        public override Card FromDataRow(DataRow dr)
        {
            throw new NotImplementedException();
        }

        public override Card FromFilter(List<KeyValuePair<string, string>> filters)
        {
            throw new NotImplementedException();
        }

        public override UpdateDTO<Card> Insert(FilterDTO filters)
        {
            throw new NotImplementedException();
        }

        public override UpdateDTO<Card> Update(FilterDTO filters)
        {
            throw new NotImplementedException();
        }
    }
}
