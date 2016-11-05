using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DBContext;
using DataLayer.Interfaces;
namespace DataLayer.Impelmentation
{
    public class StateInfoOperations:IStateInfoOperations
    {
        DBentities db = new DBentities();
        public List<StateInfo> GetAllStates()
        {
            try
            {
                List<StateInfo> states = db.StateInfoes.Select(x => x).ToList();
                return states;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
