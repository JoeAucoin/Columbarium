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
using System.Net.Mail;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace GIBS.Modules.Columbarium
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The EditColumbarium class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from ColumbariumModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : ColumbariumModuleBase
    {

        int _ResourceID = Null.NullInteger;
        int _PurchaserID = Null.NullInteger;
        public string EmailContent = "";
        public bool _EnableDiscount = true;


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "InputMasks", (this.TemplateSourceDirectory + "/JavaScript/jquery.maskedinput-1.4.1.js"));

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
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Settings.Contains("DisplayRemains"))
                {
                    if (Settings["DisplayRemains"].ToString().Length > 0)
                    {
                        PanelRemains.Visible = Convert.ToBoolean(Settings["DisplayRemains"].ToString());
                    }
                    
                }

                //_EnableDiscount
                if (Settings.Contains("EnableDiscount"))
                {
                    if (Settings["EnableDiscount"].ToString().Length > 0)
                    {
                        _EnableDiscount = Convert.ToBoolean(Settings["EnableDiscount"].ToString());
                    }

                }


                if (Settings.Contains("ShowPriceOnCheckout"))
                {
                    if (Settings["ShowPriceOnCheckout"].ToString().Length > 0)
                    {
                        lblNichePrice.Visible = Convert.ToBoolean(Settings["ShowPriceOnCheckout"].ToString());
                        AdditionalPhoneNumbers.Visible = Convert.ToBoolean(Settings["ShowPriceOnCheckout"].ToString());
                    }

                }

                if (Request.QueryString["Resource"] != null)
                {
                    _ResourceID = Int32.Parse(Request.QueryString["Resource"]);
                //    hidDonationID.Value = DonationID.ToString();
                }

                if (!IsPostBack)
                {
                    GetStates();
                    if (_ResourceID != Null.NullInteger)
                    {
                        GetNiche(_ResourceID);
                    }

                    //GetNiche

                    //  LoadTemplates();
                }

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }



        public void GetNiche(int _resourceID)
        {

            try
            {
                
                ColInfo item = ColController.GetNiche(_resourceID);

                if (item != null)
                {
                    HiddenFieldNicheID.Value = _resourceID.ToString();
                    HiddenFieldPrice.Value = item.Price.ToString();

                    if (item.Status == "a")
                    {
                        lblNicheNumber.Text = "Niche Number: " + item.NicheNumber.ToString() + " - " + item.SectionName.ToString();
                        lblNichePrice.Text = "Niche Price: " + item.Price.ToString("C", CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        Response.Redirect(Globals.NavigateURL(), true);
                    }
                }            

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {
                    // your code here...



                    DateTime sqlMinDateAsNetDateTime = DateTime.Parse("1/1/1753");

                    int _hidNicheID = Convert.ToInt32(HiddenFieldNicheID.Value.ToString());

                    ColInfo item;

                    if (_hidNicheID > 0)
                    {

                        string _remains1DOB = null;
                        bool isremains1DOB = DateTime.TryParse(txtRemains1DOB.Text.ToString(), out sqlMinDateAsNetDateTime);
                        if (isremains1DOB == true)
                        {
                            _remains1DOB = txtRemains1DOB.Text.ToString();
                        }
                        else
                        {
                            _remains1DOB = null;
                        }

                        string _Remains1DOD = null;
                        bool isRemains1DOD = DateTime.TryParse(txtRemains1DOD.Text.ToString(), out sqlMinDateAsNetDateTime);
                        if (isRemains1DOD == true)
                        {
                            _Remains1DOD = txtRemains1DOD.Text.ToString();
                        }
                        else
                        {
                            _Remains1DOD = null;
                        }

                        string _Remains2DOB = null;
                        bool isRemains2DOB = DateTime.TryParse(txtRemains2DOB.Text.ToString(), out sqlMinDateAsNetDateTime);
                        if (isRemains2DOB == true)
                        {
                            _Remains2DOB = txtRemains2DOB.Text.ToString();
                        }
                        else
                        {
                            _Remains2DOB = null;
                        }

                        string _Remains2DOD = null;
                        bool isRemains2DOD = DateTime.TryParse(txtRemains2DOD.Text.ToString(), out sqlMinDateAsNetDateTime);
                        if (isRemains2DOD == true)
                        {
                            _Remains2DOD = txtRemains2DOD.Text.ToString();
                        }
                        else
                        {
                            _Remains2DOD = null;
                        }


                        item = new ColInfo
                        {
                            salutation = ddlPrefix.SelectedValue.ToString(),
                            FirstName = txtFirstName.Text.ToString(),
                            MiddleInitial = txtMiddleInitial.Text.ToString(),
                            LastName = txtLastName.Text.ToString(),
                            Suffix = ddlSuffix.SelectedValue.ToString(),
                            email = txtEmail.Text.ToString(),
                            Address1 = txtAddress1.Text.ToString(),
                            Address2 = txtAddress2.Text.ToString(),
                            City = txtCity.Text.ToString(),
                            State = ddlState.SelectedValue.ToString(),
                            Zip = txtZipCode.Text.ToString(),
                            phone_day = txtDayPhone.Text.ToString(),
                            phone_eve = txtNightPhone.Text.ToString(),
                            phone_cell = txtCellPhone.Text.ToString(),
                            phone_fax = txtFaxPhone.Text.ToString(),
                            AmountPaid = Convert.ToDouble(0),
                            NicheID = _hidNicheID,
                            PurchaserID = 0,
                            Comments = txtComments.Text.ToString(),

                            Remains1Salutation = ddlPrefixR1.SelectedValue.ToString(),
                            Remains1FirstName = txtFirstNameR1.Text.ToString(),
                            Remains1MI = txtMiddleInitialR1.Text.ToString(),
                            Remains1LastName = txtLastNameR1.Text.ToString(),
                            Remains1Suffix = ddlSuffixR1.SelectedValue.ToString(),
                            Remains1DOB = _remains1DOB,
                            Remains1CityOfBirth = txtRemains1CityOfBirth.Text.ToString(),
                            Remains1StateOfBirth = txtRemains1StateOfBirth.Text.ToString(),
                            Remains1DOD = _Remains1DOD,
                            Remains1CityOfDeath = txtRemains1CityOfDeath.Text.ToString(),
                            Remains1StateOfDeath = txtRemains1StateOfDeath.Text.ToString(),
                            Remains1Obituary = txtRemains1Obituary.Text.ToString(),
                            Remains2Salutation = ddlPrefixR2.SelectedValue.ToString(),
                            Remains2FirstName = txtFirstNameR2.Text.ToString(),
                            Remains2MI = txtMiddleInitialR1.Text.ToString(),
                            Remains2LastName = txtLastNameR2.Text.ToString(),
                            Remains2Suffix = ddlSuffixR2.SelectedValue.ToString(),
                            Remains2DOB = _Remains2DOB,
                            Remains2CityOfBirth = txtRemains2CityOfBirth.Text.ToString(),
                            Remains2StateOfBirth = txtRemains2StateOfBirth.Text.ToString(),
                            Remains2DOD = _Remains2DOD,
                            Remains2CityOfDeath = txtRemains2CityOfDeath.Text.ToString(),
                            Remains2StateOfDeath = txtRemains2StateOfDeath.Text.ToString(),
                            Remains2Obituary = txtRemains2Obituary.Text.ToString(),

                            Parishioner = cbxParishioner.Checked,
                            HasDonated = cbxHasDonated.Checked,
                            HasAncestor = cbxHasAncestor.Checked,
                            AncestorName = txtAncestorName.Text.ToString(),

                            Salutation1 = ddlPrefix1.SelectedValue.ToString(),
                            FirstName1 = txtFirstName1.Text.ToString(),
                            MiddleInitial1 = txtMiddleInitial1.Text.ToString(),
                            LastName1 = txtLastName1.Text.ToString(),
                            Suffix1 = ddlSuffix1.SelectedValue.ToString(),


                        };
                        _PurchaserID = ColController.InsertReservation(item);

                    }

                    if (_EnableDiscount)
                    {
                        if (cbxHasAncestor.Checked || cbxHasDonated.Checked)
                        {
                            int DiscountPrice = getDiscountPrice(Int32.Parse(HiddenFieldPrice.Value.ToString()));
                            HiddenFieldPrice.Value = DiscountPrice.ToString();
                            lblNichePrice.Text = "Niche Price: " + DiscountPrice.ToString("C", CultureInfo.CurrentCulture);

                            ColInfo priceitem;
                            priceitem = new ColInfo
                            {
                                NicheID = _hidNicheID,
                                Price = DiscountPrice
                            };
                            _hidNicheID = ColController.UpdateNichePrice(priceitem);
                        }
                    }
                    else
                    {
                        int SalePrice = Int32.Parse(HiddenFieldPrice.Value.ToString());
                        lblNichePrice.Text = "Niche Price: " + SalePrice.ToString("C", CultureInfo.CurrentCulture);
                    }

                    //       lblDebug.Text = "Success";

                    SendConfirmationEmail(_hidNicheID);

                    NicheDetails.Visible = false;
                    ReservationForm.Visible = false;


                    lblDebug.Text = "<h1 style='color:green;'>Success</h1>" + EmailContent.ToString();

                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public int getDiscountPrice(int val)
        {
            int retValue = 0;
            switch (val)
            {
                

                case 12000:
                    retValue = 9000;
                    break;
                case 9000:
                    retValue = 7750; 
                    break;

                default:
                    retValue = val;
                    break;
            }
        return retValue;
        }

        public void GetStates()
        {
            try
            {               
                var _states = new ListController().GetListEntryInfoItems("Region", "Country.US", this.PortalId);
           
                ddlState.DataTextField = "Text";
                ddlState.DataValueField = "Value";
                ddlState.DataSource = _states;
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("--", ""));
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = CheckBox4.Checked;
            
        }

        protected void CheckBoxRequired_ServerValidate5(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = CheckBox5.Checked;

        }

        public void SendConfirmationEmail(int _nicheID)
        {

            try
            {

                ColInfo item = ColController.GetNiche(_nicheID);
                //load the item
            //    GiftCertificateController controller = new GiftCertificateController();
            //    GiftCertificateInfo item = controller.GetGiftCert(_itemID);
                if (item != null)
                {
                    string _emailFrom = "";
                    string _emailSubject = "";
                    string _emailMessage = "";
                    string _emailNotify = "";
                    string _emailBCC = "";
                    //EmailBCC

                    //  EmailBCC    EmailSubject    EmailMessage
                    if (Settings.Contains("EmailFrom"))
                    {
                        _emailFrom = Settings["EmailFrom"].ToString();
                    }
                    else
                    {
                        _emailFrom = PortalSettings.Email.ToString();
                    }

                    if (Settings.Contains("EmailNotify"))
                    {
                        _emailNotify = Settings["EmailNotify"].ToString();
                    }
                    else
                    {
                        _emailNotify = PortalSettings.Email.ToString();
                    }

                    if (Settings.Contains("EmailSubject"))
                    {
                        _emailSubject = Settings["EmailSubject"].ToString();
                    }
                    else
                    {
                        _emailSubject = "New Order";
                    }

                    if (Settings.Contains("EmailMessage"))
                    {
                        _emailMessage = Settings["EmailMessage"].ToString();
                    }

                    if (Settings.Contains("EmailBCC"))
                    {
                        _emailBCC = Settings["EmailBCC"].ToString();
                    }


                    //
                    EmailContent = "<style type='text/css'>";
                    EmailContent += "body{background: #ffffff;font-family: verdana, arial;font-size: 10px;color: #000000;}";
                    EmailContent += "h4 {color: #840000; font-family: verdana, arial;font-size: 16px;}";
                    EmailContent += "</style>";
                    // BUILD E-MAIL BODY

                 //   EmailContent += "<p><b>Print this and mail it with your payment . . . </b></p>";
                    EmailContent += "<h5>Order Date: " +  item.DateOfReservation.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "</h5>";
                    EmailContent += "<h2>Niche Order Confirmation</h2>";

                    EmailContent += "<h4>Niche Number: " + item.NicheNumber.ToString() + " - " + item.SectionName.ToString();
                    EmailContent += "<br>Niche Price: " + String.Format("{0:c}", item.Price) + "</h4>";

                    EmailContent += "<h5>Purchaser Information:</h5>";
                    EmailContent += "<p>";

                   // EmailContent += item.salutation.ToString() + " " + item.FirstName.ToString() + " " + item.MiddleInitial.ToString() + " " + item.LastName.ToString() + " " + item.Suffix.ToString();
                    EmailContent += item.Buyer1.ToString();
                    if (item.Buyer2.ToString().Length > 0)
                    {
                        EmailContent += "<br />" + item.Buyer2.ToString();
                    }

                    EmailContent += "<br />" + item.Address1.ToString();
                    if (item.Address2.ToString().Length > 0)
                    {
                        EmailContent += "<br />" + item.Address2.ToString();
                    }
                    EmailContent += "<br>" + item.City.ToString() + ", " + item.State.ToString() + " " + item.Zip.ToString() + "</p>";
                    EmailContent += "<p>";
                    if (item.phone_day.ToString().Length > 0)
                    {
                        EmailContent += "Daytime Phone: " + item.phone_day.ToString() + "<br />";
                    }

                    if (item.phone_eve.ToString().Length > 0)
                    {
                        EmailContent += "Evening Phone: " + item.phone_eve.ToString() + "<br />";
                    }

                    if (item.phone_fax.ToString().Length > 0)
                    {
                        EmailContent += "Fax Phone: " + item.phone_fax.ToString() + "<br />";
                    }

                    if (item.phone_cell.ToString().Length > 0)
                    {
                        EmailContent += "Cell Phone: " + item.phone_cell.ToString() + "<br />";
                    }

                    if (item.email.ToString().Length > 0)
                    {
                        EmailContent += "E-Mail: " + item.email.ToString() + "<br />";
                    }

                    EmailContent += "</p>";


                    if (item.Comments.ToString().Length > 0)
                    {
                        EmailContent += "<p>";
                        EmailContent += "<b>Questions/Comments:</b><br /><br />" + item.Comments.ToString() ;
                        EmailContent += "</p>";
                    }

                    EmailContent += "<p>";
                    EmailContent += "<b>Parishioner:</b> " + ReturnBooleanAsString(item.Parishioner) + "<br />";
                    EmailContent += "<b>Past Pledge:</b> " + ReturnBooleanAsString(item.HasDonated) + "<br />";
                    EmailContent += "<b>Has Ancestor:</b> " + ReturnBooleanAsString(item.HasAncestor);
                    if (item.HasAncestor.ToString() == "True")
                    {
                        EmailContent += "<br /><b>Ancestor Name:</b> " + item.AncestorName.ToString();
                    }

                    EmailContent += "</p>";

                    //    EmailContent += "<br />&nbsp;";
                    EmailContent += "<hr style='background-color: #fff;border-top: 4px dashed #8c8b8b;'>";

                    EmailContent += _emailMessage.ToString();

                    


                    EmailContent += "<p>Page Submitted: " + Globals.NavigateURL() + "</p>";

                    //EMAIL THE PURCHASER
                    string EmailFrom = "";
                    if (_emailFrom.Length > 1)
                    {
                        EmailFrom = _emailFrom.ToString();
                    }
                    else
                    {
                        EmailFrom = PortalSettings.Email.ToString();
                    }

                    string SMTPUserName = DotNetNuke.Entities.Controllers.HostController.Instance.GetString("SMTPUsername");
                 //   string[] arrNoAttachements = new string[] { };
                    List<Attachment> attchmnts = new List<Attachment>();

                    // EMAIL PURCHASER
                    DotNetNuke.Services.Mail.Mail.SendMail("Holy Trinity Columbarium <" + SMTPUserName.ToString() + ">",
                        "Holy Trinity Columbarium <" + SMTPUserName.ToString() +">",
                            item.email.ToString(),
                            "",
                            "",
                            EmailFrom.ToString(),
                            DotNetNuke.Services.Mail.MailPriority.Normal,
                            _emailSubject.ToString(),
                            DotNetNuke.Services.Mail.MailFormat.Html,
                            System.Text.Encoding.Default,
                            EmailContent.ToString(),
                            attchmnts,
                            "",
                            "",
                            "",
                            "",
                            true);

    
                    //// EMAIL THE settingsData.EmailNotify
                    //// ADD NOTE for ADMINS . . . . 
                    string AdminEmailContent = "<p><b>Administrators must log in to the site to manage record.</b></p>";

                    if (_emailNotify.ToString().Length > 1)
                    {
                        string FromPurchaserEmail = item.email.ToString();
                        string emailAddress = _emailNotify.ToString().Replace(" ", "");
                        string[] valuePair = emailAddress.Split(new char[] { ';' });

                        for (int i = 0; i <= valuePair.Length - 1; i++)
                        {                   
                            DotNetNuke.Services.Mail.Mail.SendMail("Holy Trinity Columbarium <" + SMTPUserName.ToString() + ">",
                                "Holy Trinity Columbarium <" + SMTPUserName.ToString() + ">",
                                valuePair[i].ToString().Trim(),
                                "",
                                _emailBCC.ToString(),
                                FromPurchaserEmail.ToString(),
                                DotNetNuke.Services.Mail.MailPriority.Normal,
                                _emailSubject.ToString(),
                                DotNetNuke.Services.Mail.MailFormat.Html,
                                System.Text.Encoding.Default,
                                EmailContent.ToString() + AdminEmailContent.ToString(),
                                attchmnts,
                                "",
                                "",
                                "",
                                "",
                                true);

                        }

                    }







                }
                else
                {
                    Response.Redirect(Globals.NavigateURL(), true);
                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public string ReturnBooleanAsString(Boolean choice)
        {
            if (choice)
            {
                return ("Yes");
            }
            else
            {
                return ("No");
            }
        }


    }
}