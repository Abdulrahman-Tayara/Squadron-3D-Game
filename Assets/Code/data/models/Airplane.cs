using System;
using UnityEngine;

[Serializable]
public class Airplane {
    public int id;
    public string name;
    public AirplaneAttributes attributes;

    public Airplane(int id, string name) {
        this.id = id;
        this.name = name;
        attributes = new AirplaneAttributes();
    }

    public override string ToString() {
        return "id: " + id + ", name: " + name + "\n";
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