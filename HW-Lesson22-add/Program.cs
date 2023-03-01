using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


Employee root = null;

while (true)
{
        
    Console.WriteLine("Выберете пункт меню");
    Console.WriteLine();
    Console.WriteLine("1 - для ввода данных о сотрудниках, 2 - вывод отсортированного списка");
    Console.WriteLine("3 - для поиска сотрудника, 4 - для выхода из программы  ");


    string choise = Console.ReadLine();

    switch (choise)

    {
        case "1":

            for (int i = 0; i < 1; )
            {

                Console.Write("Введите имя: ");
                var _name = Console.ReadLine();

                        if (string.IsNullOrEmpty(_name))
                        {
                            break;
                        }


                Console.Write("Введите зарплату: ");
                Console.WriteLine();
                var d = int.Parse(Console.ReadLine());

                if (root == null)
                {
                    root = new Employee()
                    {
                        Name = _name,
                        Sallary = d
                    };
                }
                else
                {
                    AddEmployee(root, new Employee
                    {
                        Name = _name,
                        Sallary = d
                    });
                }

            }
                
                break;
            

        case "2":

            if (root == null)
            {
                Console.WriteLine("данных о сотрудниках нет");
                break;
            }

            Console.WriteLine("Sorted:");
            Traverse(root);

            break;

        case "3":

            if (root == null)
            {
                Console.WriteLine("данных о сотрудниках нет");
                break;
            }

            Console.WriteLine("Какая зарплата ищется");

            int _sallary = int.Parse(Console.ReadLine());

            var (employee, level) = FindEmployee(root, _sallary, level: 1);
            if (employee == null)
            {
                Console.WriteLine("Такой сотрудник не найден");
            }
            else
            {
                Console.WriteLine($"Сотрудник найден, его имя: {employee.Name}, его зарплата: {employee.Sallary}");
            }

            break;

        case "4":

            return;

        default:
            Console.WriteLine("неверный ввод, введите 1, 2, 3 или 4");
            break;
    }


}  
    


static (Employee employee, int level) FindEmployee(Employee root, int number, int level)
{
if (number < root.Sallary)
{
//ищем в левом поддереве
if (root.Left != null)
{
return FindEmployee(root.Left, number, level + 1);
}
return (null, -1);
}
if (number > root.Sallary)
{
//ищем в правом поддереве
if (root.Right != null)
{
return FindEmployee(root.Right, number, level + 1);
}
return (null, -1);
}
return (root, level);
}



static void Traverse(Employee rootNode)
{

if (rootNode.Left != null)
{
Traverse(rootNode.Left);
}

Console.Write(rootNode.Name);
Console.WriteLine(", Sallary:   " + rootNode.Sallary);

if (rootNode.Right != null)
{
Traverse(rootNode.Right);
}
}




static void AddEmployee(Employee root, Employee toAdd)
{
if (toAdd.Sallary < root.Sallary)
{
//Идем в левое поддерево

if (root.Left != null) AddEmployee(root.Left, toAdd);
else root.Left = toAdd;
}
else
{
//Идем в правое поддерево
if (root.Right != null) AddEmployee(root.Right, toAdd);
else root.Right = toAdd;
}
}





public class Employee
{

    public string Name { get; set; }
    public int Sallary { get; set; }

    public Employee Left { get; set; }
    public Employee Right { get; set; }
}