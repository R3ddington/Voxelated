using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour {
    public int health;
    public int maxHealth;
    public GameObject hpBar;
    public GameObject deathParticle;
    public bool destroyMore;
    public string specialCode;
    public Animator fade;
    public bool dontDestroy;
    public GameObject extraObject;
    public Animator extraAnim;

    public AudioSource aSource;
    public AudioClip[] clip;

    public void Start ()
    {
        aSource = gameObject.GetComponent<AudioSource>();
        if(aSource != null)
        {
            aSource.clip = clip[0];
        }   
    }

    public void Hit(int i)
    {
        health -= i;
        hpBar.transform.GetComponent<LifeBar>().Damage(maxHealth, i);
        if(aSource != null)
        {
            aSource.Play();
        }
        if (health <= 0)
        {
            //Play death animation
            Instantiate(deathParticle, transform.transform.position, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<CharacterScript>().AddQubits(5);
            if(specialCode != null)
            {
                switch (specialCode)
                {
                    case "lavaBoss":
                        player.GetComponent<CharacterScript>().levelNumber = 2;
                        fade.SetTrigger("FadeOut");
                        StartCoroutine(WaitForTP());
                        break;
                    case "arcadeBoss":
                        //Do arcade boss death cutscene
                        //Remove minigame canvas
                        //set level to 3
                        //wait for tp
                        transform.SetParent(player.transform);
                        transform.position = new Vector3(5000, 5000, 0);
                        player.GetComponent<CharacterScript>().levelNumber = 3;
                        extraObject.SetActive(false);
                        fade.SetTrigger("FadeIn");
                        StartCoroutine(WaitForExtraAnim());
                        break;
                }
            }
            if (dontDestroy)
            {
                return;
            }
            if (!destroyMore)
            {
                Destroy(gameObject);
            }
            else
            {
                GameObject parentObject = transform.parent.gameObject;
                Destroy(parentObject);
            }
        }
    }
    IEnumerator WaitForTP()
    {
        print("Loading scene");
        yield return new WaitForSeconds(3);
        print("Passed yield");
        SceneManager.LoadScene(7);
    }
    IEnumerator WaitForExtraAnim()
    {
        yield return new WaitForSeconds(2);
        extraAnim.SetBool("Dead", true);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CharacterScript>().FreezeOff();
        transform.parent = null;
        yield return new WaitForSeconds(1);
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(7);
    }
}
