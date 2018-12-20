using API.Datalayer;
using API.Models.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace API.Repositories
{
    public abstract class BaseRepository<T>
    {
        // Standard values
        public abstract string Table { get; protected set; }
        public virtual string PrimaryKey { get { return "ID"; } protected set { PrimaryKey = value; } }
        public virtual string OrderBy { get { return " order by " + PrimaryKey; } protected set { OrderBy = value; } }
        protected string selectQuery { get { return "select * from " + Table; } }

        // Standard functions
        public abstract T FromDataRow(DataRow dr);

        public abstract UpdateDTO<T> Update(FilterDTO filters);
        public abstract UpdateDTO<T> Insert(FilterDTO filters);


        private string queryGet(FilterDTO filter)
        {
            return selectQuery + (filter.Fields.Count() > 0 ? mapFilter(filter.Fields) : "") + OrderBy;
        }

        private string queryGetById(int id)
        {
            return "select * from " + Table + "where " + PrimaryKey + " = " + id + OrderBy;
        }

        private string mapFilter(IEnumerable<KeyValuePair<string, string>> filter)
        {
            string query = " WHERE 1=1";

            filter.ToList().ForEach(f =>
            {
                query += " AND " + f.Key + "='" + f.Value + "'";
            });
            return query;
        }


        // Check column
        public virtual bool CheckColumn(DataRow dr, string column)
        {
            return dr.Table.Columns.Contains(column);
        }

        public virtual string QueryFields(FilterDTO filters)
        {
            string query = " SET ";
            filters.Fields.Where(f => f.Key.ToLower() != PrimaryKey.ToLower()).ToList().ForEach(f =>
            {
                query += f.Key + " = '" + f.Value + "',";
            });

            return query.Substring(0, query.Length - 1);
        }
        public virtual string QueryInsertFields(FilterDTO filters)
        {
            string queryFields = $"INSERT INTO {Table} (";
            string queryValues = "VALUES(";
            string fields = "";
            string fields2 = "";

            filters.Fields.Where(f => f.Key.ToLower() != PrimaryKey.ToLower()).ToList().ForEach(f =>
            {
                fields += f.Key + ",";
                fields2 += ("'" + f.Value + "',");
            });
            return queryFields + (fields.Remove(fields.Length - 1) + ")" + queryValues + fields2.Remove(fields2.Length - 1) + ")");

        }

        public ResultDTO<T> Get()
        {
            return Get(new FilterDTO());
        }

        public ResultDTO<T> Get(FilterDTO filters)
        {
            ResultDTO<T> result = new ResultDTO<T>();
            
            DataTable dt = Database.ExecSelect(queryGet(filters));
            foreach (DataRow dr in dt.Rows)
            {
                result.Result.Add(FromDataRow(dr));
            }
            return result;
        }
    }
}
