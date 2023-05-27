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
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace GIBS.Modules.Columbarium
{
    public partial class Manage : ColumbariumModuleBase
    {



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

            try
            {
              //  Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "Watermark", (this.TemplateSourceDirectory + "/JavaScript/jquery.watermarkinput.js"));

                if (!IsPostBack)
                {
                    FillDropDown();

                    //   Settings

                    if (Settings.Contains("WallImage"))
                    {
                        ImageWall.ImageUrl = Settings["WallImage"].ToString();
                        ImageWall.Attributes.Add("usemap", "#image-map");
                    }
                    else
                    {

                        ImageWall.Visible = false;
                    }

                    if (Request.QueryString["DisplaySection"] != null)
                    {
                        int _WhatSection = Int32.Parse(Request.QueryString["DisplaySection"].ToString());
                        GetSection(_WhatSection);
                        ddlDisplaySection.SelectedValue = _WhatSection.ToString();
                    }
                    else
                    {
                        GetSection(1);
                    }

                }
                else
                {
                    //
                  //  lblDebug.Text = "postback";
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        public void FillDropDown()
        {

            try
            {
                // CreatePrefixSuffixDropdowns();

                List<ColInfo> items;
                //  ColController controller = new ColController();


                items = ColController.GetSections();


                ddlDisplaySection.DataTextField = "SectionName";
                ddlDisplaySection.DataValueField = "SectionID";
                ddlDisplaySection.DataSource = items;
                ddlDisplaySection.DataBind();
                //      ddlDisplaySection.Items.Insert(0, new ListItem("-- Select --", "0"));


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }



        //
        public void GetSection(int _DisplaySection)
        {

            try
            {

                List<ColInfo> items;
                items = ColController.GetDisplaySection(_DisplaySection);

                ImageNicheSection.ImageUrl = Settings["ImagePath"].ToString() + items[0].Photo.ToString();
                ImageNicheSection.AlternateText = "Niche " + items[0].SectionName.ToString();

                lblSectionTitle.Text = "Niche " + items[0].SectionName.ToString();


                var _NumRows = items[0].NumberOfRows.ToString();

                int _ItemsPerRow = items.Count / Int32.Parse(_NumRows.ToString());

                lblTotalNiches.Text = "TOTAL NICHES THIS SECTION: " + items.Count.ToString();
                lblNumberPerRow.Text = "NUMBER PER ROW: " + _ItemsPerRow.ToString();

                DataList1.RepeatColumns = _ItemsPerRow;
                DataList1.DataSource = items;
                DataList1.DataBind();

                GridView1.DataSource = items;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string _NicheID = DataBinder.Eval(e.Item.DataItem, "NicheID").ToString();
                string _NicheNumber = DataBinder.Eval(e.Item.DataItem, "NicheNumber").ToString();
              //  string _NicheSection = DataBinder.Eval(e.Item.DataItem, "NicheSection").ToString();
                string _SectionName = DataBinder.Eval(e.Item.DataItem, "SectionName").ToString();
                string _Status = DataBinder.Eval(e.Item.DataItem, "Status").ToString();
                Image vImage = (Image)e.Item.FindControl("vImage");

                vImage.ImageUrl = FindImage(_Status.ToString());
                vImage.ToolTip = "Niche Number " + _NicheNumber.ToString() + " - " + _SectionName.ToString();
                HyperLink ep = (HyperLink)e.Item.FindControl("HyperLinkBookNiche");
                string vLink = Globals.NavigateURL("Edit", "Resource", _NicheID.ToString(), "mid", this.ModuleId.ToString());
                string adminLink = Globals.NavigateURL("ManageEdit", "Resource", _NicheID.ToString(), "mid", this.ModuleId.ToString());

                if (_Status == "a")
                {
                    ep.NavigateUrl = vLink.ToString();
                }
                else if (_Status == "p")
                {

                    ep.NavigateUrl = adminLink.ToString();
                }
                else
                {
                    ep.NavigateUrl = adminLink.ToString();

                }




            }
        }

        protected void ddlDisplaySection_TextChanged(object sender, EventArgs e)
        {
            GetSection(Int32.Parse(ddlDisplaySection.SelectedValue.ToString()));
        }

        public string FindImage(string _status)
        {
            string _theImage = "";
            switch (_status)
            {
                case "a":
                    _theImage = this.TemplateSourceDirectory + "/images/bgreen.gif";
                    break;
                case "p":
                    _theImage = this.TemplateSourceDirectory + "/images/byellow.gif";

                    break;
                case "s":
                    _theImage = this.TemplateSourceDirectory + "/images/bred.gif";
                    break;

                default:
                    _theImage = this.TemplateSourceDirectory + "/images/bgreen.gif";

                    break;
            }

            return _theImage.ToString();
        }



        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            //    lblDebug.Text = "Searching . . .";
            WallAndImages.Visible = false;
            List<ColInfo> items;
            items = ColController.Search(txtLastName.Text.ToString());
            GridView1.DataSource = items;
            GridView1.DataBind();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string _NicheID = DataBinder.Eval(e.Row.DataItem, "NicheID").ToString();
                string vLink = Globals.NavigateURL("ManageEdit", "Resource", _NicheID.ToString(), "mid", this.ModuleId.ToString());
                HyperLink myHyperLink = e.Row.FindControl("HyperLinkEdit") as HyperLink;
                myHyperLink.NavigateUrl = vLink.ToString();
            }

        } 

        protected void Btn_Restore_Click(object sender, EventArgs e)
        {
            WallAndImages.Visible = true;
            txtLastName.Text = "";
            GetSection(1);
        }

        protected void LinkButtonShowPending_Click(object sender, EventArgs e)
        {
            WallAndImages.Visible = false;
            List<ColInfo> items;
            items = ColController.SearchPending();
            GridView1.DataSource = items;
            GridView1.DataBind();
          //  lblDebug.Text = "JUST CHECKING";
        }

        protected void Btn_ExitAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL(), true);
        }

        //protected void ButtonShowPending_Click(object sender, EventArgs e)
        //{
        //    WallAndImages.Visible = false;
        //    List<ColInfo> items;
        //    items = ColController.SearchPending();
        //    GridView1.DataSource = items;
        //    GridView1.DataBind();
        //    lblDebug.Text = "JUST CHECKING";
        //}
    }
}