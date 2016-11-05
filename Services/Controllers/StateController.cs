using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.EntityClasses;
using DataLayer.Interfaces;
using DataLayer.Impelmentation;
using DataLayer.DBContext;
using Services.Common;
namespace Services.Controllers
{
    [RoutePrefix("api/State")]
    public class StateController : ApiController
    {
        public List<StateInfoEntities> GetAllStates()
        {
            try
            {
                IStateInfoOperations stateInfo = new StateInfoOperations();
                List<StateInfoEntities> states = MapEntities.MapList<StateInfo, StateInfoEntities>(stateInfo.GetAllStates());
                return states;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
