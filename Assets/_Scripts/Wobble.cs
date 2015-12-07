using UnityEngine;
using System.Collections;

public class Wobble : MonoBehaviour {

    public float wobbling;
    public float wobblingSpeed;

    public float rotatingScale;

    Vector3 iniScale;

    bool bScale;

    float rRotation;

    void Awake ()
    {
        iniScale = transform.localScale;
    }

    void Start ()
    {
        rRotation = Random.Range(0, 500);
        float r = Random.Range(-wobbling, wobbling);
        transform.localScale = new Vector3(transform.localScale.x+r, transform.localScale.y + r, 0);
        //transform.Rotate(new Vector3(0, 0, Random.Range(-5, 5)));
    }

    void Update ()
    {
        if (bScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(iniScale.x + wobbling, iniScale.y + wobbling), wobblingSpeed*Time.timeScale);
            if (transform.localScale.y > iniScale.y + Random.Range(wobbling-(wobbling*.1f), wobbling))
            {
                bScale = false;
            }
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(iniScale.x - wobbling, iniScale.y - wobbling), wobblingSpeed*Time.timeScale);
            if (transform.localScale.y < iniScale.y - Random.Range(wobbling - (wobbling*.1f), wobbling))
            {
                bScale = true;
            }
        }

        transform.Rotate(new Vector3(0, 0, 1) * Mathf.Cos(Time.time + rRotation) * rotatingScale * Time.timeScale);

            
        
    }


}
