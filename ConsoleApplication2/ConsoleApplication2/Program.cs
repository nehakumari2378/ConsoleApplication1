using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using del;

namespace ConsoleApplication2
{

    class Program
    {
        static void Main(string[] args)
        {
            //MultiCast Delegate
            multicastDel del1 = new multicastDel(Multicast.sample1);
            //multicastDel del2 = new multicastDel(Multicast.sample2);
            //multicastDel del3 = new multicastDel(Multicast.sample3);
            //multicastDel del4;
            //del4 = del1 + del2 + del3;
            //del4();
            del1 += Multicast.sample2;
            del1 += Multicast.sample3;
            del1();



            //Reusability of class using Delegate
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { Id = 101, Name = "One", Experience = 5 });
            empList.Add(new Employee() { Id = 102, Name = "Two", Experience = 4 });
            empList.Add(new Employee() { Id = 103, Name = "Three", Experience = 9 });
            empList.Add(new Employee() { Id = 104, Name = "four", Experience = 1 });

            PromoteDelegate del = new PromoteDelegate(IsPromotable);
            Employee.Promote(empList, del);
            Console.ReadLine();
        }
        public static bool IsPromotable(Employee emp)
        {
            if (emp.Experience >= 5)
                return true;
            else
                return false;
        }
    }

    delegate bool PromoteDelegate(Employee emp);
    delegate void multicastDel();
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public static void Promote(List<Employee> EmpList, PromoteDelegate IsEligible)
        {
            foreach (Employee emp in EmpList)
            {
                if (IsEligible(emp))
                    Console.WriteLine(emp.Name + " Promoted");
            }
        }
    }
}
