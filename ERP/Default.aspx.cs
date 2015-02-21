using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_gvEmpInfo();
            }
        }
        private void Load_gvEmpInfo() 
        {
            EmployeeInfoBLL objEmployeeInfoBLL = new EmployeeInfoBLL();
            gvEmpInfo.DataSource = objEmployeeInfoBLL.GetEmployeeInfoAll();
            gvEmpInfo.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            EmployeeInfo objEmployeeInfo = new EmployeeInfo();
            objEmployeeInfo.EmpFullName = this.txtEmpFullNm.Text;
            objEmployeeInfo.EmpNickName = this.txtEmpNickName.Text;
            objEmployeeInfo.EmpDesignation = this.txtDesignation.Text;
            EmployeeInfoBLL objEmployeeInfoBLL = new EmployeeInfoBLL();

            try
            {
                msg = objEmployeeInfoBLL.SaveEmployeeInfo(objEmployeeInfo);
                this.Load_gvEmpInfo();
                ClearForm();
            }
            catch(Exception exp)
            {
                msg = exp.Message;
            }
            this.lblMsg.Text = msg;

        }
        private void ClearForm()
        {
            this.txtEmpFullNm.Text = string.Empty;
            this.txtEmpNickName.Text = string.Empty;
            this.txtDesignation.Text = string.Empty;
        }
        
        
    }
}