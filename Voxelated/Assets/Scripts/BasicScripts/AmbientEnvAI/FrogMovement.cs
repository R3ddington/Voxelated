using UnityEngine;
using System.Collections;
using System;

public class FrogMovement : MonoBehaviour {
    public FrogAI frog;
    public Vector3 jumping;
    public bool stretched = true;
    public float frogScale;
	// Use this for initialization
	void Start () {
        frog = new FrogAI(-1, 0, false);
	}
	
	// Update is called once per frame
	void Update () {
        FrogMoving();
        FrogStretchMove();
	}
    [Serializable]
    public class FrogAI
    {
        public float frogSpeed;
        public int frogScareZone;
        public bool frogScared = false;

        public FrogAI(float _frogSpeed, int _frogScareZone, bool _frogScared)
        {
            frogSpeed = _frogSpeed;
            frogScareZone = _frogScareZone;
            frogScared = _frogScared;
        }
    }
    public void FrogMoving()
    {
        transform.Translate(jumping * frog.frogSpeed * Time.deltaTime);
    }
    
    public void FrogStretchMove()
    {
        if(stretched == true)
        {
            if(transform.localScale.y > 8)
            {
                return;
            }
            Vector3 scaler = transform.localScale;
            scaler.y += frogScale;
            transform.localScale = scaler;
        }
        else
        {
            if(transform.localScale.y < 0.8)
            {
                return;
            }
            print("GroundHit");
            Vector3 scaler = transform.localScale;
            scaler.y -= frogScale;
            transform.localScale = scaler;  
        }
    }
    
}
