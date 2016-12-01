using UnityEngine;
using System.Collections;

public class MovingCubes : MonoBehaviour {

    public int amount;
    public Transform[] waypoints;
    public Transform target;
    public int targetNumber;
    public float speed;
    public bool oneWay;
	// Use this for initialization
	void Start () {
        target = waypoints[targetNumber];
        if (!oneWay)
        {
            Move();
        }
	}

    public void SetOn ()
    {
        target = waypoints[targetNumber];
        Move();
    }

    public void Move ()
    {
       // print("Moving");
       // print("Own Location" + " " + transform.position.ToString() + " " + "Target Location" + " " + target.position.ToString());
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        if (transform.position == target.position) //WERKT SOMS NIET
        {
            NextWayPoint();
        }
        else if (transform.position.ToString() == target.position.ToString()) //WERKT ALTIJD
        {
            NextWayPoint();
        }
        else
        {
            StartCoroutine(WaitForMove());
        }
    }
    void NextWayPoint()
    {
        //   print("Setting New Waypoint");
        if (oneWay)
        {
            return;
        }
        if(targetNumber == amount)
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
    IEnumerator WaitForMove ()
    {
        yield return new WaitForSeconds(0.01f);
        Move();
    }
}