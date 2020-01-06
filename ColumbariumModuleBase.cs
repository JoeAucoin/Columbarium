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
    public class ColumbariumModuleBase : PortalModuleBase
    {

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

                mc.UpdateModuleSetting(ModuleId, "PageSize", value.ToString());

            }

        }


    }
}