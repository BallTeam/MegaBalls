using UnityEngine;
using System.Collections;

public class WallContinuumScript : MonoBehaviour {

    PersistentScripts perScript;
    BoxCollider2D collider;

    public GameObject duplicateWall;
    public Vector3 tpPos;

    void Awake ()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void Start ()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        if (perScript.continuumBalls)
        {
            Destroy(duplicateWall);
            collider.isTrigger = true;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (perScript.continuumBalls && other.tag == "Ball")
        {
            other.transform.position = new Vector3(tpPos.x, other.transform.position.y, other.transform.position.z);
            Debug.Log("continuum tp pos is : " + new Vector3(tpPos.x, other.transform.position.y, other.transform.position.z));
        }
    }

    
}
