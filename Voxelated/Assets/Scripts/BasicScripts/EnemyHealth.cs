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

    public void Hit(int i)
    {
        health -= i;
        hpBar.transform.GetComponent<LifeBar>().Damage(maxHealth, i);
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
                }
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
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(7);
    }
}
