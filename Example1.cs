using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDExample
{
   

    #region SRP
    //public class Employee
    //{
    //    public int Employee_Id { get; set; }
    //    public string Employee_Name { get; set; }

    //    /// <summary>
    //    /// This method used to insert into employee table
    //    /// </summary>
    //    /// <param name="em">Employee object</param>
    //    /// <returns>Successfully inserted or not</returns>
    //    public bool InsertIntoEmployeeTable(Employee em)
    //    {
    //        // Insert into employee table.
    //        return true;
    //    }
    //    /// <summary>
    //    /// Method to generate report
    //    /// </summary>
    //    /// <param name="em"></param>
    //    /// SRP Violation
    //    //public void GenerateReport(Employee em)
    //    //{
    //    //    // Report generation with employee data using crystal report.
    //    //}
    //}

    //SRP Correction
    //public class ReportGeneration
    //{
    //    /// <summary>
    //    /// Method to generate report
    //    /// </summary>
    //    /// <param name="em"></param>
    //    public void GenerateReport(Employee em)
    //    {
    //        // Report reneration with employee data.
    //    }
    //}
    #endregion

    #region OCP
    public class IReportGeneration
    {
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public virtual void GenerateReport(Employee em)
        {
            // From base
        }
    }
    /// <summary>
    /// Class to generate Crystal report
    /// </summary>
    public class CrystalReportGeneraion : IReportGeneration
    {
        public override void GenerateReport(Employee em)
        {
            // Generate crystal report.
        }
    }
    /// <summary>
    /// Class to generate PDF report
    /// </summary>
    public class PDFReportGeneraion : IReportGeneration
    {
        public override void GenerateReport(Employee em)
        {
            // Generate PDF report.
        }
    }

#endregion

    # region LSP
    public interface IEmployee
    {
        string GetEmployeeDetails(int employeeId);
    }
    public interface IProject
    {
        string GetProjectDetails(int employeeId);
    }
    public abstract class Employee
    {
        public virtual string GetProjectDetails(int employeeId)
        {
            return "Base Project";
        }
        public virtual string GetEmployeeDetails(int employeeId)
        {
            return "Base Employee";
        }
    }
    public class CasualEmployee : IEmployee,IProject
    {
        //public override string GetProjectDetails(int employeeId)
        //{
        //    return "Child Project";
        //}
        //// May be for contractual employee we do not need to store the details into database.
        //public override string GetEmployeeDetails(int employeeId)
        //{
        //    return "Child Employee";
        //}
        public  string GetProjectDetails(int employeeId)
        {
            return "Child Project";
        }
        // May be for contractual employee we do not need to store the details into database.
        public  string GetEmployeeDetails(int employeeId)
        {
            return "Child Employee";
        }
    }
    public class ContractualEmployee : IProject
    {
        //public override string GetProjectDetails(int employeeId)
        //{
        //    return "Child Project";
        //}
        // May be for contractual employee we do not need to store the details into database.
        //public override string GetEmployeeDetails(int employeeId)
        //{
        //    throw new NotImplementedException();
        //}
        public  string GetProjectDetails(int employeeId)
        {
            return "Child Project";
        }
    }
    
    #endregion

    #region ISP
    public interface IAddOperation
    {
        bool AddEmployeeDetails();
    }
    public interface IGetOperation
    {
        string ShowEmployeeDetails(int employeeId);
    }

    public class CasualEmployeeISP : IAddOperation, IGetOperation
    {
       public bool AddEmployeeDetails()
        {
            return true;
        }
        public string ShowEmployeeDetails(int employeeId)
        {
            return "Employee Details";
        }
    }
    public class ContractualEmployeeISP : IAddOperation
    {
        public bool AddEmployeeDetails()
        {
            return true;
        }  
    }

    #endregion

    #region DependencyInversionPrinciple

    public interface IMessenger
    {
        void SendMessage();
    }
    public class Email : IMessenger
    {
        public void SendMessage()
        {
            // code to send email
        }
    }

    public class SMS : IMessenger
    {
        public void SendMessage()
        {
            // code to send SMS
        }
    }

    public class Notification
    {
        private IMessenger _iMessenger;
        public Notification()
        {
            _iMessenger = new Email();

        }
        public void DoNotify()
        {
            _iMessenger.SendMessage();

        }
    }

    #region Constructor Injection   
    //public class Notification
    //{
    //    private IMessenger _iMessenger;
    //    public Notification(IMessenger pMessenger)
    //    {
    //        _iMessenger = pMessenger;         
    //    }
    //    public void DoNotify()
    //   {
    //        _iMessenger.SendMessage();     
    //   }
    //}
     #endregion

    #region Property Injection
//    public class Notification
//{
//    private IMessenger _iMessenger;

//    public Notification()
//    {
//    }
//    public IMessenger MessageService
//    {
//       private get;
//       set
//       {
//           _iMessenger = value;
//       }
//     }

//    public void DoNotify()
//    {
//        _iMessenger.SendMessage();
//    }
//}
    
    #endregion

    #region Method Injection
    //public class Notification
    //{
    //    public void DoNotify(IMessenger pMessenger)
    //    {
    //        pMessenger.SendMessage();
    //    }
    //}
    #endregion
    
    #endregion

}
