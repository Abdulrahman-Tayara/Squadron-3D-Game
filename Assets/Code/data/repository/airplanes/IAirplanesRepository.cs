using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface IAirplanesRepository {
    Task<Airplane> getAirplaneById(int id);

    Task<List<Airplane>> getAirplanes();
}

