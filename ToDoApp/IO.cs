

namespace ToDoApp
{
    public class IO
    {
        public static void Exclusion(string sText)
        {
            Console.WriteLine(sText);
        }
        public static string Input()
        {
            string sText = Console.ReadLine();
            return sText;
        }
    }
}