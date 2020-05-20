using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.ioliu.net.Entity
{
    [SqlSugar.SugarTable("Content")]
    public class Content
    {
        [SqlSugar.SugarColumn(IsPrimaryKey =true)]
        public string id
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
            set
            {
                id = Guid.NewGuid().ToString();
            }
        }

        public DateTime addTime { get; set; }
        public string addUser { get; set; }
        public string content { get; set; }
        public DateTime modifyTime { get; set; }
    }
}
