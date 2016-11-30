using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
    public GameObject target;
    public GameObject player;
    public bool active;
    public Vector3 offset;
    public bool searchPerm;

    public GameObject fakePlayer;
    public GameObject fakeHud;
    public Transform playerPos;
    
	// Use this for initialization
	void Start () {
        GameObject reloader = GameObject.FindGameObjectWithTag("Reload");
        if(reloader != null)
        {
            reloader.GetComponent<SceneReload>().DoLoad();
        }
        if (searchPerm)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                fakePlayer.SetActive(true);
                player = GameObject.FindGameObjectWithTag("Player");
            }
            if(!player.GetComponent<CharacterScript>().reloaded)
            {
                print("reloaded is false");
                player.transform.position = playerPos.position;
                player.transform.rotation = playerPos.rotation;
                print("Changed Pos in cam follow script");
            }
            else
            {
                print("Set reload on false, didnt change pos in cam follow script");
                player.GetComponent<CharacterScript>().reloaded = false;
             //   player.transform.position = player.GetComponent<CharacterScript>().checkpointPos;
            }
            player.GetComponent<CharacterScript>().hitFreeze = false;
            player.GetComponent<CharacterScript>().freeze = false;
            SetTarget(player);
            if(player != null)
            {
                active = true;
            }
            GameObject hud = GameObject.FindGameObjectWithTag("Hud");
                if(hud == null)
                {
                    fakeHud.SetActive(true);
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