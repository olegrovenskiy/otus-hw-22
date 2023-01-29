
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

while (true)

{
    int variation;

    bool textCheck = false;



    Console.WriteLine("введите имя и зарплату сотрудника");

    Employee root = null;

    while (true)
    {

        Console.Write("Введите имя: ");
        var _name = Console.ReadLine();

        textCheck = string.IsNullOrEmpty(_name);

        if (textCheck)
        {
            break;
        }


        Console.Write("Введите зарплату: ");
        var s = Console.ReadLine();
        var d = int.Parse(s);

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



    while (true)
    {


        Console.WriteLine("Какая зарплата ищется");

        var s = Console.ReadLine();

        int d = int.Parse(s);


        var (employee, level) = FindEmployee(root, d, level: 1);
        if (employee == null)
        {
            Console.WriteLine("Такой сотрудник не найден");
        }
        else
        {
            Console.WriteLine($"Сщтрудник найден, его имя:   {employee.Name}, его зарплата:   {employee.Sallary}, level: {level}");
        }


        Console.WriteLine("для нового поиска сотрудника по зарплате введите 1, для ввода нового списка сотрудников введите 0");

        variation = int.Parse(Console.ReadLine());

        if (variation == 0)
        {
            break;
        }

        if (variation == 1)
        {
            continue;
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








static void Traverse(Employee originiEmployee)
{

    if (originiEmployee.Left != null)
    {
        Traverse(originiEmployee.Left);
    }

    Console.Write(originiEmployee.Name);
    Console.WriteLine(originiEmployee.Sallary);

    if (originiEmployee.Right != null)
    {
        Traverse(originiEmployee.Right);
    }
}
















static void AddEmployee(Employee root, Employee toAdd)
{
    if (toAdd.Sallary < root.Sallary)
    {
        //Идем в левое поддерево
        if (root.Left != null)
        {
            AddEmployee(root.Left, toAdd);
        }
        else
        {
            root.Left = toAdd;
        }
    }
    else
    {
        //Идем в правое поддерево
        if (root.Right != null)
        {
            AddEmployee(root.Right, toAdd);
        }
        else
        {
            root.Right = toAdd;
        }
    }
}











public class Employee
{

    public string Name { get; set; }
    public int Sallary { get; set; }

    public Employee Left { get; set; }
    public Employee Right { get; set; }
}