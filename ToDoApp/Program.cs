namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoApp app = new();

            MyClass.DoIt("Напиши help чтобы увидеть команды");

            Console.Write(">");

            string inputLine = Console.ReadLine();
            while (!inputLine.Equals("") && !inputLine.ToLower().Equals("exit"))
            {
                if (inputLine.StartsWith("Add "))
                {
                    string text = inputLine.Split(new[] { "Add " }, StringSplitOptions.None)[1];
                    app.Add(text);
                }
                else if (inputLine.StartsWith("Do #"))
                {
                    try
                    {
                        int doNumber = int.Parse(inputLine.Split(new[] { "Do #" }, StringSplitOptions.None)[1]);
                        app.Do(doNumber);
                    }
                    catch (FormatException)
                    {
                        MyClass.DoIt("Укажите номер готового элемента для пометки.");
                    }
                }
                else if (inputLine.ToLower().Equals("clear"))
                {
                    app.Clear();
                }
                else if (inputLine.ToLower().Equals("print"))
                {
                    app.Print();
                }
                else if (inputLine.ToLower().Equals("help"))
                {
                    app.Help();
                }
                else
                {
                    MyClass.DoIt("Команда не распознана, введите help, чтобы просмотреть все команды");
                }
                Console.Write(">");
                inputLine = Console.ReadLine();
            }
        }
    }
}