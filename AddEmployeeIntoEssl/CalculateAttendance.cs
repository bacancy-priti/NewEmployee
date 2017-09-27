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
    class CalculateAttendance
    {


        //static EsslNewEntities12 context = new EsslNewEntities12();
        //static EsslEntities context2 = new EsslEntities();
        //static void Main(string[] args)
        //{

        //    AddNow();

        //    Console.WriteLine("\nWant to Add Attendance");
        //    string add = Console.ReadLine();           
        //    if (add.ToLower() == "y")
        //    {
        //        Console.WriteLine("For One Date (y or n)");
        //        var date=Console.ReadLine();
        //        if ( date.ToLower()== "y")
        //        {                   
        //            AddNow();
        //        }
        //        else
        //        {
        //            Console.WriteLine("Ok Bye...");
        //            Console.Read();
        //            Environment.Exit(0);
        //        }
        //        AddNow();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ok Bye...");
        //        Console.Read();
        //        Environment.Exit(0);
        //    }

        //    Console.Read();
        //}

       
       
        //public static void AddNow()
        //{
        //    Console.WriteLine("For One Date");
        //    var date1 = Console.ReadLine();
        //    Console.WriteLine("Employee Details \n ");
        //    Console.WriteLine("Enter Employee Details (EmployeeName or EmployeeCode) or exit:");
        //    string detail = Console.ReadLine();

        //    if (detail == "Exit" || detail == "exit")
        //        Environment.Exit(0);

        //    Console.WriteLine("Please  Wait... \n ");
        //    var FinalList = GetData(detail);

            
        //        Console.WriteLine("Do u want to insert the above employee (type y or n)");
        //        string add = Console.ReadLine();
        //        bool isdone = false;
        //        if (add == "y")
        //        {
        //            Console.WriteLine("Adding...");
        //            isdone = EmployeePunch(FinalList);
        //            if (isdone)
        //            {
        //                var empcode = context2.Employees.Max(e => e.EmployeeId);
        //                Console.WriteLine("Employee Added with code {0}", empcode);
        //            }
        //            else
        //                Console.WriteLine("Some Exception");
        //        }
        //        else
        //            Console.WriteLine("Ok Not Added");
            
        //}
        //public void EmployeePunch(DateTime date,DateTime Date2)
        //{
        //    var enddate = date.Date;
        //    var startdate = enddate.AddDays(-1);
        //    List<int> emaillist = new List<int>();

        //    try
        //    {
        //        var result = db.AttendanceMaster.Where(q => q.AttendanceDate >= startdate && q.AttendanceDate < enddate).ToList();
        //        db.AttendanceMaster.RemoveRange(result);
        //        db.SaveChanges();

        //        var holidays = db.HolidayMaster.Where(q => q.HolidayDate >= startdate && q.HolidayDate < enddate).Count();
        //        var Punches = db1.DeviceLogs.Where(q => q.LogDate >= startdate && q.LogDate < enddate).ToList();
        //        var offlineHours = db.OfflineHoursMaster.Where(f => f.ForDate >= startdate && f.ForDate < enddate).ToList();
        //        var Employees = db1.Employees.ToList();
        //        var EmployeesMasters = db.EmployeeMasters.Where(e => e.EmployeeIsActive == true).ToList();
        //        var AllEmployeees = (from myemp in EmployeesMasters.ToList()
        //                             join deviceemp in Employees.ToList()
        //                             on myemp.EmployeeCode equals deviceemp.EmployeeId.ToString()
        //                             select new
        //                             {
        //                                 Id = myemp.Id,
        //                                 EmployeId = myemp.EmployeeCode,
        //                                 EmployeCode = deviceemp.EmployeeCode
        //                             }).ToList();

        //        DateTime InDate = DateTime.MinValue;
        //        DateTime TempDate = DateTime.MinValue;

        //        if (Punches.Count() > 0 || offlineHours.Count() > 0)
        //        {
        //            foreach (var Employee in AllEmployeees)
        //            {
        //                AttendanceMaster attendance = new AttendanceMaster();
        //                var EmpId = Employee.Id;// example: 7136
        //                var employeeId = Convert.ToInt32(Employee.EmployeId);// example:2622
        //                var employeeCode = Employee.EmployeCode; //example :79
        //                attendance.EmployeeId = EmpId;
        //                attendance.AttendanceDate = startdate;
        //                attendance.Duration = 0;
        //                var punch = Punches.Where(q => q.UserId == employeeCode).OrderBy(d => d.LogDate).ToList();
        //                var offlineHoursList = offlineHours.Where(o => o.EmployeeId == EmpId).ToList();

        //                if (punch.Count % 2 != 0)
        //                {
        //                    var CheckCount = (from p in punch
        //                                      group p by p.LogDate.Value.ToString("dd/MM/yyyy hh:mm") into grouped
        //                                      select new
        //                                      {
        //                                          LogDate = grouped.Select(c => c.LogDate).FirstOrDefault(),
        //                                          Count = grouped.Count()
        //                                      }).ToList();
        //                    foreach (var list in CheckCount)
        //                    {
        //                        if (list.Count > 2)
        //                        {
        //                            var GetAll = (from p in punch.Where(c => c.LogDate.Value.ToString("dd/MM/yyyy hh:mm") == list.LogDate.Value.ToString("dd/MM/yyyy hh:mm")).ToList()
        //                                          select new DeviceLogs
        //                                          {
        //                                              DeviceLogId = p.DeviceLogId,
        //                                              LogDate = p.LogDate,
        //                                          }).OrderBy(l => l.LogDate).ToList();

        //                            var firstNearestTime = GetAll.Min(d => d.LogDate);
        //                            var lastNearestTime = GetAll.Max(d => d.LogDate);

        //                            GetAll = GetAll.Where(g => g.LogDate > firstNearestTime && g.LogDate < lastNearestTime).ToList();
        //                            foreach (var id in GetAll)
        //                            {
        //                                var Id = id.DeviceLogId;
        //                                punch.Remove(punch.Where(p => p.DeviceLogId == Id).FirstOrDefault());
        //                            }
        //                        }
        //                    }
        //                }
        //                if (punch.Count % 2 != 0)
        //                {
        //                    punch = (from p in punch
        //                             group p by p.LogDate.Value.ToString("dd/MM/yyyy hh:mm") into grouped
        //                             select new DeviceLogs
        //                             {
        //                                 LogDate = grouped.Select(c => c.LogDate).FirstOrDefault(),
        //                             }).ToList();
        //                }
        //                if (punch.Count % 2 != 0)
        //                    punch.RemoveAt(punch.Count - 1);

        //                if (punch.Count > 0)
        //                {
        //                    attendance.TimeIn = punch[0].LogDate;
        //                    attendance.TimeOut = punch[punch.Count - 1].LogDate;
        //                    TempDate = new DateTime(punch[punch.Count - 1].LogDate.Value.Year, punch[punch.Count - 1].LogDate.Value.Month, punch[punch.Count - 1].LogDate.Value.Day, punch[punch.Count - 1].LogDate.Value.Hour, punch[punch.Count - 1].LogDate.Value.Minute, 00);
        //                    InDate = new DateTime(punch[0].LogDate.Value.Year, punch[0].LogDate.Value.Month, punch[0].LogDate.Value.Day, punch[0].LogDate.Value.Hour, punch[0].LogDate.Value.Minute, 00);
        //                    attendance.TotalTime = (int)(TempDate.Subtract(InDate).TotalMinutes);
        //                }
        //                for (int i = 0; i < punch.Count; i++)
        //                {
        //                    if (i % 2 != 0)
        //                    {
        //                        TempDate = new DateTime(punch[i].LogDate.Value.Year, punch[i].LogDate.Value.Month, punch[i].LogDate.Value.Day, punch[i].LogDate.Value.Hour, punch[i].LogDate.Value.Minute, 00);
        //                        attendance.Duration += (int)TempDate.Subtract(InDate).TotalMinutes;
        //                    }
        //                    InDate = new DateTime(punch[i].LogDate.Value.Year, punch[i].LogDate.Value.Month, punch[i].LogDate.Value.Day, punch[i].LogDate.Value.Hour, punch[i].LogDate.Value.Minute, 00);
        //                }
        //                attendance.Break = attendance.TotalTime - attendance.Duration;
        //                if (attendance.Duration == 0)
        //                {
        //                    attendance.Break = 0;
        //                    attendance.TotalTime = 0;
        //                }
        //                if (offlineHoursList.Count() != 0)
        //                {
        //                    attendance.OfflineHours = offlineHoursList.Where(o => o.ForDate >= startdate && o.ForDate < enddate).ToList().Sum(o => o.Duration).Value;
        //                }
        //                else
        //                {
        //                    attendance.OfflineHours = 0;
        //                }
        //                if (holidays == 0)
        //                {
        //                    db.AttendanceMaster.Add(attendance);
        //                    db.SaveChanges();
        //                }
        //                //if (attendance.Break > 90)
        //                //{
        //                //    emaillist.Add(attendance.EmployeeId);                        
        //                //}
        //                //SendEmail(emaillist);
        //            }
        //            db.SaveChanges();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex.InnerException;
        //    }

        //}
    }
   
}
    
