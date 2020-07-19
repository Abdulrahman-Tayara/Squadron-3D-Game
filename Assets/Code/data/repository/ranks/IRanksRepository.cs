using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface IRanksRepository {
    Task<List<Rank>> getRanks();
}

