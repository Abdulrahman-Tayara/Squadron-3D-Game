using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface ISessionsRepository {

    Task<Session> getSavedSession();

    Task<Session> getSessionById(int id);



}

