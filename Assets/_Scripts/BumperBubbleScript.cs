using UnityEngine;
using System.Collections;

public class BumperBubbleScript : MonoBehaviour {

    Rigidbody2D rb2D;

    float speed =1;

    public GameObject particles;

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(gameObject, 0.03f);
        }
    }

    void Update ()
    {
        if (transform.position.y > 36)
            Destroy(gameObject);
        speed += .01f*Time.timeScale*Time.deltaTime*50;
        transform.position += Vector3.up * speed*Time.timeScale*Time.deltaTime*50;
    }

    void OnDestroy ()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
    }
}
