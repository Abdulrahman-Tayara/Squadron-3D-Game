using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Radar : MonoBehaviour {
    // Singleton
    private static Radar instance;
    public static Radar getInstance() {
        return instance;
    }

    public Transform center;
    [SerializeField, Range(0, 1)]
    private float mapScale = 0.1f;

    private List<RadarObject> radarObjects = new List<RadarObject>();
    public void registerRadarObject(GameObject gameObject, Image image) {
        Image imageClone = Instantiate(image);
        this.radarObjects.Add(new RadarObject(gameObject, imageClone));
        if (gameObject.CompareTag("Airplane")) {
            this.center = gameObject.transform;
        }
    }
    public void deregisterRadarObject(GameObject gameObject) {
        this.radarObjects.RemoveAll(item => {
            bool result = item.getOwner() == gameObject;
            if (result)
                if (!item.getIcon().IsDestroyed())
                    Destroy(item.getIcon().gameObject);
            return result;
        });
    }

    public void drawRadarDots() {
        foreach (RadarObject radarObject in this.radarObjects) {
            Vector3 radarPosition = (radarObject.getOwner().transform.position - this.center.position);
            float distanceToObject = Vector3.Distance(this.center.position, radarObject.getOwner().transform.position) * this.mapScale;
            float deltaY = Mathf.Atan2(radarPosition.x, radarPosition.z) * Mathf.Rad2Deg - 270 - this.center.eulerAngles.y;
            radarPosition.x = distanceToObject * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
            radarPosition.z = distanceToObject * Mathf.Sin(deltaY * Mathf.Deg2Rad);

            radarObject.getIcon().transform.SetParent(this.transform);
            radarObject.getIcon().transform.position = new Vector3(radarPosition.x, radarPosition.z, 0) + this.transform.position;
        }
    }

    void Update() {
        this.drawRadarDots();
    }

    void Awake() {
        instance = this;
    }

    //public void setCenter(Transform center) {
    //    this.center = center;
    //}

    public class RadarObject {
        private Image icon;
        private GameObject owner;

        public RadarObject(GameObject owner, Image icon) {
            this.owner = owner;
            this.icon = icon;
        }

        public GameObject getOwner() {
            return this.owner;
        }
        public Image getIcon() {
            return this.icon;
        }
    }

}
