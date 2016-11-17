using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {
    public int health;
    public int maxHealth;
    public GameObject hpBar;

    public void Hit(int i)
    {
        health -= i;
        hpBar.transform.GetComponent<LifeBar>().Damage(maxHealth, i);
        if (health <= 0)
        {
            //Play death animation
            Destroy(gameObject);
        }
    }
}
