using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface IStoreRepository {
    Task<List<Airplane>> getStoreAirplanes();

    Task<bool> buyAirplane(Airplane airplane);
}

