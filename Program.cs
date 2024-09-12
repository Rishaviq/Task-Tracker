using System.Text.Json;
namespace Task_Tracker
{
    internal class Program
    {
       static string fileName = "tasksFile.json";
        public static async Task Main(string[] args)
        {
            LoadFile(); 
            List<Tasks> listTasks = new List<Tasks>();
           
            //Tasks currentTask = new Tasks("go to school");
            


            //string jsonString = JsonSerializer.Serialize(listTasks);
            //File.WriteAllText(fileName, jsonString);
            //Console.WriteLine(jsonString);
            






        }
      static async void LoadFile() {
            if (!File.Exists(fileName))
            {
                await using FileStream createStream = File.Create(fileName);

            }

        }
    }
}
