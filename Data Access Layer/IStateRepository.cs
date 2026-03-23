using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_9.Entity_Layer;

namespace Lab_9.Data_Access_Layer
{
    public interface IStateRepository
    {
        List<State> GetStates();
        List<City> GetCitiesByState(int stateId);
    }
}
