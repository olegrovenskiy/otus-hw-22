
using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


int choise = 4;

while (true)

{

    if (choise == 3)
    {
        break;
    }


    bool textCheck = false;



    Console.WriteLine("введите имя и зарплату сотрудника");

    Employee root = null;

    // ввод имени и зартплаты

    while (true)
    {

        Console.Write("Введите имя: ");
        var _name = Console.ReadLine();

        if (string.IsNullOrEmpty(_name))
        {
            break;
        }


        Console.Write("Введите зарплату: ");

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


    Console.WriteLine("Sorted:");
    Traverse(root);

    // поиск по зарплате

    while (true)
    {


        Console.WriteLine("Какая зарплата ищется");

        int d = int.Parse(Console.ReadLine());

        var (employee, level) = FindEmployee(root, d, level: 1);
        if (employee == null)
        {
            Console.WriteLine("Такой сотрудник не найден");
        }
        else
        {
            Console.WriteLine($"Сотрудник найден, его имя: {employee.Name}, его зарплата: {employee.Sallary}");
        }


        Console.WriteLine("для нового поиска сотрудника по зарплате введите 1, для ввода нового списка сотрудников введите 0 и 3 для выхода из программы");

        choise = int.Parse(Console.ReadLine());

        if (choise == 0 || choise == 3)
        {
            break;
        }

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
        root.Left = toAdd;
    }
    else
    {
        //Идем в правое поддерево
        if (root.Right != null) AddEmployee(root.Right, toAdd);
        root.Right = toAdd;
    }
}





public class Employee
{

    public string Name { get; set; }
    public int Sallary { get; set; }

    public Employee Left { get; set; }
    public Employee Right { get; set; }
}