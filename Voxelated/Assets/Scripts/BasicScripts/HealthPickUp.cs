using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {

    int health;
    Transform location;
    public GameObject prefab;

    public HealthPickUp(int h, Transform pos) {
        health = h;
        location = pos;
        //Do instantiate at pos
    }
}
