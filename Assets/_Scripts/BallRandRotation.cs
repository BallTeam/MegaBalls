using UnityEngine;
using System.Collections;

public class BallRandRotation : MonoBehaviour {

	void Update ()
    {
        transform.Rotate(0, 0, 300*Time.deltaTime);
    }
}
