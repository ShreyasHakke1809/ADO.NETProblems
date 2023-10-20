using Ado.net;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("1.Get data from database\n2.Add new data\n3.Delete data by id\n4.Update data by id\n5.Exit");
        bool loopAgain = true;
        while (loopAgain)
        {
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Employee.GetAllEmployees();
                    break;
                case 2:
                    Employee.InsertData();
                    break;
                case 3:
                    Employee.DeleteData();
                    break;
                case 4:
                    Employee.UpdateData();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                case 6:
                    loopAgain = false;
                    break;
            }
        }
    }
}