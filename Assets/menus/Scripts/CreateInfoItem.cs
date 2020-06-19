using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateInfoItem : MonoBehaviour
{
    public GameObject infoItem;

    private string[] info = new string[]{
        "Plane 1",
        "Attack 50%",
        "Armor 20%",
        "Speed 70%",
        "Price 100"
    };
    // Start is called before the first frame update
    void Start()
    {
        int top = -43;
        foreach(string s in info) {
            GameObject item = Instantiate(
                infoItem, 
                new Vector3(0, top, 0), 
                Quaternion.identity
            );

            item.GetComponent<TextMeshProUGUI>().text = s;
            item.transform.SetParent(this.transform.GetChild(0).gameObject.transform, false);
            top -= 50;
        }
    }
}
