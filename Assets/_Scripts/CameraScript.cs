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
        transform.position = new Vector3(transform.position.x + Random.Range(-intensity*10 * perScript.screenShakeIntensity, intensity*10*perScript.screenShakeIntensity), transform.position.x + Random.Range(intensity * perScript.screenShakeIntensity, intensity*perScript.screenShakeIntensity), -10);
    }
	
}
