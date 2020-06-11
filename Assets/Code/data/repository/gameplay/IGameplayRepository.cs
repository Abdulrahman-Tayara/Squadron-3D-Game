using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGameplayRepository {
    Session getSavedSession();

    Task<Airplane> getAirplaneById(int id);
}

