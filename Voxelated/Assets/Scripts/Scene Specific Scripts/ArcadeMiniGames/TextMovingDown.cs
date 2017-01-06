using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMovingDown : MonoBehaviour {
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
    }
}
