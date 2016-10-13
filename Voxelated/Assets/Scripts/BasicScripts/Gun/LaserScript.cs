using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    LineRenderer line;
    public float incLengthCast;
    public float coolDownTime;


	// Use this for initialization
	void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        incLengthCast = 0;

       // Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
            if (incLengthCast >= 100)
            {
                //StartCoroutine(CoolDownSystemLaser());
                line.enabled = false;
                incLengthCast = 0;
            }
            else
            {
                FireLaser();

            }
            
	
	}
    public void FireLaser()
    {
        if (Input.GetButton("Fire1"))
        {
            if (incLengthCast <= 100)
            {
                incLengthCast += 150 * Time.deltaTime;
                line.enabled = true;
                line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                line.SetPosition(0, ray.origin);
                if (Physics.Raycast(ray, out hit, incLengthCast))
                {
                    line.SetPosition(1, hit.point);
                    //StartCoroutine(CoolDownSystemLaser());
                }
                else
                {
                    line.SetPosition(1, ray.GetPoint(incLengthCast));
                }
            }
             else
            {
                incLengthCast = 0;
                //StopCoroutine("FireLaser");
                line.enabled = false;
                //StartCoroutine(CoolDownSystemLaser());
            }
        }
        else
        {
            incLengthCast = 0;
            line.enabled = false;
        }
    } 

    /*IEnumerator CoolDownSystemLaser()
    {
        yield return new WaitForSeconds(coolDownTime);
        incLengthCast = 0;
    }*/
    
}
