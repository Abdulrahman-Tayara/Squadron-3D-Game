using System;
using System.Collections.Generic;
using UnityEngine;

public class ListViewAdapter<T> {
    
    public List<T> data;
    public RectTransform container { private set; get; }
    public GameObject listItem { private set; get; }
    public BindItem bindItem { private set; get; }

    public float itemHeight;


    public ListViewAdapter(RectTransform container, GameObject listItem, BindItem bindItem) {
        this.container = container;
        this.bindItem = bindItem;
        this.listItem = listItem;
        this.itemHeight = listItem.GetComponent<RectTransform>().rect.height;
    }

    public int getItemsCount() => data == null ? 0 : data.Count;

    private void buildList() {
        clearList();
        int itemsCount = getItemsCount();
        container.offsetMin = new Vector2(container.offsetMin.x, -((RectTransform) (listItem.transform)).rect.height * itemsCount);
        for (int i = 0; i < itemsCount; ++i) {
            GameObject listItem = buildItem(i);
            if (listItem != null && container != null) {
                bindItem(listItem, data[i], i);
                listItem.transform.SetParent(container, false);
            }
        }
    }

    public void notifiyDataChanged() {
        buildList();
    }

    public void clearList() {
        for (int i = 0; i < container.transform.childCount; ++i) {
            GameObject.Destroy(container.transform.GetChild(i).gameObject);
        }
    }

    protected GameObject buildItem(int position) {
        Vector3 itemVector = new Vector3(listItem.transform.position.x, (itemHeight * (position)), listItem.transform.position.z);
        return GameObject.Instantiate(listItem, itemVector, Quaternion.identity);
    }

    public delegate void BindItem(GameObject listItem, T item, int position);
}

