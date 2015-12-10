using UnityEngine;
using System.Collections;

public class PaddleFloorCushionScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
    {
        other.rigidbody.velocity = Vector2.zero;
    }
}
