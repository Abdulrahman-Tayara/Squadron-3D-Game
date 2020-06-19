using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Session {
    public int id;
    public int airplaneId;
    public int environmentId;
    public string sessionName;
    public GameState gameState;

    public Session(int airplaneId, int environmentId, string sessionName, GameState gameState) {
        this.id = DateTime.Now.Millisecond;
        this.airplaneId = airplaneId;
        this.environmentId = environmentId;
        this.sessionName = sessionName;
        this.gameState = gameState;
    }

}

