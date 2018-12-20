using API.Datalayer;
using API.Models;
using API.Models.Exceptions;
using API.Models.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        // Override table
        public override string Table { get { return "gebruikers"; } protected set { Table = value; } }

        public ResultDTO<User> Get(char[] code)
        {
            ResultDTO<User> result = new ResultDTO<User>();

            string query = "select * from gebruikers where code = '" + new string(code) + "'";
            DataTable dt = Database.ExecSelect(query);
            foreach (DataRow dr in dt.Rows)
            {
                result.Result.Add(FromDataRow(dr));
            }
            return result;
        }
        
        /// <summary>
        /// Override FromDataRow for convert to User
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public override User FromDataRow(DataRow dr)
        {
            return new User()
            {
                ID = CheckColumn(dr, "ID") ? int.Parse(dr["ID"].ToString()) : 0,
                Email = CheckColumn(dr, "Email") ? dr["Email"].ToString() : "",
                Name = CheckColumn(dr, "Naam") ? dr["Naam"].ToString() : "",
                PhoneNumber = CheckColumn(dr, "Telnr") ? dr["Telnr"].ToString() : "",
                Birthdate = CheckColumn(dr, "Gbdatum") ? Convert.ToDateTime(dr["Gbdatum"].ToString()) : new DateTime(),
                Code = CheckColumn(dr, "Code") ? dr["Code"].ToString().ToArray() : new char[0]
            };
        }
        
        public override UpdateDTO<User> Update(FilterDTO filters)
        {
            UpdateDTO<User> result = new UpdateDTO<User>();
            string pKeyValue = filters.Fields.Where(f => f.Key.ToLower() == PrimaryKey.ToLower()).FirstOrDefault().Value;
            string where = " where " + PrimaryKey + " = '" + pKeyValue + "'";

            string query = "update " + Table + QueryFields(filters) + where;
            bool success = Database.ExecOverig(query);

            return new UpdateDTO<User>()
            {
                Success = success,
                Obj = FromDataRow(Database.ExecSelect(selectQuery + where).Rows[0])
            };
        }

        public override UpdateDTO<User> Insert(FilterDTO filters)
        {
            UpdateDTO<User> result = new UpdateDTO<User>();

            string query = QueryInsertFields(filters);
            bool success = Database.ExecOverig(query);
            return new UpdateDTO<User>()
            {
                Success = success,
                Obj = FromDataRow(Database.ExecSelect(selectQuery + " order by " + PrimaryKey + " desc").Rows[0])
            };
        }
    }
}
