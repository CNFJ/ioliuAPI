using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.ioliu.net.Db
{

    public class DBContext<T> where T : class, new()
    {
        private SqlSugarClient Db = null;

        public static DBContext<T> OpDB()
        {
            DBContext<T> dbcontext_t = new DBContext<T>();

            dbcontext_t.Db = new SqlSugarClient(new ConnectionConfig()
            {

                ConnectionString = "server=.;uid=sa;pwd=df727123.;database",
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute

            }); ;
            return dbcontext_t;
        }
        protected DBContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Data Source=47.106.166.10;port=3306; Initial Catalog=camerafic;uid=root; pwd=df727123.",
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //调式代码 用来打印SQL
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }
        //可以扩展更多方法 
    }
}
