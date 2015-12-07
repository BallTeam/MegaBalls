using UnityEngine;
using System.Collections;

public class BrickPlaceholderScript : MonoBehaviour {

    public GameObject brickPrefab;

	void Awake ()
    {
        Instantiate(brickPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
