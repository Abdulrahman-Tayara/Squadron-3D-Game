using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadGameMenu : MonoBehaviour {
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public Button listButton;
    public ListViewAdapter<string> listView;
    private string[] arr = new string[] {
        "Saved game 1",
        "Saved game 2",
        "Saved game 3",
        "Saved game 4",
        "Saved game 5",
        "Saved game 6",
        "Saved game 7",
        "Saved game 8",
        "Saved game 9",
        "Saved game 10",
    };

    // This script will simply instantiate the Prefab when the game starts.
    void Start() {
        buildList();
    }

    private void buildList() {
        GameObject parent = this.transform.GetChild(0).gameObject  // Scroll View
                        .transform.GetChild(0).gameObject  // Viewport
                        .transform.GetChild(0).gameObject; // Content
        
        listView = new ListViewAdapter<string>(parent.GetComponent<RectTransform>(), listButton.gameObject,
            (listObject, data) => {
                listObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = data;
                listObject.GetComponent<Button>().onClick.AddListener(() => {
                    Debug.Log(data);
                });
            });
        listView.data = new List<string>(arr);
        listView.notifiyDataChanged();
    }
}
