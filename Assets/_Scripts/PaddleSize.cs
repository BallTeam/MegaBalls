using UnityEngine;
using System.Collections;

public class PaddleSize : MonoBehaviour {

    PersistentScripts perScript;
    public float iniSize;

    void Start()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
    }

    void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(iniSize*perScript.paddleSize, iniSize*perScript.paddleSize, iniSize*perScript.paddleSize), 0.47f);
    }
}
