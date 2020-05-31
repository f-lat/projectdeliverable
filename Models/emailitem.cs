using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectdeliverable.Models
{
    public class emailitem
    {
        public string id { set; get; }
        public string sender { set; get; }
        public string time { set; get; }
        public string content { set; get; }
        public string esubject { set; get; }
        public string receiver { set; get; }
    }

    public class customlists
    {
        public List<string> block;
        public List<string> spam;
    }

}