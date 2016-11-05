using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.DBContext;
namespace DataLayer.Impelmentation
{
    public class FarmerDetailOperations : IfarmerDetailOperations
    {
        DBentities db = new DBentities();

       
        /// <summary>
        /// Delete Farmer Detail
        /// </summary>
        /// <param name="farmerDetailId"></param>
        /// <returns></returns>
        public int DeleteFarmerDetail(int farmerDetailId)
        {
            try
            {
                FarmerDetail existingFarmerDetail = GetFarmerDetailById(farmerDetailId);
                if (existingFarmerDetail != null)
                {
                    db.Entry(existingFarmerDetail).State = System.Data.Entity.EntityState.Deleted;
                    return SaveChanges();
                }
                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        /// <summary>
        /// Get Farmer detail by id
        /// </summary>
        /// <param name="farmerDetailId"></param>
        /// <returns></returns>
        public FarmerDetail GetFarmerDetailById(int farmerDetailId)
        {
            try
            {
                return db.FarmerDetails.FirstOrDefault(x => x.Id == farmerDetailId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get farmer detail by first name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public FarmerDetail GetFarmerDetailByFirstName(string firstName)
        {
            try
            {
                return db.FarmerDetails.Select(x => x).Where(x => x.FarmerFirstName == firstName).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get all farmer detail
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FarmerDetail> GetFarmerDetailList()
        {
            try
            {
                
                return db.FarmerDetails.Select(x => x);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Insert farmer detail
        /// </summary>
        /// <param name="farmerDetail"></param>
        /// <returns></returns>
        public FarmerDetail InsertFarmerDetail(FarmerDetail farmerDetail)
        {
            try
            {
                farmerDetail.CreatedDate = DateTime.Now;
                farmerDetail.LastUpdate = DateTime.Now;
                farmerDetail.RegistrationNumber = (farmerDetail.FarmerFirstName.Length > 3 ? farmerDetail.FarmerFirstName.Substring(0, 3) : farmerDetail.FarmerFirstName.Substring(0, farmerDetail.FarmerFirstName.Length)) + "far" + farmerDetail.CreatedDate.Value.Day + farmerDetail.CreatedDate.Value.Month + farmerDetail.CreatedDate.Value.Year;
                db.FarmerDetails.Add(farmerDetail);
                SaveChanges();
                return farmerDetail;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update farmer detail
        /// </summary>
        /// <param name="farmerDetail"></param>
        /// <returns></returns>
        public FarmerDetail UpdateFarmerDetail(FarmerDetail farmerDetail)
        {
            try
            {

                FarmerDetail farmerDetailExisting = GetFarmerDetailById(farmerDetail.Id);
                farmerDetailExisting.DAP = farmerDetail.DAP;
                farmerDetailExisting.DealerId = farmerDetail.DealerId;
                farmerDetailExisting.DryLandFields = farmerDetail.DryLandFields;
                farmerDetailExisting.FarmerAddress = farmerDetail.FarmerAddress;
                farmerDetailExisting.FarmerDealerFertilizer = farmerDetail.FarmerDealerFertilizer;
                farmerDetailExisting.FarmerDealerPesticides = farmerDetail.FarmerDealerPesticides;
                farmerDetailExisting.FarmerDealerSeeds = farmerDetail.FarmerDealerSeeds;
                farmerDetailExisting.FarmerFirstName = farmerDetail.FarmerFirstName;
                farmerDetailExisting.FarmerLastName = farmerDetail.FarmerLastName;
                farmerDetailExisting.FarmerMiddleName = farmerDetail.FarmerMiddleName;
                farmerDetailExisting.FarmerTypeId = farmerDetail.FarmerTypeId;
                farmerDetailExisting.FertiCons = farmerDetail.FertiCons;
                farmerDetailExisting.Id = farmerDetail.Id;
                farmerDetailExisting.IrrigatedFields = farmerDetail.IrrigatedFields;
                farmerDetailExisting.LandTotal = farmerDetail.LandTotal;
                farmerDetailExisting.LastUpdate = DateTime.Now;
                farmerDetailExisting.MobileNumber = farmerDetail.MobileNumber;
                farmerDetailExisting.PocketId = farmerDetail.PocketId;
                farmerDetailExisting.Potash = farmerDetail.Potash;
                farmerDetailExisting.RegistrationDate = farmerDetail.RegistrationDate;
                farmerDetailExisting.SampleDemoDetails = farmerDetail.SampleDemoDetails;
                farmerDetailExisting.SourceId = farmerDetail.SourceId;
                farmerDetailExisting.Urea = farmerDetail.Urea;

                db.Entry(farmerDetailExisting).State = System.Data.Entity.EntityState.Modified;
                SaveChanges();
                return farmerDetailExisting;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private int SaveChanges()
        {
          return  db.SaveChanges();
        }
    }
}
