using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Serializable]
public class User {
    public int id { set; get; }
    public string username { set; get; }
    public string email { set; get; }
    public int coins { set; get; }
    [JsonProperty("planes")]
    public List<int> airplanesId { set; get; }

    public User(int id, string username, string email, int coins, List<int> airplanesId) {
        this.id = id;
        this.username = username;
        this.email = email;
        this.coins = coins;
        this.airplanesId = airplanesId;
    }
}

