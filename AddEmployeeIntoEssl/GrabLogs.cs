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
    class GrabLogs
    {


        static EsslNewEntities12 context = new EsslNewEntities12();
        static EsslEntities context2 = new EsslEntities();
        static void Main(string[] args)
        {

            AddNow();

            Console.WriteLine("\nWant to Add More");
            string add = Console.ReadLine();           
            if (add == "y")
            {
                AddNow();
            }
            else
            {
                Console.WriteLine("Ok Bye...");
                Console.Read();
                Environment.Exit(0);
            }

            Console.Read();
        }
       
        public static void AddNow()
        {
            Console.WriteLine("Employee Details \n ");
            Console.WriteLine("Enter Employee Details (EmployeeName or EmployeeCode) or exit:");
            string detail = Console.ReadLine();

            if (detail == "Exit" || detail == "exit")
                Environment.Exit(0);

            Console.WriteLine("Please  Wait... \n ");
            var FinalList = GetData(detail);

            if (FinalList != null)
            {
                Console.WriteLine("Got the Employee Details as Below... \n ");
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
                Console.WriteLine("Do u want to insert the above employee (type y or n)");
                string add = Console.ReadLine();
                bool isdone = false;
                if (add == "y")
                {
                    Console.WriteLine("Adding...");
                    isdone = AddEmployee(FinalList);
                    if (isdone)
                    {
                        var empcode = context2.Employees.Max(e => e.EmployeeId);
                        Console.WriteLine("Employee Added with code {0}", empcode);
                    }
                    else
                        Console.WriteLine("Some Exception");
                }
                else
                    Console.WriteLine("Ok Not Added");
            }
            else
                Console.Write("OOPs Not FOUND");
        }
        //public void GetNewLogs(DateTime date)
        //{
        //    var startdate = date.Date;
        //    var enddate = startdate.AddDays(1);
        //    List<int> emaillist = new List<int>();

        //    try
        //    {
        //        var result = db1.DeviceLogs.Where(q => q.LogDate >= startdate && q.LogDate < enddate).ToList();
        //        db1.DeviceLogs.RemoveRange(result);
        //        db1.SaveChanges();

        //        var LogDateMaximum = date.AddDays(1);
        //        var LogDateMinimum = date;

        //        var GetMonth = date.Month;
        //        var GetYear = date.Year;
        //        var TableName = "DeviceLogs_" + GetMonth + '_' + GetYear;

        //        var Punches = db1.DeviceLogs.Where(q => q.LogDate >= startdate && q.LogDate < enddate).ToList();
        //        var GetLogs = db1.DeviceLogDate(LogDateMinimum.ToString("yyyy/MM/dd"), LogDateMaximum.ToString("yyyy/MM/dd"), TableName).ToList();

        //        if (GetLogs.Count() > 0)
        //        {
        //            for (var i = 0; i < GetLogs.Count(); i++)
        //            {
        //                DeviceLogs log = new DeviceLogs();
        //                log.UserId = GetLogs[i].UserId;
        //                log.LogDate = GetLogs[i].LogDate;
        //                log.DownloadDate = GetLogs[i].DownloadDate;
        //                log.DeviceId = GetLogs[i].DeviceId;
        //                log.Direction = GetLogs[i].Direction;
        //                log.AttDirection = GetLogs[i].AttDirection;
        //                log.C1 = GetLogs[i].C1;
        //                log.C4 = GetLogs[i].C4;
        //                log.C5 = GetLogs[i].C5;
        //                log.WorkCode = GetLogs[i].WorkCode;
        //                db1.DeviceLogs.Add(log);
        //                db1.SaveChanges();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex.InnerException;
        //    }
        //}

    }
   
}
    
