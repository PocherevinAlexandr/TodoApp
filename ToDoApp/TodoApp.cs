namespace ToDoApp
{
    public class TodoApp
    {
        string fileLocation = "todo-items.txt";
        List<TodoItem> items = new();
        readonly string helpOutput = @"Команды
    Add [item]      Добавляет элемент в список задач
    Do #[number]    Отмечает знаком '*' выполненые задачи, и снимает метку
    Print           Выводит список задач
    Clear           Очистить список задач (без возможности восстановить)
    Help            показывает данную справку
    Exit            Выход, так же можно использовать 'Enter'";

        public TodoApp()
        {
            LoadItems();
        }

        public void UseTestEnvironment()
        {
            fileLocation = "todo-items-test.txt";
            items.Clear();
        }

        void LoadItems()
        {
            if (File.Exists(fileLocation))
            {
                string[] lines = File.ReadAllLines(fileLocation);
                foreach (string line in lines)
                {
                    string text = line.Substring(3);
                    int number = int.Parse(line.Substring(1).Split(' ')[0]);
                    TodoItem newItem = new(text, number);
                    items.Add(newItem);
                }
            }
        }

        void SaveItems()
        {
            List<string> allItems = new();
            foreach (TodoItem item in items)
            {
                allItems.Add(item.ToString());
            }
            File.WriteAllLines(fileLocation, allItems);
        }

        public void Add(string text)
        {
            int newNumber = 1;
            if (items.Count > 0)
            {
                newNumber = items.ElementAt(items.Count - 1).Number + 1;
            }
            TodoItem newItem = new(text, newNumber);
            items.Add(newItem);
            Console.WriteLine(newItem);
            SaveItems();
        }

        public void Do(int number)
        {
            bool found = false;
            foreach (TodoItem item in items)
            {
                if (item.Number == number)
                {
                    Console.WriteLine("Выполнен " + item);
                    found = true;
                    string a = item.ToString();
                    a = a.Substring(3);
                    if (!a.Contains('*'))
                    {
                        TodoItem olditem = new("*" + a, number);
                        items.Insert(number, olditem);
                        items.Remove(item);
                        SaveItems();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Уже выполнено. Хотите отметить как не выполненое?");
                        Console.WriteLine("Нажмите 'Y'");
                        Console.WriteLine("Для отмены нажми 'N'");
                        ConsoleKeyInfo cki;
                        cki = Console.ReadKey(true);
                        if (cki.Key == ConsoleKey.N)
                            break;
                        else if (cki.Key == ConsoleKey.Y)
                        {
                            a = a.Substring(1);
                            TodoItem olditem = new(a, number);
                            items.Insert(number, olditem);
                            items.Remove(item);
                            SaveItems();
                            break;
                        }


                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Не удалось найти элемент с указанным номером");
            }
        }

        public void Print()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Задач нет");
            }
            else
            {
                foreach (TodoItem item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void Clear()
        {
            items.Clear();
            File.Delete(fileLocation);
        }

        public void Help()
        {
            Console.WriteLine(helpOutput);
        }
    }
}