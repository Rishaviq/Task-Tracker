using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_Tracker
{
    internal class Tasks
    {   //attributes

        [JsonInclude]
        public int _id { get; private set; }
        [JsonInclude]
        private string _name { get; set; }
        [JsonInclude]
        private string _description { get; set; }
        [JsonInclude]
        private string? _progress;
        private string progress
        {
            get { return _progress ?? ""; }
            set
            {
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

    /*    public Tasks(string name, string description)
        {
            _id = Aoutoincrementing();
            _description = description;
            _name = name;
            progress = "To do";
            creationDate = DateTime.Now;
        }*/
        public Tasks(string name)
        {
            _id = Aoutoincrementing();
            _description = "";
            _name = name;
            progress = "To do";
            creationDate = DateTime.Now;
            updatedDate = DateTime.Now;
        }
        [JsonConstructor]
        public Tasks(int _Id, string _Name, string _Description, string _Progress, DateTime CreationDate, DateTime UpdatedDate) =>
           (_id, _name, _description, _progress, creationDate, updatedDate) = (_Id, _Name, _Description, _Progress, CreationDate, UpdatedDate);




        //get methods
        public int GetId() { return _id; }
        public string GetName() { return _name; }
        public string GetDescription() { return _description; }
        public string GetProgress() { return _progress ?? ""; }
        public DateTime GetCreationDate() { return creationDate; }
        public DateTime GetUpdatedDate() { return updatedDate; }

        //set methods
        public void SetName(string newName) {_name = newName;}
        public void SetProgress(string newprogress) { progress = newprogress; }
        public void SetUpdatedDate() { updatedDate = DateTime.Now; }



        //autoincrement method
        private int Aoutoincrementing()
        {
            try
            {
                if (!File.Exists("autoincrementId.txt"))
                {
                    using FileStream createStream = File.Create("autoincrementId.txt");
                    File.WriteAllText("autoincrementId.txt", "0");
                }

                int tempId = Int32.Parse(File.ReadAllText("autoincrementId.txt"));

                File.WriteAllText("autoincrementId.txt", tempId++.ToString());



                return tempId;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return 0;
        }

        //method displaying the task
        public void Display() {
            Console.WriteLine(_id.ToString());
            Console.WriteLine(_name.ToString());
            //Console.WriteLine(_description.ToString());  //scrapped the idea of description
            Console.WriteLine(progress.ToString());
            Console.WriteLine(creationDate.ToString());
            Console.WriteLine(updatedDate.ToString());
        }
    }
}




