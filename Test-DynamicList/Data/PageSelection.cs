using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_DynamicList.Data
{
    public class PageSelection
    {
        public string Custodian { get; set; } = "";
        public string Release { get; set; } = "";
        public string Page { get; set; } = "";
        public bool IsLocked { get; set; } = false;
    }
}
