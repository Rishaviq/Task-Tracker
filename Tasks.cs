using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_Tracker
{
    internal class Tasks
    {   //attributes
        
        static int autoincrementedId = 0;
        [JsonInclude]
        public int _id { get; private set; }
        [JsonInclude]
        private string _name { get; set; }
        [JsonInclude]
        private string _description { get; set; }
        [JsonInclude]
        private string _progress;
        private string progress {
            get { return _progress; }
            set {
                if (string.Compare(value, "Completed", true) == 0)
                {
                    _progress = "Completed";
                }
                else if (string.Compare(value, "In proggres", true) == 0)
                {
                    _progress = "In proggres";

                }
                else if (string.Compare(value, "To Do", true) == 0)
                {
                    _progress = "To Do";
                }
                else { _progress = "To Do"; }

            }
        }
        [JsonInclude]
        private DateTime creationDate { get; set; }
        [JsonInclude]
        private DateTime updatedDate { get; set; }



        //constructors
        public Tasks(string name, string description)
        {
            _id = autoincrementedId;
            autoincrementedId++;
            _description = description;
            _name = name;
            progress = "to do";
            creationDate = DateTime.Now;
        }
        public Tasks(string name)
        {
            _description = "";
            _name = name;
            progress = "to do";
            creationDate = DateTime.Now;
        }



        //methods
        public int GetId() { return _id; }
        public string GetName() { return _name; }
        public string GetDescription() { return _description; }
        public string GetProgress() { return _progress; }
        public DateTime GetCreationDate() { return creationDate; }
        public DateTime GetUpdatedDate() { return updatedDate; }
        


    }
}
