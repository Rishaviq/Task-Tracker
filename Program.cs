using System.Data;
using System.Text.Json;
namespace Task_Tracker
{
    internal class Program
    {
       static string fileName = "tasksFile.json";
      static List<Tasks> listTasks = new List<Tasks>();
        public static void Main(string[] args)
        {
            
             
           
            for (; ; ) {
                listTasks = LoadFile(listTasks);

                string[] input = InputReader(Console.ReadLine());
                CommandRecognition(input);
                SaveTasks();

            }



        }
        static List<Tasks> LoadFile(List<Tasks>? loadingTasks) {
            try
            {
                if (!File.Exists(fileName))
                {
                     using FileStream createStream = File.Create(fileName);

                }
                string jsonString = File.ReadAllText(fileName);
                Console.WriteLine(jsonString);
                var options = new JsonSerializerOptions { IncludeFields = true };
                loadingTasks = JsonSerializer.Deserialize<List<Tasks>>(jsonString, options);

                Console.WriteLine("'" + loadingTasks[0].GetName() + "'");
                return loadingTasks;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return null;
        }


        static string[] InputReader(string input) {  //not proud of it
            string[] commandInfo = input.Split(" ");
            int newleanght = 0;
            bool connecting = true;
            for (int i = 0; i < commandInfo.Length; i++)
            {
                newleanght++;
                
                if (commandInfo[i].Contains("\"") && connecting)
                {
                  
                    for (int j = i+1; j < commandInfo.Length; j++) {
                        commandInfo[i] = commandInfo[i] +" "+ commandInfo[j];
                        if (commandInfo[j].Contains("\"")) {
                            connecting = false;
                            break;
                        }


                    }
                    break;
                }
               
            }
            Array.Resize<string>(ref commandInfo, newleanght);
            return commandInfo;
        }

       static void CommandRecognition(string[] input) {
            if (input[0] == "add")
            {
                AddTask(input);

            }
            else if (input[0] == "update")
            {
                UpdateTask(input);
            }
            else if (input[0] == "delete")
            {
                DeleteTask(input);
            }
            else if (input[0] == "mark-in-progress")
            {
                MarkProgress(input);
            }
            else if (input[0] == "mark-done")
            {
                MarkDone(input);
            }
            else if (input[0] == "list")
            {
                DisplayTasks(input);
            }
            else { Console.WriteLine("Inavalid command. Try again!"); }


        }

      static  void AddTask(string[] input) {
            Tasks newTask = new Tasks(input[1]);
            listTasks.Add(newTask);
        
        }

      static   void UpdateTask(string[] input)
        {
            for (int i = 0; i < listTasks.Count; i++)
            {
                if (listTasks[i]._id == Int32.Parse(input[1]))
                {
                    listTasks[i].SetName(input[2]);
                }
            }

        }

       static void DeleteTask(string[] input)
        {

            for (int i = 0; i < listTasks.Count; i++)
            {
                if (listTasks[i]._id == Int32.Parse(input[1]))
                {
                    listTasks.Remove(listTasks[i]);
                }
            }
        }

       static void MarkProgress(string[] input) {

            for (int i = 0; i < listTasks.Count; i++)
            {
                if (listTasks[i]._id == Int32.Parse(input[1]))
                {
                    listTasks[i].SetProgress("In proggres");
                }
            }

        }

       static void MarkDone(string[] input)
        {

            for (int i = 0; i < listTasks.Count; i++)
            {
                if (listTasks[i]._id == Int32.Parse(input[1]))
                {
                    listTasks[i].SetProgress("Completed");
                }
            }

        }

       static void DisplayTasks(string[] input) {
            if (input.Length == 2) {
                if (input[1] == "done")
                {
                    for (int i = 0; i < listTasks.Count; i++)
                    {
                        if (listTasks[i].GetProgress() == "Completed")
                        {
                            listTasks[i].Display();
                            Console.WriteLine("");
                        }
                    }

                }
                else if (input[1] == "todo")
                {
                    for (int i = 0; i < listTasks.Count; i++)
                    {
                        if (listTasks[i].GetProgress() == "To Do")
                        {
                            listTasks[i].Display();
                            Console.WriteLine("");
                        }
                    }
                }
                else if (input[1] == "in-progress")
                {
                    for (int i = 0; i < listTasks.Count; i++)
                    {
                        if (listTasks[i].GetProgress() == "In proggres")
                        {
                            listTasks[i].Display();
                            Console.WriteLine("");
                        }
                    }
                }
                else { Console.WriteLine("Inavalid command. Try again!"); }

            }
            else {
                for (int i = 0; i < listTasks.Count; i++) {
                    listTasks[i].Display();
                    Console.WriteLine("");
                }
                    
            }
        
        }

       static void SaveTasks() {
            try
            {
                string jsonString = JsonSerializer.Serialize(listTasks);
                File.WriteAllText(fileName, jsonString);
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
