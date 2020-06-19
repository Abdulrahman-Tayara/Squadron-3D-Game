using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreMenu : MonoBehaviour
{

    private Sprite[] planeSprites = new Sprite[8];
    private string[] planePathes = new string[]{
        "Images/plane1",
        "Images/plane3",
        "Images/plane4"
    };
    private int index = 0;

    private string[,] arrOfInfo = new string[,]{
        {
            "Plane 1",
            "Attack 50%",
            "Armor 20%",
            "Speed 70%",
            "Price 100"
        },
        {
            "Plane 2",
            "Attack 60%",
            "Armor 40%",
            "Speed 65%",
            "Price 175"
        },
        {
            "Plane 3",
            "Attack 65%",
            "Armor 20%",
            "Speed 75%",
            "Price 250"
        }
    };

    public void Start()
    {
        for(int i = 0; i < planePathes.Length; i++) {
            planeSprites[i] = Resources.Load<Sprite>(planePathes[i]);
        }
    }

    public void right()
    {
        index++;
        index %= planePathes.Length;
        makeChanges(index);
    }

    public void left()
    {
        index--;
        index %= planePathes.Length;
        makeChanges(index >= 0 ? index : -index);
    }

    private void makeChanges(int index)
    {
        GameObject slide = this.transform.GetChild(0).gameObject
                               .transform.GetChild(0).gameObject
                               .transform.GetChild(0).gameObject;

        GameObject infoList = this.transform.GetChild(1).gameObject
                                  .transform.GetChild(0).gameObject;

        slide.GetComponent<Image>().sprite = planeSprites[index];
        editInfoItems(infoList, index);
    }

    private void editInfoItems(GameObject infoList, int index) {
        for(int i = 0; i < infoList.transform.childCount; i++) {
            GameObject child = infoList.transform.GetChild(i).gameObject;
            child.GetComponent<TextMeshProUGUI>().text = arrOfInfo[index, i];
        }
    }
}
