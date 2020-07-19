using System;
using UnityEngine;

[Serializable]
public class Airplane {
    public int id;
    public string name;
    public int price;
    public bool userHasIt = false;
    public AirplaneAttributes attributes;

    public Airplane(int id, string name, int price) {
        this.id = id;
        this.name = name;
        this.price = price;
        attributes = new AirplaneAttributes();
    }


    [Serializable]
    public class AirplaneAttributes {
        public float maxHealth;
        public float speed;
        public float maxSpeed;
        public float minSpeed;
        public float specialDamage;
        public float basicDamage;
    }
}