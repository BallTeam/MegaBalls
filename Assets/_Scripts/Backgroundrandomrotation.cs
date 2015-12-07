using UnityEngine;
using System.Collections;

public class Backgroundrandomrotation : MonoBehaviour {

    int r;

    void Start ()
    {
        r = Random.Range(0, 4);

        switch (r)
        {
            case 0:
                transform.localScale = new Vector3(2, 2, 1);
                break;
            case 1:
                transform.localScale = new Vector3(-2, 2, 1);
                break;
            case 2:
                transform.localScale = new Vector3(2, -2, 1);
                break;
            case 3:
                transform.localScale = new Vector3(-2, -2, 1);
                break;
            default:
                Debug.Log("tez pls");
                break;
        }
    }
}
