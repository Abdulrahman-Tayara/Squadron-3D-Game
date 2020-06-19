using UnityEngine;
using UnityEngine.UI;

public class NewGameMenu : MonoBehaviour
{
    private Sprite[] planeSprites = new Sprite[8];
    private Sprite[] mapSprites = new Sprite[8];
    private string[] planePathes = new string[]{
        "Images/plane1",
        "Images/plane3",
        "Images/plane4"
    };
    private string[] mapPathes = new string[]{
        "Images/map",
        "Images/map2",
        "Images/map3"
    };
    
    private int indexPlane = 0;
    private int indexMap = 0;

    public void Start() 
    {
        for(int i = 0; i < planePathes.Length; i++) {
            planeSprites[i] = Resources.Load<Sprite>(planePathes[i]);
        }

        for(int i = 0; i < mapPathes.Length; i++) {
            mapSprites[i] = Resources.Load<Sprite>(mapPathes[i]);
        }
    }

    public void rightPlane()
    {
        indexPlane++;
        indexPlane %= planePathes.Length;
        makeChanges(indexPlane);
    }

    public void leftPlane()
    {
        indexPlane--;
        indexPlane %= planePathes.Length;
        makeChanges(indexPlane >= 0 ? indexPlane : -indexPlane);
    }

    public void rightMap()
    {
        indexMap++;
        indexMap %= mapPathes.Length;
        makeChanges(indexMap, false);
    }

    public void leftMap()
    {
        indexMap--;
        indexMap %= mapPathes.Length;
        makeChanges(indexMap >= 0 ? indexMap : -indexMap, false);
    }

    private void makeChanges(int index, bool plane = true)
    {
        Debug.Log(index);
        if(plane) {
            GameObject planeSlide = this.transform.GetChild(0).gameObject
                                .transform.GetChild(0).gameObject
                                .transform.GetChild(0).gameObject;

            planeSlide.GetComponent<Image>().sprite = planeSprites[index];
        } else {
            GameObject mapSlide = this.transform.GetChild(1).gameObject
                                        .transform.GetChild(0).gameObject
                                        .transform.GetChild(0).gameObject;

            mapSlide.GetComponent<Image>().sprite = mapSprites[index];
        }
    }
}
