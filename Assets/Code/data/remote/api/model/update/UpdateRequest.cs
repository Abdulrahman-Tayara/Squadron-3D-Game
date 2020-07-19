using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Serializable]
public class UpdateRequest {
    [JsonProperty("user_id")]
    public int userId;
    public int score;
    public int coins;

    public UpdateRequest(int userId, int score, int coins) {
        this.userId = userId;
        this.score = score;
        this.coins = coins;
    }
}


