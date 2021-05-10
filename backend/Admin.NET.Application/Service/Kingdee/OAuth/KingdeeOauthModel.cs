using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Service.Kingdee.OAuth
{
    public class KingdeeOauthModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string format { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string useragent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string v { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> parameters { get; set; }
    }
}
