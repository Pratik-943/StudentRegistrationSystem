using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_9.Data_Access_Layer;
using Lab_9.Entity_Layer;

namespace Lab_9.Business_Access_Layer
{
    public class StateService
    {
        private IStateRepository repo;

        public StateService()
        {
            repo = new StateRepository();
        }

        public List<State> GetStates()
        {
            return repo.GetStates();
        }

        public List<City> GetCities(int stateId)
        {
            return repo.GetCitiesByState(stateId);
        }
    }
}