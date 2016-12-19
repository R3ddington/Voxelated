using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TreantBoss : MonoBehaviour {
    public int health;
    public bool dead;
    public int maxHealth;
    public GameObject hpBar;
    public GameObject hpBarParent;
    public Animator anim;

    public Camera cutsceneCam;
    public Camera mainCam;
    public Animator cutSceneAnim;

    public GameObject player;
    public int step = -1;

    public GameObject targeter;
    public GameObject rootAttackPrefab;
    public bool targetMode;
    public bool moveRootsMode;
    public bool moveRootsModeDown;
    public GameObject activeRoots;
    public int movingInt;
    public Animator fade;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}


	// Update is called once per frame
	void Update () {
        if (targetMode)
        {
            Targeting();
        }
        if (moveRootsMode)
        {
            MoveRootsUp();
        }
        if (moveRootsModeDown)
        {
            RootsDown();
        }
	}

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
                StartCoroutine(RunWaiting(2));
                break;
            case 2:
                RootAttack(0);
                break;
        }
    }

    public void RootAttack (int i)
    {
        switch (i)
        {
            case 0:
                print("Activated targeting mode");
                targetMode = true;
                StartCoroutine(RootTimer(i, 2f));
                break;
            case 1:
                //Wait a second to give player time to dodge
                targetMode = false;
                anim.SetTrigger("Stomp");
                StartCoroutine(RootTimer(i, 0.5f));
                break;
            case 2:
                print("Activated RootsUp mode");
                RootsUp();
                StartCoroutine(RootTimer(i, 5f));
                break;
            case 3:
                print("Activated RootsDown mode");
                moveRootsModeDown = true;
                StartCoroutine(RootTimer(i, 4f));
                break;
        }
    }

    IEnumerator RootTimer (int i, float w)
    {
        yield return new WaitForSeconds(w);
        if(i != 3)
        {
            i++;
        }
        else
        {
            i = 0;
        }
        if (!dead)
        {
            RootAttack(i);
        }
    }

    public void Targeting()
    {
        targeter.transform.position = new Vector3(player.transform.position.x, targeter.transform.position.y, player.transform.position.z);
    }

    public void MoveRootsUp ()
    {
        if(movingInt < 50)
        {
            activeRoots.transform.Translate(0, 0, 1);
            movingInt++;
        }
        else
        {
            movingInt = 0;
            moveRootsMode = false;
        }
    }

    public void RootsUp ()
    {
        activeRoots = Instantiate(rootAttackPrefab, targeter.transform.position, rootAttackPrefab.transform.rotation) as GameObject;
        moveRootsMode = true;
    }

    public void RootsDown ()
    {
        if (movingInt < 50)
        {
            activeRoots.transform.Translate(0, 0, -1);
            movingInt++;
        }
        else
        {
            movingInt = 0;
            moveRootsModeDown = false;
            Destroy(activeRoots);
        }
    }

    public void Hit(int i)
    {
        health -= i;
        hpBar.transform.GetComponent<LifeBar>().Damage(maxHealth, i);
        if (health <= 0)
        {
            if (!dead)
            {
                dead = true;
                RootAttack(3);
                anim.SetBool("Death", true);
                player.GetComponent<CharacterScript>().levelNumber = 1;
                fade.SetTrigger("FadeOut");
                StartCoroutine(WaitForTP());
            }
        }
    }

    IEnumerator WaitForTP()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(7);
    }
}