using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionIMG
{
   public class ResponseModel
    {
		public string api
		{
			get;
			set;
		}

		public Data data
		{
			get;
			set;
		}

		public string[] ret
		{
			get;
			set;
		}

		public string v
		{
			get;
			set;
		}
	}
}
