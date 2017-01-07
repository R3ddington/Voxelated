using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcade_Boss : MonoBehaviour {

    public int amount;
    public Vector3[] waypoints;
    public Vector3 target;
    public int targetNumber;
    public float speed;

    void Start()
    {
        target = waypoints[targetNumber];
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {    
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
        if (transform.position == target) //WERKT SOMS NIET
        {
            NextWayPoint();
        }
        else if (transform.position.ToString() == target.ToString()) //WERKT ALTIJD
        {
            NextWayPoint();
        }
    }
    void NextWayPoint()
    {
        if (targetNumber == amount)
        {
            targetNumber = 0;
        }
        else
        {
            targetNumber++;
        }
        target = waypoints[targetNumber];
        Move();
    }

}
