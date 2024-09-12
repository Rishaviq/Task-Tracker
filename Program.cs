using System.Text.Json;
namespace Task_Tracker
{
    internal class Program
    {
       static string fileName = "tasksFile.json";
        public static void Main(string[] args)
        {
            
              List<Tasks> listTasks = new List<Tasks>();
            listTasks= LoadFile(listTasks);

            Console.WriteLine("'" +listTasks[0].GetCreationDate().ToString() +"'");


            //Tasks currentTask = new Tasks("go to school");




            //Console.WriteLine(jsonString);







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

        List<Tasks> AddTask() {

            return null;
        }
    
    }
}
