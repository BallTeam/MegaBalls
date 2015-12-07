using UnityEngine;
using System.Collections;

public class CameraFollowPaddle : MonoBehaviour {

    public float speed; //goes from 0 to 1

    Transform paddleTf;

    void Start ()
    {
        paddleTf = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Transform>();
    }

    void Update ()
    {
        transform.position = new Vector3(transform.position.x,  Mathf.Lerp(transform.position.y, paddleTf.position.y, speed), transform.position.z);
    }
}
