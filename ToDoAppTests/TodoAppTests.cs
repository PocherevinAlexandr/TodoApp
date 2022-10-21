namespace ToDoApp.Tests
{
    [TestClass()]
    public class TodoAppTests
    {
        [TestMethod()]
        public void AddAndPrintTest()
        {
            TodoApp todoApp = new();
            todoApp.UseTestEnvironment();

            using (StringWriter sw = new())
            {
                Console.SetOut(sw);

                todoApp.Add("This is a test");
                string expected = "#1 This is a test\r\n";

                Assert.AreEqual(expected, sw.ToString());


            }

            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
                todoApp.Add("another item");
                string expectedPrint = "#2 another item\r\n#1 This is a test\r\n#2 another item\r\n";
                todoApp.Print();
                Assert.AreEqual(expectedPrint, sw.ToString());
            }
        }

        [TestMethod()]
        public void DoTest()
        {
            TodoApp todoApp = new();
            todoApp.UseTestEnvironment();

            using StringWriter sw = new();
            Console.SetOut(sw);
            todoApp.Add("This is a test");
            todoApp.Add("another string");
            todoApp.Do(1);
            string expected = "#1 This is a test\r\n#2 another string\r\nВыполнен #1 This is a test\r\n#1 *This is a test\r\n#2 another string\r\n";
            todoApp.Print();
            Assert.AreEqual(expected, sw.ToString());
        }
    }
}