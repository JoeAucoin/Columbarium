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

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using System.Collections;
using System.Web.UI.WebControls;
using DotNetNuke.Services.FileSystem;

namespace GIBS.Modules.Columbarium
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from ColumbariumSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : ColumbariumModuleSettingsBase
    {
        #region Base Method Implementations

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    GetPortalRoles();

                    if (EnableDiscount != null)
                    {
                        if (EnableDiscount.ToString().Length > 0)
                        {
                            CbxEnableDiscount.Checked = Convert.ToBoolean(EnableDiscount.ToString());
                        }
                    }

                    if (ShowPriceOnCheckout != null)
                    {
                        if (ShowPriceOnCheckout.ToString().Length > 0)
                        {
                            CbxShowPriceOnCheckout.Checked = Convert.ToBoolean(ShowPriceOnCheckout.ToString());
                        }
                    }

                    if (DisplayRemains != null)
                    {
                        if (DisplayRemains.ToString().Length > 0)
                        {
                            CbxDisplayRemains.Checked = Convert.ToBoolean(DisplayRemains.ToString());
                        }
                    }

                    if (RoleName != null)
                    {
                        ddlRoles.SelectedValue = RoleName;
                    }
                    if (PageSize > 0)
                    {
                        ddlPageSize.SelectedValue = PageSize.ToString();
                    }
                    if (EmailMessage != null)
                    {
                        txtEmailMessage.Text = EmailMessage;
                    }
                    if (EmailFrom != null)
                    {
                        txtEmailFrom.Text = EmailFrom;
                    }

                    if (EmailNotify != null)
                    {
                        txtEmailNotify.Text = EmailNotify;
                    }

                    if (EmailBCC != null)
                    {
                        txtEmailBCC.Text = EmailBCC;
                    }

                    if (EmailSubject != null)
                    {
                        txtEmailSubject.Text = EmailSubject;
                    }



                    if (ReportServerURL != null)
                    {
                        txturlReportServer.Text = ReportServerURL.ToString();
                    }

                    if (ReportPath != null)
                    {
                        txtReportPath.Text = ReportPath.ToString();
                    }

                    if (ReportCredentialsUserName != null)
                    {
                        txtRSCredentialsUserName.Text = ReportCredentialsUserName.ToString();
                    }

                    if (ReportCredentialsPassword != null)
                    {

                        txtRSCredentialsPassword.Text = ReportCredentialsPassword.ToString();
                    }
                    if (ReportCredentialsDomain != null)
                    {
                        txtRSCredentialsDomain.Text = ReportCredentialsDomain.ToString();
                    }
                    if (jQueryUI != null)
                    {
                        txtjQueryUI.Text = jQueryUI.ToString();
                    }

                    if (ImagePath != null)
                    {
                        txtImagePath.Text = ImagePath.ToString();
                    }

                    if (WallImage != null)
                    {
                        txtWallImage.Text = WallImage.ToString();
                    }

                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public void GetPortalRoles()
        {
            ArrayList list = DotNetNuke.Security.Roles.RoleProvider.Instance().GetRoles(this.PortalId);

            ddlRoles.DataSource = list;
            ddlRoles.DataBind();

            // ADD FIRST (NULL) ITEM
            ListItem item = new ListItem();
            item.Text = "-- Select Manager Role --";
            item.Value = "";
            ddlRoles.Items.Insert(0, item);
            // REMOVE DEFAULT ROLES
            ddlRoles.Items.Remove("Administrators");
            ddlRoles.Items.Remove("Registered Users");
            ddlRoles.Items.Remove("Subscribers");

        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                var image = (DotNetNuke.Services.FileSystem.FileInfo)FileManager.Instance.GetFile(fpPictureWallImage.FileID);
                string vWallImage = "";
                string vImagePath = "";
                if (image != null)
                {
                    vWallImage =  FileManager.Instance.GetUrl(image);
                    vImagePath = image.Folder.ToString();
                }
                else
                {
                    
                    vWallImage = txtWallImage.Text.ToString();
                    vImagePath = txtImagePath.Text.ToString();
                }


                var modules = new ModuleController();

                //the following are two sample Module Settings, using the text boxes that are commented out in the ASCX file.
                //module settings
                //modules.UpdateModuleSetting(ModuleId, "Setting1", txtSetting1.Text);
                //modules.UpdateModuleSetting(ModuleId, "Setting2", txtSetting2.Text);

                //tab module settings
                //modules.UpdateTabModuleSetting(TabModuleId, "Setting1",  txtSetting1.Text);
                //modules.UpdateTabModuleSetting(TabModuleId, "Setting2",  txtSetting2.Text);

                modules.UpdateModuleSetting(ModuleId, "RoleName", ddlRoles.SelectedValue.ToString());
                modules.UpdateModuleSetting(ModuleId, "jQueryUI",txtjQueryUI.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "PageSize", ddlPageSize.SelectedValue.ToString());
                modules.UpdateModuleSetting(ModuleId, "EmailFrom", txtEmailFrom.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "EmailNotify", txtEmailNotify.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "EmailBCC", txtEmailBCC.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "EmailSubject", txtEmailSubject.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "EmailMessage", txtEmailMessage.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "ReportServerURL", txturlReportServer.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "ReportPath", txtReportPath.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "ReportCredentialsUserName", txtRSCredentialsUserName.ToString());
                modules.UpdateModuleSetting(ModuleId, "ReportCredentialsPassword", txtRSCredentialsPassword.Text.ToString());
                modules.UpdateModuleSetting(ModuleId, "ReportCredentialsDomain", txtRSCredentialsDomain.Text.ToString());

                modules.UpdateModuleSetting(ModuleId, "WallImage", vWallImage.ToString());
                modules.UpdateModuleSetting(ModuleId, "ImagePath", vImagePath.ToString());

                modules.UpdateModuleSetting(ModuleId, "ShowPriceOnCheckout", CbxShowPriceOnCheckout.Checked.ToString());
                modules.UpdateModuleSetting(ModuleId, "DisplayRemains", CbxDisplayRemains.Checked.ToString());
                modules.UpdateModuleSetting(ModuleId, "EnableDiscount", CbxEnableDiscount.Checked.ToString());

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}