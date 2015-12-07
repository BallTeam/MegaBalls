using UnityEngine;
using System.Collections;

public class PipeScript : MonoBehaviour {

    public bool movesVertically;

    Vector3 iniPos;
    bool isGoingUp;

    void Awake ()
    {
        iniPos = transform.position;
    }

    void Start ()
    {
        if (movesVertically)
        {
            transform.position = new Vector3(iniPos.x, Random.Range(iniPos.y - .18f, iniPos.y + .18f), 0);
        }
        else
        {
            transform.position = new Vector3(Random.Range(iniPos.x - .18f, iniPos.x + .18f), iniPos.y , 0);
        }
    }

    void Update ()
    {
        if (movesVertically)
        {
            if (isGoingUp)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(iniPos.x, iniPos.y + 0.2f), .1f*Time.timeScale);
                if (transform.position.y > iniPos.y + Random.Range(.16f,.19f))
                {
                    isGoingUp = false;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(iniPos.x, iniPos.y - 0.2f), .1f*Time.timeScale);
                if (transform.position.y < iniPos.y - Random.Range(.16f, .19f))
                {
                    isGoingUp = true;
                }
            }
        }
        else
        {
            if (isGoingUp)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(iniPos.x +.2f, iniPos.y), .1f * Time.timeScale);
                if (transform.position.x > iniPos.x + Random.Range(.16f, .19f))
                {
                    isGoingUp = false;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(iniPos.x -.2f, iniPos.y), .1f * Time.timeScale);
                if (transform.position.x < iniPos.x - Random.Range(.16f, .19f))
                {
                    isGoingUp = true;
                }
            }
        }
        
    }
}
