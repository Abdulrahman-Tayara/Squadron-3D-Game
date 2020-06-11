using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Session {
    public int airplaneId;
    public int environmentId;
    public string sessionName;
    public GameState gameState;

    public Session(int airplaneId, int environmentId, string sessionName, GameState gameState) {  
        this.airplaneId = airplaneId;
        this.environmentId = environmentId;
        this.sessionName = sessionName;
        this.gameState = gameState;
    }

}

