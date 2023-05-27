using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIBS.Modules.Columbarium.Components
{
    public class ColInfo
    {

        public int StatusID { get; set; }
        public string StatusCode { get; set; }
        public string Status { get; set; }
        public string isActive { get; set; }
        public int Ownerid { get; set; }
         
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public string Photo { get; set; }
        public string PhotoThumb { get; set; }

        public int NicheSize { get; set; }
        public int NicheID { get; set; }
        public int NicheNumber { get; set; }
        public int NicheSection { get; set; }
        //public string Notes { get; set; }
        public DateTime DateOfReservation { get; set; }
        public string DateOfPayment { get; set; }
        public bool isPaid { get; set; }
        public double Price { get; set; }
        public double AmountPaid { get; set; }
        public string Remains1FullName { get; set; }
        public string Remains1Salutation { get; set; }
        public string Remains1FirstName { get; set; }
        public string Remains1MI { get; set; }
        public string Remains1LastName { get; set; }
        public string Remains1Suffix { get; set; }
        public string Remains1DOB { get; set; }
        public string Remains1CityOfBirth { get; set; }
        public string Remains1StateOfBirth { get; set; }
        public string Remains1DOD { get; set; }
        public string Remains1CityOfDeath { get; set; }
        public string Remains1StateOfDeath { get; set; }
        public string Remains1Obituary { get; set; }
        public string Remains2FullName { get; set; }
        public string Remains2Salutation { get; set; }
        public string Remains2FirstName { get; set; }
        public string Remains2MI { get; set; }
        public string Remains2LastName { get; set; }
        public string Remains2Suffix { get; set; }
        public string Remains2DOB { get; set; }
        public string Remains2CityOfBirth { get; set; }
        public string Remains2StateOfBirth { get; set; }
        public string Remains2DOD { get; set; }
        public string Remains2CityOfDeath { get; set; }
        public string Remains2StateOfDeath { get; set; }
        public string Remains2Obituary { get; set; }
        public string InternalNotes { get; set; }

        public int PurchaserID { get; set; }
        public string salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string phone_day { get; set; }
        public string phone_eve { get; set; }
        public string phone_cell { get; set; }
        public string phone_fax { get; set; }
        public string email { get; set; } 
        public string Comments { get; set; }
        public string InternalNotesPurchaser { get; set; }
        public string Referrer { get; set; }
        public string Source { get; set; }
        public string BillingType { get; set; }
        public DateTime InsertDate { get; set; }

        public bool Parishioner { get; set; }
        public bool HasDonated { get; set; }
        public bool HasAncestor { get; set; }
        public string AncestorName { get; set; }

        public string Salutation1 { get; set; }
        public string FirstName1 { get; set; }
        public string MiddleInitial1 { get; set; }
        public string LastName1 { get; set; }
        public string Suffix1 { get; set; }

        public string Buyer1 { get; set; }
        public string Buyer2 { get; set; }

    }
}