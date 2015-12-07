using UnityEngine;
using System.Collections;

public class PaddleBounceScript : MonoBehaviour {

    public float sensibility;
    public float intensity;

    Rigidbody2D rb2D;
    Vector2 force;
    float paddleSize; // 1 = 2 Units

	void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //paddleSize = PersistentScripts.instance.paddleSize; 
            rb2D = other.gameObject.GetComponent<Rigidbody2D>();
            force = new Vector2(0, (transform.position.y - Mathf.Log(other.transform.position.y, sensibility)) * intensity);
            rb2D.AddForce(force);
            Debug.Log("Collision detected with paddle");
            Debug.Log(force);
        }
    }
}
