using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handbook.Code
{
    public class AllMenu
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? parentID { get; set; }
        public List<AllMenu> children { get; set; } 
    }
}