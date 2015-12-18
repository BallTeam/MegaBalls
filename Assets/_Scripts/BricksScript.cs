using UnityEngine;
using System.Collections;

public class BricksScript : MonoBehaviour {

    public GameObject brickParticle;

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            Destroy(gameObject, .03f);
        }
    }

    void OnDestroy ()
    {
        GM.instance.DestroyBrick();

    }
}
