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
                if(btnSave.Text == "Edit")
                {
                    objEmployeeInfo.EmpGid = Convert.ToInt32(this.hf_emp_gid.Value);
                    msg = objEmployeeInfoBLL.EditEmployeeInfo(objEmployeeInfo);
                }
                else
                {
                    msg = objEmployeeInfoBLL.SaveEmployeeInfo(objEmployeeInfo);
                }
                this.Load_gvEmpInfo();
                ClearForm();
                
            }
            catch(Exception exp)
            {
                msg = exp.Message;
            }
            this.lblMsg.Text = msg;

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.btnSave.Text = "Edit";
            LinkButton btnEdit = sender as LinkButton;
            int rowIndex = Convert.ToInt32(btnEdit.Attributes["RowIndex"]);
            GridViewRow gvRow = this.gvEmpInfo.Rows[rowIndex];
            int emp_gid = Convert.ToInt32(((HiddenField)gvRow.FindControl("hidemp_gid")).Value);
            this.txtEmpFullNm.Text = gvRow.Cells[0].Text;
            this.txtEmpNickName.Text = gvRow.Cells[1].Text;
            this.txtDesignation.Text = gvRow.Cells[2].Text;

            this.hf_emp_gid.Value = emp_gid.ToString();
        }
        protected void btnDelete_Click(object sender,EventArgs e)
        {
            LinkButton btnDelete = sender as LinkButton;
            int rowIndex = Convert.ToInt32(btnDelete.Attributes["RowIndex"]);
            GridViewRow gvRow = this.gvEmpInfo.Rows[rowIndex];
            int emp_gid = Convert.ToInt32(((HiddenField)gvRow.FindControl("hidemp_gid")).Value);
            string msg = string.Empty;
            try
            {
                EmployeeInfoBLL objEmployeeInfoBLL = new EmployeeInfoBLL();
                msg = objEmployeeInfoBLL.RemoveEmployeeInfo(emp_gid);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
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