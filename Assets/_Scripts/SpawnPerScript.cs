using UnityEngine;
using System.Collections;

public class SpawnPerScript : MonoBehaviour {

    public PersistentScripts perScript;

    GameObject[] perScriptArray;

    void Awake ()
    {
        perScriptArray = GameObject.FindGameObjectsWithTag("PersistentScript");
        if (perScriptArray.Length == 0)
        {
            Instantiate(perScript, transform.position, Quaternion.identity);
        }
        else if (perScriptArray.Length > 1)
        {
            Debug.Log("TEZ THERES WAY TOO MANY PERISSTENT OBJECTS WTF DID YOU DO MAN OMG");
        }
    }
}
