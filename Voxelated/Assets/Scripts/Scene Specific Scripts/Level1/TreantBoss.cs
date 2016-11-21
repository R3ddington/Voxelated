using UnityEngine;
using System.Collections;

public class TreantBoss : MonoBehaviour {
    public int health;
    public int maxHealth;
    public GameObject hpBar;
    public GameObject hpBarParent;
    public Animator anim;

    public Camera cutsceneCam;
    public Camera mainCam;
    public Animator cutSceneAnim;

    public GameObject player;
    public int step = -1;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    /*
	// Update is called once per frame
	void Update () {
	
	}
    */
    public void StartBattle ()
    {
        cutsceneCam.enabled = true;
        mainCam.enabled = false;
        cutSceneAnim.SetTrigger("Active");
        StartCoroutine(RunWaiting(3));
    }

    IEnumerator RunWaiting (int i)
    {
        yield return new WaitForSeconds(i);
        step++;
        RunBattle();
    }

    public void RunBattle ()
    {
        switch (step)
        {
            case 0:
                anim.SetTrigger("Life");
                StartCoroutine(RunWaiting(2));
                break;
            case 1:
                cutsceneCam.enabled = false;
                mainCam.enabled = true;
                hpBarParent.SetActive(true);
                player.transform.position = new Vector3(5032, -142, -2992);
                break;
            case 2:

                break;
        }
    }

    public void Hit(int i)
    {
        health -= i;
        hpBar.transform.GetComponent<LifeBar>().Damage(maxHealth, i);
        if (health <= 0)
        {
            //Play death animation
            //   Destroy(gameObject);
            anim.SetBool("Death", true);
        }
    }
}
