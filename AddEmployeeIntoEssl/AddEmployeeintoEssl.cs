using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


using System.Linq.Expressions;
using System.Reflection;

namespace AddEmployeeIntoEssl
{
    class AddEmployeeintoEssl
    {                
        static void Main(string[] args)
        {
            CallAgain();
        }
        static void CallAgain()
        {
            AddNow();
            W("\nWant to Add Other");
            string add = Console.ReadLine();
            if (add == "y")
            {
                AddNow();
            }
            else
            {
                W("Ok Bye...");
                Console.Read();
                Environment.Exit(0);
            }
            Console.Read();
        }                
        public static void AddNow()
        {
            W("Employee Details \n ");
            W("Enter Employee Details (EmployeeName or EmployeeCode) or exit:");
            string detail = Console.ReadLine();

            if (detail == "Exit" || detail == "exit")
                Environment.Exit(0);

            W("Please  Wait... \n ");
            var FinalList = NewEmployees.GetData(detail);

            if (FinalList != null)
            {
                W("Got the Employee Details as Below... \n ");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(FinalList))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(FinalList);
                    if (value != null)
                    {
                        if (value.ToString() != "")
                            Console.WriteLine("{0}", value);
                    }

                }
                W("Do u want to insert the above employee (type y or n)");
                string add = Console.ReadLine();
                bool isdone = false;
                if (add == "y")
                {
                    W("Adding...");
                    isdone = NewEmployees.AddEmployee(FinalList);
                    if (isdone)
                    {
                        var empcode = NewEmployees.GetEmployeeCode();
                        Console.WriteLine("Employee Added with code {0}", empcode);
                    }
                    else
                    {
                        W("Some Exception");
                        CallAgain();
                    }
                }
                else
                {
                    W("Ok Not Added");
                    CallAgain();
                }

                }
            else
            {
                W("OOPs Not FOUND");
                CallAgain();
            }
        }
        static void W(string line)
        {
            Console.WriteLine(line);
        }            
    }   
}
    
