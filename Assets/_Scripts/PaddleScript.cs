using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

    public float paddleSpeed = 1*10;

    public GameObject bumperBubble;
    public GameObject ball_Standard;
    public GameObject ball_Egg;
    public Vector3 ballSpawnPos;
    GameObject ball;

    PersistentScripts perScript;
    Vector3 playerPos = new Vector3 (0,-4.5f*10,0);
    Vector3 mousePos;
    int bumperBubbleCd;


    void Start ()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        transform.position = new Vector3 (0,-5.8f*10,0);
        if (perScript.eggBalls)
        {
            ball = Instantiate(ball_Egg, new Vector3(transform.position.x + ballSpawnPos.x * 10, transform.position.y + ballSpawnPos.y * 10, transform.position.z), Quaternion.identity) as GameObject;
            ball.transform.parent = gameObject.transform;
        }
        else
        {
            ball = Instantiate(ball_Standard, new Vector3(transform.position.x + ballSpawnPos.x * 10, transform.position.y + ballSpawnPos.y * 10, transform.position.z), Quaternion.identity) as GameObject;
            ball.transform.parent = gameObject.transform;
        }
    }



    void Update ()
    {

        
            float xPos = transform.position.x + (Input.GetAxis("Horizontal") *2* paddleSpeed) + (Input.mousePosition.x - mousePos.x)*Time.deltaTime * paddleSpeed;
            playerPos = new Vector3(Mathf.Clamp(xPos, -7.75f * 10, 7.75f * 10), transform.position.y , 0);

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



        if (perScript.bumper && Input.GetButtonDown("Fire1") && bumperBubbleCd < 0)
        {
            bumperBubbleCd = 20;
            Instantiate(bumperBubble, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

    void FixedUpdate ()
    {
        bumperBubbleCd--;

        //    if (strikeCd < 0)
        //    {
        //        strike = false;
        //    }
        //    else
        //    {
        //        strikeCd--;
        //    }
        //    if (!strike && Input.GetButtonDown("Fire1"))
        //    {
        //        strike = true;
        //        strikeCd = 60;
        //        rb2D.AddForce(Vector2.up * 60000000);
        //        Debug.Log("Bumped Paddle");
        //    }
        }
    }
