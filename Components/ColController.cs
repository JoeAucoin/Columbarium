using GIBS.Modules.Columbarium.Data;
using DotNetNuke.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIBS.Modules.Columbarium.Components
{
    public class ColController
    {

        //DeleteReservation
        public static void DeleteReservation(int nicheID)

        {   //todo: look at caching

            DataProvider.Instance().DeleteReservation(nicheID);

        }

        public static List<ColInfo> GetSections()

        {   //todo: look at caching

            return CBO.FillCollection<ColInfo>(DataProvider.Instance().GetSections());

        }

        public static List<ColInfo> GetDisplaySection(int displaySection)

        {   //todo: look at caching

            return CBO.FillCollection<ColInfo>(DataProvider.Instance().GetDisplaySection(displaySection));

        } 

        public static ColInfo GetNiche(int nicheID)
        {
            return CBO.FillObject<ColInfo>(DataProvider.Instance().GetNiche(nicheID));
        }

        public static int InsertReservation(ColInfo ci)

        {
            if (ci.PurchaserID > 0)
            {
                // NEED UPDATE
            }
            else
            {
                // INSERT
                ci.PurchaserID = DataProvider.Instance().InsertReservation(ci);
            }

            return ci.PurchaserID;

        }

        public static List<ColInfo> SearchPending()

        {   
            return CBO.FillCollection<ColInfo>(DataProvider.Instance().SearchPending());
        }

        public static List<ColInfo> Search(string lastName)

        {   //todo: look at caching

            return CBO.FillCollection<ColInfo>(DataProvider.Instance().Search(lastName));

        }


        public static int UpdateReservation(ColInfo ci)

        {
            if (ci.PurchaserID > 0)
            {
                // NEED UPDATE
                ci.PurchaserID = DataProvider.Instance().UpdateReservation(ci);
            }
            else
            {
                // INSERT
             //   ci.PurchaserID = DataProvider.Instance().InsertReservation(ci);
            }

            return ci.PurchaserID;

        }

        public static int UpdateNichePrice(ColInfo ci)

        {
            if (ci.NicheID > 0)
            {
                // NEED UPDATE
                ci.NicheID = DataProvider.Instance().UpdateNichePrice(ci);
            }


            return ci.NicheID;

        }


    }
}