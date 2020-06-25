using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Code.ui.loadGame.mvp;
using Assets.Code.utils;
using UnityEngine.SceneManagement;
using System;

public class LoadGameMenu : MonoBehaviour, LoadGameView {

    private List<Session> sessions;
    private LoadGamePresenter presenter;
    private ListViewAdapter<Session> listView;

    public GameObject listContainer;
    public Button listButton;



    private void Start() {
        presenter = Injector.injectLoadGamePresenter(this);
        presenter.getSessions();
    }

    private void buildList() {
        listView = new ListViewAdapter<Session>(listContainer.GetComponent<RectTransform>(), listButton.gameObject, 
            (listObject, session) => {
            Button button = listObject.GetComponent<Button>();
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = session.sessionName;
            button.onClick.AddListener(() => presenter.selectSession(session));
        });
        listView.data = sessions;
        listView.notifiyDataChanged();
    }


    // Called from presneter

    public void setSessions(List<Session> sessions) {
        this.sessions = sessions;
        buildList();
    }

    public void sessionSelected(Session session) {
        SceneManager.LoadScene("GamePlayScene");
    }
}
