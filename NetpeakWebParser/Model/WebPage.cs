using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetpeakWebParser
{
    class WebPage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ResponseCode { get; set; }
        public TimeSpan ResponseTime { get; set; }
        public List<string> HeadersList { get; set; }
        public List<string> ImagesList { get; set; }
        public List<string> HrefInnerList { get; set; } // внутринние
        public List<string> HrefOuterList { get; set; } //внешние 

        public WebPage()
        {
            HeadersList = new List<string>();
            ImagesList = new List<string>();
            HrefInnerList = new List<string>();
            HrefOuterList = new List<string>();
        }
    }
}
