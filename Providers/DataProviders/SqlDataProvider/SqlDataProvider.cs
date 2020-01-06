/*
' Copyright (c) 2017 GIBS.com
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
using System;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace GIBS.Modules.Columbarium.Data
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// SQL Server implementation of the abstract DataProvider class
    /// 
    /// This concreted data provider class provides the implementation of the abstract methods 
    /// from data dataprovider.cs
    /// 
    /// In most cases you will only modify the Public methods region below.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public class SqlDataProvider : DataProvider
    {

        #region Private Members

        private const string ProviderType = "data";
        private const string ModuleQualifier = "GIBS_";

        private readonly ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType);
        private readonly string _connectionString;
        private readonly string _providerPath;
        private readonly string _objectQualifier;
        private readonly string _databaseOwner;

        #endregion

        #region Constructors

        public SqlDataProvider()
        {

            // Read the configuration specific information for this provider
            Provider objProvider = (Provider)(_providerConfiguration.Providers[_providerConfiguration.DefaultProvider]);

            // Read the attributes for this provider

            //Get Connection string from web.config
            _connectionString = Config.GetConnectionString();

            if (string.IsNullOrEmpty(_connectionString))
            {
                // Use connection string specified in provider
                _connectionString = objProvider.Attributes["connectionString"];
            }

            _providerPath = objProvider.Attributes["providerPath"];

            _objectQualifier = objProvider.Attributes["objectQualifier"];
            if (!string.IsNullOrEmpty(_objectQualifier) && _objectQualifier.EndsWith("_", StringComparison.Ordinal) == false)
            {
                _objectQualifier += "_";
            }

            _databaseOwner = objProvider.Attributes["databaseOwner"];
            if (!string.IsNullOrEmpty(_databaseOwner) && _databaseOwner.EndsWith(".", StringComparison.Ordinal) == false)
            {
                _databaseOwner += ".";
            }

        }

        #endregion

        #region Properties

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public string ProviderPath
        {
            get
            {
                return _providerPath;
            }
        }

        public string ObjectQualifier
        {
            get
            {
                return _objectQualifier;
            }
        }

        public string DatabaseOwner
        {
            get
            {
                return _databaseOwner;
            }
        }

        // used to prefect your database objects (stored procedures, tables, views, etc)
        private string NamePrefix
        {
            get { return DatabaseOwner + ObjectQualifier + ModuleQualifier; }
        }

        #endregion

        #region Private Methods

        private static object GetNull(object field)
        {
            return Null.GetNull(field, DBNull.Value);
        }

        #endregion

        #region Public Methods

        public override IDataReader GetSections()
        {
            return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "Col_GetSections");
        }

        public override IDataReader SearchPending()
        {
            return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "Col_SearchPending");

        }
        //DeleteReservation
        public override void DeleteReservation(int nicheID)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, NamePrefix + "Col_DeleteReservation", nicheID);

        }

        public override IDataReader GetDisplaySection(int displaySection)
        {
            return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "Col_GetDisplaySection", displaySection);
        }

        public override IDataReader GetNiche(int nicheID)
        {
            return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "Col_GetNiche", nicheID);
        }

        public override int InsertReservation(ColInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, NamePrefix + "Col_InsertReservation"
                , new SqlParameter("@Salutation", ci.salutation)
                , new SqlParameter("@FirstName", ci.FirstName)
                , new SqlParameter("@MiddleInitial", ci.MiddleInitial)
                , new SqlParameter("@LastName", ci.LastName)
                , new SqlParameter("@Suffix", ci.Suffix)
                , new SqlParameter("@Email", ci.email)
                , new SqlParameter("@Address1", ci.Address1)
                , new SqlParameter("@Address2", ci.Address2)
                , new SqlParameter("@City", ci.City)
                , new SqlParameter("@State", ci.State)
                , new SqlParameter("@Zip", ci.Zip)
                , new SqlParameter("@phone_day", ci.phone_day)
                , new SqlParameter("@phone_eve", ci.phone_eve)
                , new SqlParameter("@phone_cell", ci.phone_cell)
                , new SqlParameter("@phone_fax", ci.phone_fax)
                , new SqlParameter("@AmountPaid", ci.AmountPaid)
                , new SqlParameter("@NicheID", ci.NicheID)
                , new SqlParameter("@Comments",ci.Comments)

                , new SqlParameter("@Remains1Salutation", ci.Remains1Salutation)
                , new SqlParameter("@Remains1FirstName", ci.Remains1FirstName)
                , new SqlParameter("@Remains1MI", ci.Remains1MI)
                , new SqlParameter("@Remains1LastName", ci.Remains1LastName)
                , new SqlParameter("@Remains1Suffix", ci.Remains1Suffix)
                , new SqlParameter("@Remains1DOB", ci.Remains1DOB)
                , new SqlParameter("@Remains1CityOfBirth", ci.Remains1CityOfBirth)
                , new SqlParameter("@Remains1StateOfBirth", ci.Remains1StateOfBirth)
                , new SqlParameter("@Remains1DOD", ci.Remains1DOD)
                , new SqlParameter("@Remains1CityOfDeath", ci.Remains1CityOfDeath)
                , new SqlParameter("@Remains1StateOfDeath", ci.Remains1StateOfDeath)
                , new SqlParameter("@Remains1Obituary", ci.Remains1Obituary)
                , new SqlParameter("@Remains2Salutation", ci.Remains2Salutation)
                , new SqlParameter("@Remains2FirstName", ci.Remains2FirstName)
                , new SqlParameter("@Remains2MI", ci.Remains2MI)
                , new SqlParameter("@Remains2LastName", ci.Remains2LastName)
                , new SqlParameter("@Remains2Suffix", ci.Remains2Suffix)
                , new SqlParameter("@Remains2DOB", ci.Remains2DOB)
                , new SqlParameter("@Remains2CityOfBirth", ci.Remains2CityOfBirth)
                , new SqlParameter("@Remains2StateOfBirth", ci.Remains2StateOfBirth)
                , new SqlParameter("@Remains2DOD", ci.Remains2DOD)
                , new SqlParameter("@Remains2CityOfDeath", ci.Remains2CityOfDeath)
                , new SqlParameter("@Remains2StateOfDeath", ci.Remains2StateOfDeath)
                , new SqlParameter("@Remains2Obituary", ci.Remains2Obituary)

                , new SqlParameter("@Parishioner", ci.Parishioner)
                , new SqlParameter("@HasDonated", ci.HasDonated)
                , new SqlParameter("@HasAncestor", ci.HasAncestor)
                , new SqlParameter("@AncestorName", ci.AncestorName)

                , new SqlParameter("@Salutation1", ci.Salutation1)
                , new SqlParameter("@FirstName1", ci.FirstName1)
                , new SqlParameter("@MiddleInitial1", ci.MiddleInitial1)
                , new SqlParameter("@LastName1", ci.LastName1)
                , new SqlParameter("@Suffix1", ci.Suffix1)

                ));
        }


        public override IDataReader Search(string lastName)
        {
            return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "Col_Search", lastName);
        }


        public override int UpdateNichePrice(ColInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, NamePrefix + "Col_UpdateNichePrice",
                new SqlParameter("@NicheID", ci.NicheID)
                 , new SqlParameter("@Price", ci.Price)
                ));
        }

        public override int UpdateReservation(ColInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, NamePrefix + "Col_UpdateReservation"
                , new SqlParameter("@Status", ci.Status)
                , new SqlParameter("@NicheID", ci.NicheID)
                 , new SqlParameter("@PurchaserID", ci.PurchaserID)

                , new SqlParameter("@Salutation", ci.salutation)
                , new SqlParameter("@FirstName", ci.FirstName)
                , new SqlParameter("@MiddleInitial", ci.MiddleInitial)
                , new SqlParameter("@LastName", ci.LastName)
                , new SqlParameter("@Suffix", ci.Suffix)
                , new SqlParameter("@Email", ci.email)
                , new SqlParameter("@Address1", ci.Address1)
                , new SqlParameter("@Address2", ci.Address2)
                , new SqlParameter("@City", ci.City)
                , new SqlParameter("@State", ci.State)
                , new SqlParameter("@Zip", ci.Zip)
                , new SqlParameter("@phone_day", ci.phone_day)
                , new SqlParameter("@phone_eve", ci.phone_eve)
                , new SqlParameter("@phone_cell", ci.phone_cell)
                , new SqlParameter("@phone_fax", ci.phone_fax)
                , new SqlParameter("@AmountPaid", ci.AmountPaid)
               
                , new SqlParameter("@Comments", ci.Comments)

               
               
                , new SqlParameter("@DateOfPayment", ci.DateOfPayment)
                , new SqlParameter("@Remains1Salutation", ci.Remains1Salutation)
                , new SqlParameter("@Remains1FirstName", ci.Remains1FirstName)
                , new SqlParameter("@Remains1MI", ci.Remains1MI)
                , new SqlParameter("@Remains1LastName", ci.Remains1LastName)
                , new SqlParameter("@Remains1Suffix", ci.Remains1Suffix)
                , new SqlParameter("@Remains1DOB", ci.Remains1DOB)
                , new SqlParameter("@Remains1CityOfBirth", ci.Remains1CityOfBirth)
                , new SqlParameter("@Remains1StateOfBirth", ci.Remains1StateOfBirth)
                , new SqlParameter("@Remains1DOD", ci.Remains1DOD)
                , new SqlParameter("@Remains1CityOfDeath", ci.Remains1CityOfDeath)
                , new SqlParameter("@Remains1StateOfDeath", ci.Remains1StateOfDeath)
                , new SqlParameter("@Remains1Obituary", ci.Remains1Obituary)
                , new SqlParameter("@Remains2Salutation", ci.Remains2Salutation)
                , new SqlParameter("@Remains2FirstName", ci.Remains2FirstName)
                , new SqlParameter("@Remains2MI", ci.Remains2MI)
                , new SqlParameter("@Remains2LastName", ci.Remains2LastName)
                , new SqlParameter("@Remains2Suffix", ci.Remains2Suffix)
                , new SqlParameter("@Remains2DOB", ci.Remains2DOB)
                , new SqlParameter("@Remains2CityOfBirth", ci.Remains2CityOfBirth)
                , new SqlParameter("@Remains2StateOfBirth", ci.Remains2StateOfBirth)
                , new SqlParameter("@Remains2DOD", ci.Remains2DOD)
                , new SqlParameter("@Remains2CityOfDeath", ci.Remains2CityOfDeath)
                , new SqlParameter("@Remains2StateOfDeath", ci.Remains2StateOfDeath)
                , new SqlParameter("@Remains2Obituary", ci.Remains2Obituary)
                , new SqlParameter("@InternalNotes", ci.InternalNotes)

                , new SqlParameter("@Parishioner", ci.Parishioner)
                , new SqlParameter("@HasDonated", ci.HasDonated)
                , new SqlParameter("@HasAncestor", ci.HasAncestor)
                , new SqlParameter("@AncestorName", ci.AncestorName)

                , new SqlParameter("@Salutation1", ci.Salutation1)
                , new SqlParameter("@FirstName1", ci.FirstName1)
                , new SqlParameter("@MiddleInitial1", ci.MiddleInitial1)
                , new SqlParameter("@LastName1", ci.LastName1)
                , new SqlParameter("@Suffix1", ci.Suffix1)

                ));
        }


        //public override IDataReader GetItem(int itemId)
        //{
        //    return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "spGetItem", itemId);
        //}

        //public override IDataReader GetItems(int userId, int portalId)
        //{
        //    return SqlHelper.ExecuteReader(ConnectionString, NamePrefix + "spGetItemsForUser", userId, portalId);
        //}


        #endregion

    }

}