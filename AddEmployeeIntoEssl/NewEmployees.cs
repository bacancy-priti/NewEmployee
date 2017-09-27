using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddEmployeeIntoEssl
{
    class NewEmployees
    {
        static EsslNewEntities12 context = new EsslNewEntities12();
        static EsslEntities context2 = new EsslEntities();
        public static bool AddEmployee(Employees details)
        {
            bool isAdded = false;
            try
            {
                Employee newemp = new Employee
                {
                    EmployeeName = details.EmployeeName,
                    EmployeeCode = details.EmployeeCode,
                    NumericCode = details.NumericCode,
                    DOJ = details.DOJ,
                    Location = details.Location ?? "L",
                    Grade = details.Grade ?? "G",
                    Gender = details.Gender,
                    CompanyId = details.CompanyId,
                    DepartmentId = details.DepartmentId,
                    Designation = details.Designation,
                    CategoryId = details.CategoryId,
                    EmployeeCodeInDevice = details.EmployeeCodeInDevice,
                    EmployementType = details.EmployementType,
                    Status = details.Status,
                    EmployeeDeviceGroup = details.EmployeeDeviceGroup,
                    RecordStatus = details.RecordStatus,
                    HolidayGroup = details.HolidayGroup,
                    ShiftGroupId = details.ShiftGroupId,
                    ShiftRosterId = details.ShiftGroupId,
                    LastModifiedBy = details.LastModifiedBy,
                    Team = details.Team ?? "T",
                    StringCode = details.StringCode,
                    DOR = details.DOR,
                    DOC = details.DOC,
                    EmployeeDevicePassword = details.EmployeeDevicePassword,
                    FatherName = details.FatherName,
                    MotherName = details.MotherName,
                    ResidentialAddress = details.ResidentialAddress,
                    PermanentAddress = details.PermanentAddress,
                    ContactNo = details.ContactNo,
                    Email = details.Email,
                    DOB = details.DOB,
                    PlaceOfBirth = details.PlaceOfBirth,
                    Nomenee1 = details.Nomenee1,
                    Nomenee2 = details.Nomenee2,
                    Remarks = details.Remarks,
                };
                context2.Employees.Add(newemp);
                context2.SaveChanges();
                isAdded = true;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return isAdded;
        }
        public static Employees GetData(string name)
        {
            Employees emp = new Employees();
            int empcode;
            bool isNumeric = int.TryParse(name, out empcode);
            if (isNumeric)
                emp = context.Employees.Where(e => e.EmployeeCode == name).FirstOrDefault();
            else
                emp = context.Employees.Where(e => e.EmployeeName.Contains(name)).FirstOrDefault();
            return emp;
        }
        public static int GetEmployeeCode()
            {
             return context2.Employees.Max(e => e.EmployeeId);
            }
    }
}
