using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class FAaddressDetailOperations:IFAaddressDetailOperations
    {
        DBentities db = new DBentities();
        public int InsertFAAddressDetail(FAaddressDetail faAddressDetail)
        {
            try
            {
                db.FAaddressDetails.Add(faAddressDetail);
                db.SaveChanges();
                return faAddressDetail.Id;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public int RemoveFAaddressDetail(int FAid)
        {
            try
            {
               List<FAaddressDetail> addressDetailList = db.FAaddressDetails.Select(x => x).Where(x => x.FAdetailId == FAid).ToList();
                if(addressDetailList.Count>0)
                {
                    foreach(var address in addressDetailList)
                    {
                        db.FAaddressDetails.Remove(address);
                    }
                }
              return  db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int UpdateFAaddressDetail(List<FAaddressDetail> addressDetailList)
        {

            try
            {
                int faId = addressDetailList.ElementAt(0).FAdetailId.Value;
                List<FAaddressDetail> ExistingAddressList = db.FAaddressDetails.Select(x => x).Where(x => x.FAdetailId == faId).ToList();

                List<FAaddressDetail> AddressListToAdd = new List<FAaddressDetail>();
                List<FAaddressDetail> AddressListToUpdate = new List<FAaddressDetail>();
                List<FAaddressDetail> AddressListToDelete = new List<FAaddressDetail>();

                foreach (var address in addressDetailList)
                {
                    FAaddressDetail newAddress = ExistingAddressList.Select(x => x).Where(x => x.Id == address.Id).FirstOrDefault();
                    if (newAddress == null)
                    {
                        AddressListToAdd.Add(address);
                    }
                    else
                    {
                        AddressListToUpdate.Add(address);
                    }
                }
                foreach (var address in ExistingAddressList)
                {
                    FAaddressDetail existingAddress = addressDetailList.Select(x => x).Where(x => x.Id == address.Id).FirstOrDefault();
                    if (existingAddress == null)
                    {
                        AddressListToDelete.Add(address);
                    }
                }

                foreach (var address in AddressListToAdd)
                {
                    InsertFAAddressDetail(address);
                }
                foreach (var address in AddressListToDelete)
                {

                    //RemoveFAaddressDetail(address.Id);
                    FAaddressDetail adddtl = db.FAaddressDetails.Select(x => x).Where(x => x.Id == address.Id).FirstOrDefault();
                    db.FAaddressDetails.Remove(adddtl);
                }
                FAaddressDetail addressToUpdate;
                foreach (var address in AddressListToUpdate)
                {
                    addressToUpdate = ExistingAddressList.Select(x => x).Where(x => x.Id == address.Id).FirstOrDefault();
                    if (addressToUpdate != null)
                    {
                        addressToUpdate.Address = address.Address;
                        addressToUpdate.ContactNo = address.ContactNo;
                        addressToUpdate.District = address.District;
                        addressToUpdate.EmailId = address.EmailId;
                        addressToUpdate.MobileNo = address.MobileNo;
                        addressToUpdate.Pincode = address.Pincode;
                        addressToUpdate.SubDistrictId = address.SubDistrictId;
                        addressToUpdate.Village = address.Village;
                    }
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
