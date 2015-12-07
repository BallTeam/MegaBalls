using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

    public float paddleSpeed = 1;
    public bool strike;

    public GameObject ball_Standard;
    public GameObject ball_Egg;
    public Vector3 ballSpawnPos;
    GameObject ball;

    PersistentScripts perScript;
    Vector3 playerPos = new Vector3 (0,-4.5f,0);
    Vector3 mousePos;



    void Start ()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        transform.position = new Vector3 (-9,0,0);
        if (perScript.eggBalls)
        {
            ball = Instantiate(ball_Egg, new Vector3(transform.position.x + ballSpawnPos.x, transform.position.y + ballSpawnPos.y, transform.position.z), Quaternion.identity) as GameObject;
            ball.transform.parent = gameObject.transform;
        }
        else
        {
            ball = Instantiate(ball_Standard, new Vector3(transform.position.x + ballSpawnPos.x, transform.position.y + ballSpawnPos.y, transform.position.z), Quaternion.identity) as GameObject;
            ball.transform.parent = gameObject.transform;
        }
    }



    void Update ()
    {

        
            float xPos = transform.position.x + (Input.GetAxis("Horizontal") *2* paddleSpeed) + (Input.mousePosition.x - mousePos.x)*Time.deltaTime;
            playerPos = new Vector3(Mathf.Clamp(xPos, -7.75f, 7.75f), transform.position.y , 0);

            if (Input.GetAxis("Horizontal") != 0 || Input.mousePosition.x - mousePos.x != 0)
            {
                perScript.isPaddleMoving = true;
            }
            else
            {
                perScript.isPaddleMoving = false;
            }
        
        transform.position = playerPos;

        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        //

        if (strike)
        {
            
                float yPos = Mathf.Lerp(transform.position.y, -4.8f, 0.69f);
                transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
                if (yPos == -4.8f)
                {
                    strike = false;
                }
            
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            strike = true;

            
                float yPos = Mathf.Lerp(transform.position.y, -4.8f, 0.69f);
                transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            


        }
        else
        {
            
                float yPos = Mathf.Lerp(transform.position.y, -5.8f, 0.69f);
                transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            

        }
    }

}
