using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Serializable]
public class BuyAirplaneRequest {
    [JsonProperty("user_id")]
    public int userId { set; get; }
    [JsonProperty("plane_id")]
    public int airplaneId { set; get; }
    [JsonProperty("price")]
    public int airplanePrice { set; get; }

    public BuyAirplaneRequest(int userId, int airplaneId, int airplanePrice) {
        this.userId = userId;
        this.airplaneId = airplaneId;
        this.airplanePrice = airplanePrice;
    }
}

