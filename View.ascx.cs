/*
' Copyright (c) 2017  GIBS.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/
using GIBS.Modules.Columbarium.Components;
using GIBS.Modules.Columbarium.Data;
using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using DotNetNuke.Common;

namespace GIBS.Modules.Columbarium
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from ColumbariumModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : ColumbariumModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    FillDropDown();
                    
                    //   Settings
                    if (Settings.Contains("RoleName"))
                    {
                        if (this.UserInfo.IsInRole(Settings["RoleName"].ToString()))
                        {
                            HyperLinkManage.Visible = true;
                            HyperLinkManage.NavigateUrl = EditUrl("Manage");
                        }

                    }


                    
                                            //   Settings
                    if (Settings.Contains("WallImage"))
                    {
                        ImageWall.ImageUrl = Settings["WallImage"].ToString();
                        ImageWall.Attributes.Add("usemap", "#image-map");
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


            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
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

                lblNumberPerRow.Visible = Convert.ToBoolean(Settings["ShowPriceOnCheckout"].ToString());

                DataList1.RepeatColumns = _ItemsPerRow;
                DataList1.DataSource = items;
                DataList1.DataBind();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("Sections", LocalResourceFile), "", "", "",
                            EditUrl("Sections"), false, SecurityAccessLevel.Edit, true, false
                            //GetNextActionID(), Localization.GetString("Sections", LocalResourceFile), "", "", "",
                            //EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                actions.Add(GetNextActionID(), Localization.GetString("Niches", LocalResourceFile),
                                      "", "", "", EditUrl("Niches"), false, SecurityAccessLevel.Edit, true, false);
                return actions;
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string _NicheID = DataBinder.Eval(e.Item.DataItem, "NicheID").ToString();
                string _NicheNumber = DataBinder.Eval(e.Item.DataItem, "NicheNumber").ToString();
                string _NicheSection = DataBinder.Eval(e.Item.DataItem, "SectionName").ToString();
                string _Status = DataBinder.Eval(e.Item.DataItem, "Status").ToString();
                string _NicheSize = DataBinder.Eval(e.Item.DataItem, "NicheSize").ToString();
                Image vImage = (Image)e.Item.FindControl("vImage");

                vImage.ImageUrl = FindImage(_Status.ToString());
                vImage.Width = Int32.Parse(FindSize(_NicheSize.ToString()));
                vImage.Height = 20;
                vImage.ToolTip = "Niche Number " + _NicheNumber.ToString() + " - " + _NicheSection.ToString() + " - Niche Size: " + _NicheSize.ToString() + " Urn(s)";
                HyperLink ep = (HyperLink)e.Item.FindControl("HyperLinkBookNiche");
                string vLink = Globals.NavigateURL("Edit", "Resource", _NicheID.ToString(), "mid", this.ModuleId.ToString());

                if (_Status == "a")
                {
                    ep.NavigateUrl = vLink.ToString();
                }
                else
                {
                    ep.NavigateUrl = "javascript:void(0);";

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
                    _theImage = this.TemplateSourceDirectory + "/images/bred.gif";

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


        public string FindSize(string _size)
        {
            string _theSize = "";
            switch (_size)
            {
                case "1":
                    _theSize = "16";
                    break;
                case "2":
                    _theSize = "24";

                    break;


                default:
                    _theSize = "24";

                    break;
            }

            return _theSize.ToString();
        }

    }
}