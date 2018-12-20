using API.Datalayer;
using API.Models;
using API.Models.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class SaldoRepository : BaseRepository<Balance>
    {
        public override string Table { get => "Saldo"; protected set => Table = value; }

        public override Balance FromDataRow(DataRow dr)
        {
            return new Balance()
            {
                CardId = CheckColumn(dr, "CardID") ? int.Parse(dr["CardID"].ToString()) : 0,
                UserId = CheckColumn(dr, "UserId") ? int.Parse(dr["UserId"].ToString()) : 0,
                Amount = CheckColumn(dr, "Hoeveelheid") ? decimal.Parse(dr["Hoeveelheid"].ToString()) : (decimal)0,
                Favorite = CheckColumn(dr, "Favorieten") ? bool.Parse(dr["Favorieten"].ToString()) : false,
                Card = new Card()
                {
                    ID = CheckColumn(dr, "CardID") ? int.Parse(dr["CardID"].ToString()) : 0,
                    Company = CheckColumn(dr, "Bedrijf") ? dr["Bedrijf"].ToString() : "",
                    Name = CheckColumn(dr, "Naam") ? dr["Naam"].ToString() : "",
                }
            };
        }
        
        public BaseDTO DeleteCard(FilterDTO filters)
        {
            throw new NotImplementedException();
        }

        public UpdateDTO<Balance> Update(FilterDTO filters, int user)
        {
            string pKeyValue = filters.Fields.Where(f => f.Key.ToLower() == PrimaryKey.ToLower()).FirstOrDefault().Value;
            string where = " where " + PrimaryKey + " = '" + pKeyValue + "' AND UserID = '" + user + "'";

            string query = "update " + Table + QueryFields(filters) + where;
            bool success = Database.ExecOverig(query);

            return new UpdateDTO<Balance>()
            {
                Success = success,
                Obj = FromDataRow(Database.ExecSelect("select * from " + Table + where).Rows[0])
            };
        }

        public ResultDTO<Balance> GetCards(int id)
        {
            ResultDTO<Balance> result = new ResultDTO<Balance>();

            string query = $"select s.*, k.Naam, k.Bedrijf from Saldo s inner join Kaart k on k.ID = s.CardID where s.UserID = '{id}'";
            DataTable dt = Database.ExecSelect(query);
            foreach (DataRow dr in dt.Rows)
            {
                result.Result.Add(FromDataRow(dr));
            }
            return result;
        }

        public BaseDTO Delete(FilterDTO filters)
        {
            throw new NotImplementedException();
        }

        public override UpdateDTO<Balance> Insert(FilterDTO filters)
        {
            throw new NotImplementedException();
        }

        public override UpdateDTO<Balance> Update(FilterDTO filters)
        {
            throw new NotImplementedException();
        }
    }
}
