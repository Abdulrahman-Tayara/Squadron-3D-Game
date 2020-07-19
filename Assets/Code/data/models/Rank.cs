using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Serializable]
public class Rank {
    [JsonProperty("value")]
    public int rankValue { set; get; }
    [JsonProperty("user_id")]
    public int userId { set; get; }

    public string username { set; get; }

    public int order { set; get; }

    public Rank(int rankValue, int userId, string username) {
        this.rankValue = rankValue;
        this.userId = userId;
        this.username = username;
    }
}

