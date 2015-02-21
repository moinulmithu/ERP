using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class EmployeeInfoDAL
    {
        private SqlConnection sqlConn;
        private SqlCommand cmd;
        private readonly DBConnector objDBConnector;

        ///
        /// Constructor
        ///

        public EmployeeInfoDAL()
        {
            objDBConnector = new DBConnector();
            sqlConn = objDBConnector.GetConn();
            cmd = objDBConnector.GetCommand();
        }

        ///
        /// Get all employee information
        ///
        ///

        public DataTable GetEmployeeInfoAll()
        {
            DataTable tblEmpInfo = new DataTable();
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT emp_gid, emp_fullnm, emp_nicknm, emp_designation FROM hrm_employee";

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                rdr = cmd.ExecuteReader();
                tblEmpInfo.Load(rdr);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            return tblEmpInfo;

        }

        ///
        /// Insert Employee information
        ///
        ///
        ///

        public string InsertEmployeeInfo(EmployeeInfo objEmployeeInfo)
        {
            string msg = String.Empty;

            int noOfRowEffected = 0;

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO hrm_employee(emp_fullnm , emp_nicknm , emp_designation)"
                + " VALUES('" + objEmployeeInfo.EmpFullName + "','" + objEmployeeInfo.EmpNickName + "','" + objEmployeeInfo.EmpDesignation + "')";

                noOfRowEffected = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            if (noOfRowEffected > 0)
                return "Employee information saved successfully!";
            else
                return msg;
        }

        ///
        /// Update employee information
        ///
        ///
        ///

        public string UpdateEmployeeInfo(EmployeeInfo objEmployeeInfo)
        {
            string msg = String.Empty;

            int noOfRowEffected = 0;

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE hrm_employee SET emp_fullnm = '" + objEmployeeInfo.EmpFullName +
                "',emp_nicknm = '" + objEmployeeInfo.EmpNickName + "', emp_designation = '" + objEmployeeInfo.EmpDesignation
                + "' WHERE emp_gid = " + objEmployeeInfo.EmpGid;

                noOfRowEffected = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            if (noOfRowEffected > 0)
                return "Employee information updated successfully!";
            else
                return msg;
        }

        ///
        /// Delete employee information
        ///
        ///
        ///

        public string DeleteEmployeeInfo(int empGid)
        {
            string msg = String.Empty;

            int noOfRowEffected = 0;

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM hrm_employee"
                + " WHERE emp_gid = " + empGid;

                noOfRowEffected = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            if (noOfRowEffected > 0)
                return "Employee information deleted successfully!";
            else
                return msg;
        }
    }
}
            
