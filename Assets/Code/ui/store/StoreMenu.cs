using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Assets.Code.ui.store.mvp;
using Assets.Code.utils;
public class StoreMenu : MonoBehaviour, StoreView {
    private StorePresenter presenter;
    private List<Airplane> airplanes;
    private int userCoins;

    private int airplaneIndex = 0;

    public TextMeshProUGUI userCoinsText, airplaneNameText, airplanePriceText, airplaneSpeed,
         airplaneBasicDamageText, airplaneSpecialDamageText, airplaneStatusText;
    public Image airplanePhoto;
    public Button buyButton;
    private List<Sprite> airplanesSprites = new List<Sprite>();

    private void OnEnable() {
        presenter = Injector.injectStorePresenter(this);
        presenter.getUserCoins();
        presenter.getAirplanes();
    }

    public void rightAirplane() {
        airplaneIndex++;
        airplaneIndex %= airplanes.Count;
        changeAirplane();
    }

    public void leftAirplane() {
        airplaneIndex = airplaneIndex - 1 < 0 ? airplanes.Count - 1 : airplaneIndex - 1;
        changeAirplane();
    }

    private void changeAirplane() {
        if (airplaneIndex > airplanes.Count)
            return;
        Airplane airplane = airplanes[airplaneIndex];
        airplanePhoto.sprite = airplanesSprites[airplaneIndex];
        airplaneNameText.text = airplane.name;
        airplanePriceText.text = airplane.price.ToString();
        airplaneSpeed.text = airplane.attributes.maxSpeed.ToString();
        airplaneBasicDamageText.text = airplane.attributes.basicDamage.ToString();
        airplaneSpecialDamageText.text = airplane.attributes.specialDamage.ToString();
        buyButton.interactable = userCoins >= airplane.price && !airplane.userHasIt;

        if (airplane.userHasIt) {
            airplaneStatusText.text = "You have this airplane";
            airplaneStatusText.color = Color.green;
        } else if (airplane.price > userCoins) {
            airplaneStatusText.text = "You can't but it now!";
            airplaneStatusText.color = Color.red;
        } else {
            airplaneStatusText.text = "";
        }
    }

    public void buyAirplane() {
        Airplane airplane = airplanes[airplaneIndex];
        presenter.buyAirplane(airplane);
    }


    // Called from presenter

    public void setAirplanes(List<Airplane> airplanes) {
        this.airplanes = airplanes;
        airplanesSprites.Clear();
        airplanes.ForEach(airplane => airplanesSprites.Add(Resources.Load<Sprite>(ResourcesPath.AIRPLANES_IMAGES + airplane.id)));
        changeAirplane();
    }

    public void setCoins(int coins) {
        this.userCoins = coins;
        userCoinsText.text = userCoins.ToString();
    }
}
