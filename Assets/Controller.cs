using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Controller : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        readJson();
    }

    // Update is called once per frame
    void Update() {

    }

    private void readJson() {
        StreamReader stream = new StreamReader(ResourcesPath.AIRPLANES_FILE);
        string data = stream.ReadToEnd();
        Debug.Log("Json data : " + data);
        List<Airplane> airplanes =  JsonMapper.getInstance().fromJsonArray<Airplane>(data);
        Debug.Log("Airplane : " + airplanes[0].attributes.speed);
    }
}
