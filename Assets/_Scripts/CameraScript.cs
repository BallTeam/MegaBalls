using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    PersistentScripts perScript;


    void Start ()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
    }

    void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0,0,-10), 0.15f*Time.timeScale);
    }

    public void Shake (float intensity)
    {
        int r;
        if (Random.Range(0, 10) > 5)
            r = -1;
        else
            r = 1;
        transform.position = new Vector3(
            transform.position.x + (
                Random.Range(
                    intensity * 5 * perScript.screenShakeIntensity,
                    intensity * 10 * perScript.screenShakeIntensity)
                * r),
            transform.position.y + (
                Random.Range(
                    intensity * 5 * perScript.screenShakeIntensity,
                    intensity * 10 * perScript.screenShakeIntensity)
                * r),
            -10);
    }
	
}