using Assets.Code.ui.ranks.mvp;
using Assets.Code.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RanksMenu : MonoBehaviour, RanksView {
    private RanksPresenter presenter;
    private ListViewAdapter<Rank> ranksListView;
    private List<Rank> ranks;
    private Rank userRank;

    public RectTransform container;
    public GameObject listItem;
    public TextMeshProUGUI userRankText;

    private void OnEnable() {
        presenter = Injector.injectRanksPresenter(this);
        presenter.getRanks();
    }

    private void OnDisable() {
        clearData();
    }

    private void OnDestroy() {
        clearData();
    }

    private void clearData() {
        ranks.Clear();
        ranksListView.clearList();
        ranksListView.notifiyDataChanged();
    }

    private void buildList() {        
        ranksListView = new ListViewAdapter<Rank>(container, listItem, (item, rank, position) => {
            item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = rank.username; // userName
            item.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = rank.rankValue.ToString(); // score
            item.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = rank.order.ToString(); // order
            if (rank == userRank)
                item.GetComponent<Image>().color = Color.cyan;
        });
        ranksListView.data = ranks;
        ranksListView.notifiyDataChanged();
    }
    
    // Called from presenter
    public void setRanks(List<Rank> ranks, Rank userRank) {
        this.ranks = ranks;
        this.userRank = userRank;
        buildList();
        userRankText.text = userRank.order.ToString();
    }
}
