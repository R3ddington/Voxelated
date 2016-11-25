using UnityEngine;
using System.Collections;

public class AudioMaster : MonoBehaviour {

    public AudioSource aSource;
    public AudioClip[] clip;

    void Start()
    {
        DontDestroyOnLoad(this);
        aSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound (int i)
    {
        /*
        switch (i)
        {
            case 0:
                //ClickSound
                aSource.clip = clip[0];
                break;
            case 1:
                //JumpSound
                aSource.clip = clip[1];
                break;
            case 2:
                //KatanaSound
                aSource.clip = clip[2];
                break;
        }
        */
        aSource.clip = clip[i];
        aSource.Play();
    }

    public void PlayDelay (int i, float w)
    {
        StartCoroutine(DelayedSound(i, w));
    }

    IEnumerator DelayedSound (int i, float w)
    {
        yield return new WaitForSeconds(w);
        aSource.clip = clip[i];
        aSource.Play();
    }
}