using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
    public GameObject target;
    public GameObject player;
    public bool active;
    public Vector3 offset;
    public bool searchPerm;
    
	// Use this for initialization
	void Start () {
        if (searchPerm)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            SetTarget(player);
            if(player != null)
            {
                active = true;
            }
        }
	}
    

	// Update is called once per frame
	void Update () {
        if (active)
        {
            FollowTarget();
        }
	}

    public void SetActive()
    {
        if (!active)
        {
            active = true;
        }
        else
        {
            active = false;
        }
    }

    public void SetPlayer(GameObject g)
    {
        player = g;
        SetTarget(player);
    }

    void SetTarget(GameObject g)
    {
        target = g;
    }

    void FollowTarget ()
    {
        transform.position = target.transform.position + offset;
    }
}
