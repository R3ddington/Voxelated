using UnityEngine;
using System.Collections;

public class InfoTrigger : MonoBehaviour {
    public GameObject info;
    void OnTriggerEnter(Collider c)
    {
        if(c.transform.tag == "Player")
        {
            info.SetActive(true);
            Destroy(gameObject);
            c.GetComponent<CharacterScript>().HitFreezeOn();
            c.GetComponent<CharacterScript>().Freeze();
        }
    }
}
