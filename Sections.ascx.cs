using System;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Framework.JavaScriptLibraries;
using GIBS.Modules.Columbarium.Components;
using DotNetNuke.Common.Utilities;
using GIBS.Modules.Columbarium.Data;
using System.Globalization;
using DotNetNuke.Common.Lists;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Services.Localization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DotNetNuke.UI.Utilities;
using System.Collections.Generic;
using System.Data;

namespace GIBS.Modules.Columbarium
{
    public partial class Sections : ColumbariumModuleBase
    {

        List<ColInfo> items;


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "InputMasks", (this.TemplateSourceDirectory + "/JavaScript/jquery.maskedinput-1.4.1.js"));
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "Watermark", (this.TemplateSourceDirectory + "/JavaScript/jquery.watermarkinput.js"));

            // ADD STYLESHEET FROM SETTINGS
            HtmlGenericControl css1 = new HtmlGenericControl("link");
            css1.Attributes["type"] = "text/css";
            if (Settings.Contains("jQueryUI"))
            {
                css1.Attributes["href"] = Settings["jQueryUI"].ToString();
            }
            else
            {
                css1.Attributes["href"] = "https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/redmond/jquery-ui.css";
            }
            css1.Attributes["rel"] = "stylesheet";
            css1.Attributes["media"] = "screen";
            Page.Header.Controls.Add(css1);

            // wire button event here
            if (Settings.Contains("RoleName"))
            {
                if (this.UserInfo.IsInRole(Settings["RoleName"].ToString()))
                {
                    //    lblDebug.Text = "Welcome " + this.UserInfo.DisplayName.ToString();
                }
                else
                {
                    Response.Redirect(Globals.NavigateURL(), true);
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            GetSections();
        }


        public void GetSections()
        {

            try
            {
             
                items = ColController.GetSections();

                if (items != null)
                {
                    GridView1.DataSource = items;
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    //DropDownList dp = (DropDownList)e.Row.FindControl("DropDownList1");
                    //DataTable dt = load_department();
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    ListItem lt = new ListItem();
                    //    lt.Text = dt.Rows[i][0].ToString();
                    //    dp.Items.Add(lt);
                    //}
                    //dp.SelectedValue = drv[3].ToString();
                    //RadioButtonList rbtnl = (RadioButtonList)e.Row.FindControl("RadioButtonList1");
                    //rbtnl.SelectedValue = drv[5].ToString();
                    //CheckBoxList chkb = (CheckBoxList)e.Row.FindControl("CheckBoxList2");
                    //chkb.SelectedValue = drv[6].ToString();


                    //if (e.Row.RowType == DataControlRowType.DataRow)
                    //{

                    //    string _SectionID = DataBinder.Eval(e.Row.DataItem, "SectionID").ToString();
                    //    string vLink = Globals.NavigateURL("ManageEdit", "Section", _SectionID.ToString(), "mid", this.ModuleId.ToString());
                    //    HyperLink myHyperLink = e.Row.FindControl("HyperLinkEdit") as HyperLink;
                    //    myHyperLink.NavigateUrl = vLink.ToString();


                    //}

                }

            }

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetSections();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            GetSections();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lb = (Label)GridView1.Rows[e.RowIndex].FindControl("Label6");
            DropDownList ddl = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1");
            RadioButtonList rbl = (RadioButtonList)GridView1.Rows[e.RowIndex].FindControl("RadioButtonList1");
            CheckBoxList chb = (CheckBoxList)GridView1.Rows[e.RowIndex].FindControl("CheckBoxList2");
            TextBox tx1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
            TextBox tx2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox tx3 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3");

            // NEED UPDATE COMMAND HERE
            
            //sqlcon = new SqlConnection(con);
            //sqlcon.Open();
            //string sql = "update employee set emp_name='" +
            // tx1.Text + "',emp_address='" + tx2.Text + "',salary='" +
            //    tx3.Text + "',department='" + ddl.SelectedValue.ToString()
            // + "',maritalstatus='" + rbl.SelectedValue.ToString() + "',Active_status='"
            //     + chb.SelectedValue.ToString() + "' where emp_id='" +
            //lb.Text + "'";
            //SqlCommand cmd = new SqlCommand(sql);
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = sqlcon;
            //cmd.ExecuteNonQuery();



            GridView1.EditIndex = -1;
            GetSections();

        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
            
        //    LblDebug.Text = "JOE";
        //    DataTable yourDataTable = GridView1.DataSource as DataTable;

        //    DataRow dr = yourDataTable.NewRow();
        //    yourDataTable.Rows.InsertAt(dr, 0);
        //    //Creating the first row of GridView to be Editable
        //    GridView1.EditIndex = 0;
        //    GridView1.DataSource = yourDataTable;
        //    GridView1.DataBind();

        //    // DataTable dt = new DataTable();
        //    //   GridView1.Fill(dt);
        //}




        //public void AddNewRecord()
        //{

        //    try
        //    {
        //        GetSections();
        //        DataTable yourDataTable = GridView1.DataSource as DataTable;

        //        DataRow dr = yourDataTable.NewRow();
        //        yourDataTable.Rows.InsertAt(dr, 0);
        //        //Creating the first row of GridView to be Editable
        //        GridView1.EditIndex = 0;
        //        GridView1.DataSource = yourDataTable;
        //        GridView1.DataBind();

        //    }
        //    catch (Exception ex)
        //    {
        //        Exceptions.ProcessModuleLoadException(this, ex);
        //    }

        //}

        protected void Btn_Return_Click(object sender, EventArgs e)
        {
            string vLink = Globals.NavigateURL("Manage", "mid", this.ModuleId.ToString());
            Response.Redirect(vLink.ToString(), true);
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {


        }

    }
}