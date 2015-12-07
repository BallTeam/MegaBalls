using UnityEngine;
using System.Collections;

public class BrickScrolling : MonoBehaviour {

    public float speed;
    public bool isScrollingVertically;

    void FixedUpdate ()
    {
        if (!isScrollingVertically)
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);

    }
}
