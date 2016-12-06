using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    LineRenderer line;
    public float incLengthCast;
    public float coolDownTime;
    public bool locked;
    public bool cooldown;
    public int dealDamage;
    public GameObject hud;

    // Use this for initialization
    void Start () {
        hud = GameObject.FindGameObjectWithTag("Hud");
        if(hud == null)
        {
            print("WARNING HUD IS NULL IN LASERSCRIPT");
        }
        line = gameObject.GetComponent<LineRenderer>();
        incLengthCast = 0;
        dealDamage = 1;

       // Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (incLengthCast >= 100)
        {
            line.enabled = false;
            incLengthCast = 0;
            if (!cooldown)
            {
                cooldown = true;
                StartCoroutine(CoolDown());
            }
        }
        else
        {
            if (!locked)
            {
                FireLaser();
            }
        }
	}

    public void Lock (int i)
    {
        switch (i)
        {
            case 0:
                locked = false;
                break;
            case 1:
                locked = true;
                if (line != null)
                {
                    if (line.enabled)
                    {
                        line.enabled = false;
                    }
                }
                break;
        }
    }
    public void FireLaser()
    {
        if (cooldown)
        {
            return;
        }
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
                if(hud == null)
                {
                    hud = GameObject.FindGameObjectWithTag("Hud");
                }
                hud.GetComponent<PlayerHUD>().AmmoAndGunReduct(incLengthCast);
                if (Physics.Raycast(ray, out hit, incLengthCast))
                {
                    line.SetPosition(1, hit.point);
                    DealDamage(hit);
                }
                else
                {
                    line.SetPosition(1, ray.GetPoint(incLengthCast));
                }
            }
            else
            {
                if (!cooldown)
                {
                    cooldown = true;
                    StartCoroutine(CoolDown());
                }
                incLengthCast = 0;
                //StopCoroutine("FireLaser");
                line.enabled = false;
            }
        }
        else
        {
            if(incLengthCast > 0)
            {
                if (!cooldown)
                {
                    cooldown = true;
                    StartCoroutine(CoolDown());
                }
                incLengthCast = 0;
                line.enabled = false;
            }
        }
    } 

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        cooldown = false;
        hud.GetComponent<PlayerHUD>().AddAmmo();
    }

    public void DealDamage (RaycastHit h)
    {
        if(h.transform.tag == "Dummy")
        {
            h.transform.GetComponent<DummyScript>().Hit(dealDamage);
        }
        if(h.transform.tag == "Spider")
        {
            h.transform.GetComponent<SpiderTemp>().Hit(dealDamage);
        }
    }
}