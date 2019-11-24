using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_DynamicList.Data
{
    [Serializable]   
    public class PageItem
    {
        public int LineOrder { get; set; }
        public string Release { get; set; }
        public string Action { get; set; }
        public bool HasEdit { get; set; }
        public string Data { get; set; }
    }
}
