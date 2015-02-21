using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class EmployeeInfoBLL
    {
        public EmployeeInfoBLL()
        {

        }
        public DataTable GetEmployeeInfoAll()
        {
            try
            {
                EmployeeInfoDAL objEmployeeInfoDAL = new EmployeeInfoDAL();
                return objEmployeeInfoDAL.GetEmployeeInfoAll();
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }
        public string SaveEmployeeInfo(EmployeeInfo objEmployeeInfo)
        {
            try
            {
                EmployeeInfoDAL objEmployeeInfoDAL = new EmployeeInfoDAL();
                return objEmployeeInfoDAL.InsertEmployeeInfo(objEmployeeInfo);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }
        public string EditEmployeeInfo(EmployeeInfo objEmployeeInfo)
        {
            try
            {
                EmployeeInfoDAL objEmployeeInfoDAL = new EmployeeInfoDAL();
                return objEmployeeInfoDAL.UpdateEmployeeInfo(objEmployeeInfo);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }
        public string RemoveEmployeeInfo(int empGid)
        {
            try
            {
                EmployeeInfoDAL objEmployeeInfoDAL = new EmployeeInfoDAL();
                return objEmployeeInfoDAL.DeleteEmployeeInfo(empGid);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }
    }
}

