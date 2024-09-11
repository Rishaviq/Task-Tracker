using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Tracker
{
    internal class Tasks
    {

        private string _name { get; set; }
        private string _description { get; set; }
        
        private string progress;

       public Tasks(string name, string description)
        {
            _description = description;
            _name = name;
            progress = "no progress";
        }
        public Tasks(string name)
        {
            _description ="";
            _name = name;
            progress = "no progress";
        }
    }
}
