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

using DotNetNuke.Entities.Modules;
using System;

namespace GIBS.Modules.Columbarium
{
    public class ColumbariumModuleSettingsBase : ModuleSettingsBase
    {

        public string EnableDiscount
        {
            get
            {
                if (Settings.Contains("EnableDiscount"))
                    return Settings["EnableDiscount"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "EnableDiscount", value.ToString());
            }
        }

        public string ShowPriceOnCheckout
        {
            get
            {
                if (Settings.Contains("ShowPriceOnCheckout"))
                    return Settings["ShowPriceOnCheckout"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ShowPriceOnCheckout", value.ToString());
            }
        }

        public string DisplayRemains
        {
            get
            {
                if (Settings.Contains("DisplayRemains"))
                    return Settings["DisplayRemains"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "DisplayRemains", value.ToString());
            }
        }

        public string ImagePath
        {
            get
            {
                if (Settings.Contains("ImagePath"))
                    return Settings["ImagePath"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ImagePath", value.ToString());
            }
        }


        public string WallImage
        {
            get
            {
                if (Settings.Contains("WallImage"))
                    return Settings["WallImage"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "WallImage", value.ToString());
            }
        }


        public string jQueryUI
        {
            get
            {
                if (Settings.Contains("jQueryUI"))
                    return Settings["jQueryUI"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "jQueryUI", value.ToString());
            }
        }


        public int PageSize
        {
            get
            {
                if (Settings.Contains("PageSize"))
                    return Convert.ToInt32(Settings["PageSize"]);
                return 10;
            }

            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "NumPerPage", value.ToString());
            }
        }

        public string RoleName
        {
            get
            {
                if (Settings.Contains("RoleName"))
                    return Settings["RoleName"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "RoleName", value.ToString());
            }
        }

        public string EmailFrom
        {
            get
            {
                if (Settings.Contains("EmailFrom"))
                    return Settings["EmailFrom"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "EmailFrom", value.ToString());
            }
        }

        public string EmailNotify
        {
            get
            {
                if (Settings.Contains("EmailNotify"))
                    return Settings["EmailNotify"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "EmailNotify", value.ToString());
            }
        }

        public string EmailBCC
        {
            get
            {
                if (Settings.Contains("EmailBCC"))
                    return Settings["EmailBCC"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "EmailBCC", value.ToString());
            }
        }

        public string EmailSubject
        {
            get
            {
                if (Settings.Contains("EmailSubject"))
                    return Settings["EmailSubject"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "EmailSubject", value.ToString());
            }
        }

        public string EmailMessage
        {
            get
            {
                if (Settings.Contains("EmailMessage"))
                    return Settings["EmailMessage"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "EmailMessage", value.ToString());
            }
        }

        public string ReportServerURL
        {
            get
            {
                if (Settings.Contains("ReportServerURL"))
                    return Settings["ReportServerURL"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ReportServerURL", value.ToString());
            }
        }

        public string ReportPath
        {
            get
            {
                if (Settings.Contains("ReportPath"))
                    return Settings["ReportPath"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ReportPath", value.ToString());
            }
        }

        public string ReportCredentialsUserName
        {
            get
            {
                if (Settings.Contains("ReportCredentialsUserName"))
                    return Settings["ReportCredentialsUserName"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ReportCredentialsUserName", value.ToString());
            }
        }

        public string ReportCredentialsPassword
        {
            get
            {
                if (Settings.Contains("ReportCredentialsPassword"))
                    return Settings["ReportCredentialsPassword"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ReportCredentialsPassword", value.ToString());
            }
        }

        public string ReportCredentialsDomain
        {
            get
            {
                if (Settings.Contains("ReportCredentialsDomain"))
                    return Settings["ReportCredentialsDomain"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "ReportCredentialsDomain", value.ToString());
            }
        }



    }
}