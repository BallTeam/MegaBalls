using UnityEngine;
using System.Collections;

public class RandomRotationAndScale : MonoBehaviour {


    public float minScale;
    public float maxScale;
    public bool randomRotation;

    PersistentScripts perScript;

    void Start ()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        float r = Random.Range(minScale*perScript.splatterIntensity, maxScale*perScript.splatterIntensity);
        transform.localScale = new Vector3(r, r,0);
        if (randomRotation)
        {
            transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
        }
    }
}
