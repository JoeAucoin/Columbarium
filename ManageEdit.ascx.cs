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

namespace GIBS.Modules.Columbarium
{
    public partial class ManageEdit :  ColumbariumModuleBase

    {
        int _ResourceID = Null.NullInteger;
        int _PurchaserID = Null.NullInteger;
        public string EmailContent = "";
        DateTime temp;
        public double _nicheCost = 0.00;
        static string _DisplaySection = "";

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            JavaScript.RequestRegistration(CommonJs.jQuery);
            JavaScript.RequestRegistration(CommonJs.jQueryUI);
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "InputMasks", (this.TemplateSourceDirectory + "/JavaScript/jquery.maskedinput-1.4.1.js"));

            if (Settings.Contains("RoleName"))
            {
                if (this.UserInfo.IsInRole(Settings["RoleName"].ToString()))
                {
                    lblDebug.Text = "Welcome " + this.UserInfo.DisplayName.ToString();
                }
                else
                {
                    Response.Redirect(Globals.NavigateURL(), true);
                }
            }

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
                    _DisplaySection = item.NicheSection.ToString();

                    if (item.isPaid)
                    {
                        Image122.ImageUrl = this.TemplateSourceDirectory + "/images/yes.png";
                        Image122.ToolTip = "Paid in Full";
                        Image122.AlternateText = "Paid in Full";
                        LinkButtonDelete.Visible = false;
                    }
                    else
                    {
                        Image122.ImageUrl = this.TemplateSourceDirectory + "/images/no.png";
                        Image122.ToolTip = "Monies Owed";
                        Image122.AlternateText = "Monies Owed";
                    }
                    HiddenFieldNicheID.Value = item.NicheID.ToString();
                    HiddenFieldPurchaserID.Value = item.PurchaserID.ToString();
                    HiddenFieldPrice.Value = item.Price.ToString();
                    lblNicheNumber.Text = "Niche: " + item.NicheNumber.ToString() + " - " + item.SectionName.ToString();
                    lblNichePrice.Text = "Price: " + item.Price.ToString("C", CultureInfo.CurrentCulture);
                    _nicheCost = item.Price;
                    //PURCHASER
                    txtFirstName.Text = item.FirstName.ToString();
                    ddlSuffix.SelectedValue = item.Suffix.ToString();
                    txtMiddleInitial.Text = item.MiddleInitial.ToString();
                    ddlPrefix.SelectedValue = item.salutation.ToString();
                    txtLastName.Text = item.LastName.ToString();
                    txtAddress1.Text = item.Address1.ToString();
                    txtAddress2.Text = item.Address2.ToString();
                    txtCity.Text = item.City.ToString();
                    ddlState.SelectedValue = item.State.ToString();
                    txtZipCode.Text = item.Zip.ToString();
                    txtEmail.Text = item.email.ToString();
                    txtCellPhone.Text = item.phone_cell.ToString();
                    txtDayPhone.Text = item.phone_day.ToString();
                    txtFaxPhone.Text = item.phone_fax.ToString();
                    txtComments.Text = item.Comments.ToString();
                    txtNightPhone.Text = item.phone_eve.ToString();
                    // REMAINS 1
                    ddlPrefixR1.SelectedValue = item.Remains1Salutation.ToString();
                    txtFirstNameR1.Text = item.Remains1FirstName.ToString();
                    txtMiddleInitialR1.Text = item.Remains1MI.ToString();
                    txtLastNameR1.Text = item.Remains1LastName.ToString();
                    ddlSuffixR1.SelectedValue = item.Remains1Suffix.ToString();
                    if (DateTime.TryParse(item.Remains1DOB.ToString(), out temp))
                    {
                        if (item.Remains1DOB != null)
                        {
                            txtRemains1DOB.Text = DateTime.Parse(item.Remains1DOB.ToString()).ToShortDateString();
                        }     
                    }            
                    txtRemains1CityOfBirth.Text = item.Remains1CityOfBirth.ToString();
                    txtRemains1StateOfBirth.Text = item.Remains1StateOfBirth.ToString();
                    if (DateTime.TryParse(item.Remains1DOD.ToString(), out temp))
                    {
                        if (item.Remains1DOD != null)
                        {
                            txtRemains1DOD.Text = DateTime.Parse(item.Remains1DOD.ToString()).ToShortDateString();
                        }
                    }
                    txtRemains1CityOfDeath.Text = item.Remains1CityOfDeath.ToString();
                    txtRemains1StateOfDeath.Text = item.Remains1StateOfDeath.ToString();
                    txtRemains1Obituary.Text = item.Remains1Obituary.ToString();
                    // REMAINS 2
                    ddlPrefixR2.SelectedValue = item.Remains2Salutation.ToString();
                    txtFirstNameR2.Text = item.Remains2FirstName.ToString();
                    txtMiddleInitialR2.Text = item.Remains2MI.ToString();
                    txtLastNameR2.Text = item.Remains2LastName.ToString();
                    ddlSuffixR2.SelectedValue = item.Remains2Suffix.ToString();
                    if (DateTime.TryParse(item.Remains2DOB.ToString(), out temp))
                    {
                        if (item.Remains2DOB != null)
                        {
                            txtRemains2DOB.Text = DateTime.Parse(item.Remains2DOB.ToString()).ToShortDateString();
                        }
                    }
                    txtRemains2CityOfBirth.Text = item.Remains2CityOfBirth.ToString();
                    txtRemains2StateOfBirth.Text = item.Remains2StateOfBirth.ToString();
                    if (DateTime.TryParse(item.Remains2DOD.ToString(), out temp))
                    {
                        if (item.Remains2DOD != null)
                        {
                            txtRemains2DOD.Text = DateTime.Parse(item.Remains2DOD.ToString()).ToShortDateString();
                        }
                    }
                    txtRemains2CityOfDeath.Text = item.Remains2CityOfDeath.ToString();
                    txtRemains2StateOfDeath.Text = item.Remains2StateOfDeath.ToString();
                    txtRemains2Obituary.Text = item.Remains2Obituary.ToString();

                    txtAmountPaid.Text = item.AmountPaid.ToString("C");
                    if (DateTime.TryParse(item.DateOfPayment.ToString(), out temp))
                    {
                        if (item.DateOfPayment != null)
                        {
                            txtDateOfPayment.Text = DateTime.Parse(item.DateOfPayment.ToString()).ToShortDateString();
                        }
                    }

                    txtDateOfReservation.Text = DateTime.Parse(item.DateOfReservation.ToString()).ToShortDateString();
                    txtInternalNotes.Text = item.InternalNotes.ToString();

                    txtAncestorName.Text = item.AncestorName.ToString();
                    cbxHasAncestor.Checked = item.HasAncestor;
                    cbxHasDonated.Checked = item.HasDonated;
                    cbxParishioner.Checked = item.Parishioner;

                    ddlPrefix1.SelectedValue = item.Salutation1;
                    txtFirstName1.Text = item.FirstName1;
                    txtMiddleInitial1.Text = item.MiddleInitial1;
                    txtLastName1.Text = item.LastName1;
                    ddlSuffix1.SelectedValue = item.Suffix1;

                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void UpdateNiche()
        {
            try
            {
                DateTime sqlMinDateAsNetDateTime = DateTime.Parse("1/1/1753");

                _nicheCost = double.Parse(HiddenFieldPrice.Value.ToString());

                int _hidNicheID = Convert.ToInt32(HiddenFieldNicheID.Value.ToString());
                int _hidPurchaserID = Convert.ToInt32(HiddenFieldPurchaserID.Value.ToString());
                double _amountPaid = 0.00;
                string _status = "p";
                bool _isPaying = double.TryParse(txtAmountPaid.Text.ToString().Replace("$", ""), out _amountPaid);
                if (_isPaying == true)
                {
                    _amountPaid = double.Parse(txtAmountPaid.Text.ToString().Replace("$", ""));
                    if (_amountPaid == _nicheCost)
                    {
                        _status = "s";
                    }

                }
                string _dateOfPayment = null;
                bool isPayDate = DateTime.TryParse(txtDateOfPayment.Text.ToString(), out sqlMinDateAsNetDateTime);
                if (isPayDate == true)
                {
                    _dateOfPayment = txtDateOfPayment.Text.ToString();

                }

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


                ColInfo item;

                if (_hidNicheID > 0)
                {
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
                        AmountPaid = _amountPaid,
                        NicheID = Int32.Parse(_hidNicheID.ToString()),
                        PurchaserID = Int32.Parse(_hidPurchaserID.ToString()),
                        Comments = txtComments.Text.ToString(),
                        Status = _status.ToString(),
                        DateOfPayment = _dateOfPayment,
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
                        InternalNotes = txtInternalNotes.Text.ToString(),

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
                    _hidNicheID = ColController.UpdateReservation(item);

                }
                //       lblDebug.Text = "Success";

                // SendConfirmationEmail(_hidNicheID);

                //  NicheDetails.Visible = false;
                //  Reload Record
                GetNiche(_hidNicheID);

                lblDebug.Text = "<h1 style='color:green;'>Successfully Updated Record</h1>";

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateNiche();
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

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



                    //
                    EmailContent = "<style type='text / css'>";
                    EmailContent += "body{background: #ffffff;font-family: verdana, arial;font-size: 10px;color: #000000;}";
                    EmailContent += "h4 {color: #840000; font-family: verdana, arial;font-size: 16px;}";

                    EmailContent += "</style>";
                    // BUILD E-MAIL BODY

                    EmailContent += "<p><b>Print this page and mail it with your payment . . . </b></p>";
                    EmailContent += "<h5>Date of Purchase: " + item.DateOfReservation.ToString() + "</h5>";
                    EmailContent += "<h2>Holy Trinity Memorial Wall Niche Purchase</h2>";

                    EmailContent += "<h4>Niche: " + item.NicheNumber.ToString() + " - " + item.SectionName.ToString();
                    EmailContent += "<br>Niche Price: " + String.Format("{0:c}", item.Price) + "</ h4 >";

                    EmailContent += "<h5>Purchaser Information:</h5>";
                    EmailContent += "<blockquote><p>";

                    EmailContent += item.salutation.ToString() + " " + item.FirstName.ToString() + " " + item.MiddleInitial.ToString() + " " + item.LastName.ToString() + " " + item.Suffix.ToString();
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
                    EmailContent += "</p></blockquote>";


                    if (item.Comments.ToString().Length > 0)
                    {
                        EmailContent += "<p>";
                        EmailContent += "<b>Questions/Comments:</b><br /><br />" + item.Comments.ToString();
                        EmailContent += "</p>";
                    }



                    //    EmailContent += "<br />&nbsp;";
                    EmailContent += "<hr style='background-color: #fff;border - top: 8px dashed #8c8b8b;' width=600>";



                    EmailContent += "<p>Make your check payable to <b><font color='RED'>Holy Trinity Church</font></b> and mail your payment to:</p>";



                    EmailContent += "<p>Peterson Realty, Inc.<br>";
                    EmailContent += "P.O. Box 324<br>West Harwich, MA 02671</p>";


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
                    string[] arrNoAttachements = new string[] { };


                    // EMAIL PURCHASER
                    DotNetNuke.Services.Mail.Mail.SendMail(SMTPUserName.ToString(),
                            item.email.ToString(),
                            "",
                            "",
                            _emailFrom.ToString(),
                            DotNetNuke.Services.Mail.MailPriority.Normal,
                            _emailSubject.ToString(),
                            DotNetNuke.Services.Mail.MailFormat.Html,
                            System.Text.Encoding.Default,
                            EmailContent.ToString(),
                            arrNoAttachements,
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
                            DotNetNuke.Services.Mail.Mail.SendMail(SMTPUserName.ToString(),
                                valuePair[i].ToString().Trim(),
                                "",
                                "",
                                FromPurchaserEmail.ToString(),
                                DotNetNuke.Services.Mail.MailPriority.Normal,
                                _emailSubject.ToString(),
                                DotNetNuke.Services.Mail.MailFormat.Html,
                                System.Text.Encoding.Default,
                                EmailContent.ToString() + AdminEmailContent.ToString(),
                                arrNoAttachements,
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string vLink = Globals.NavigateURL("Manage", "mid", this.ModuleId.ToString());
            Response.Redirect(vLink.ToString(), true);
        }

        protected void LinkButtonUpdate_Click(object sender, EventArgs e)
        {
            UpdateNiche();
        }

        protected void Btn_Restore_Click(object sender, EventArgs e)
        {
            string vLink = Globals.NavigateURL("Manage", "mid", this.ModuleId.ToString() + "?DisplaySection=" + _DisplaySection.ToString());
            Response.Redirect(vLink.ToString(), true);
        }

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {



            try
            {

                ColController.DeleteReservation(Int32.Parse(HiddenFieldNicheID.Value.ToString()));

                string vLink = Globals.NavigateURL("Manage", "mid", this.ModuleId.ToString());       
                Response.Redirect(vLink.ToString(), true);

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }


        }
    }
}