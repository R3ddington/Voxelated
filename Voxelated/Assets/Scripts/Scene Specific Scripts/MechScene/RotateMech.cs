using UnityEngine;
using System.Collections;

public class RotateMech : MonoBehaviour {
    public GameObject area;
    public int turnSpeed;
    public bool turning;
    public bool activated;
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            if (!activated)
            {
                activated = true;
                turning = true;
                Turn();
            }
        }
    }
    
    public void Turn ()
    {
        area.transform.rotation = Quaternion.Lerp(area.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * turnSpeed);
        if (area.transform.rotation.eulerAngles.y >= 89 && area.transform.rotation.eulerAngles.y <= 91)
        {
            area.transform.rotation = Quaternion.Euler(0, 90, 0);
            turning = false;
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(WaitForTurn());
        }
    }
    IEnumerator WaitForTurn()
    {
        yield return new WaitForSeconds(0.01f);
        Turn();
    }
}