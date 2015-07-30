using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UniDeb
{
    
    public class Service
    {
        private static Service service;
        public String ConnectionString { get; set; }
        public TextBox CurrentTextbox { get; set; } 

        private Service() {
            // empty constructor
        }

        public static Service getInstance()
        {
            if (service == null)
                service = new Service();
            return service;
        }

     
    }
}
