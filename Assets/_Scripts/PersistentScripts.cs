using UnityEngine;
using System.Collections;

public class PersistentScripts : MonoBehaviour {

    //public int[] shopItems;

    public float paddleSize = 10; //1 = 2 Units
    public float ballSize;
    //public float score;
    //public float tezzies;
    public int roomNbr;         //number of the room the playe ris currently in (levels are composed of 3 to 5 rooms)
    public int luck = 0;
    public int currentLevel = 0;
    public float fastForwardIntensity;
    public bool brickSlowDown;
    public bool endRoomSlowDown;
    public int[] playerInventory;
    public int money;

    public float screenShakeIntensity = 1;

    //List of active upgrades
    public bool flatPaddle;
    public bool circlePaddle;
    public bool multiPaddle;
    public bool drunkBalls;
    public bool ghostBalls;
    public bool eggBalls;
    public bool trianglePaddle;
    public bool superhot;
    public bool splitBalls;
    public bool rainbowTrail;

    bool fastForward;
    bool backToNormalSpeed;
    bool brickslowDownHolder = true;
    bool endRoomSlowDownHolder = true;

    public bool isPaddleMoving;
    

    void Start()
    {
        fastForwardIntensity = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>().fastForwardIntensity;
        //StartCoroutine("CompleteSave");
    }

    void Update ()
    {
        if (superhot)
        {
            if (isPaddleMoving)
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, 2.5f, 0.15f);
            }
            else
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, .2f, 0.35f);
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire2"))
            {
                fastForward = true;
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                fastForward = false;
            }


            if (endRoomSlowDown)
            {
                if (endRoomSlowDownHolder)
                {
                    StartCoroutine("EndRoomSlowDown");
                }
            }
            else if (fastForward)
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, fastForwardIntensity, 0.35f);
            }
            else if (brickSlowDown)
            {
                if (brickslowDownHolder)
                {
                    StartCoroutine("BrickSlowDown");
                }
            }
            else
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, 1, 0.35f);
            }
        }

        

        //Cheaty dev commands!

        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.LoadLevel("shop");
        }

        //

    }

    IEnumerator EndRoomSlowDown()
    {
        endRoomSlowDownHolder = false;
        Time.timeScale = 0.25f;
        yield return new WaitForSeconds(1f);
        endRoomSlowDown = false;
        endRoomSlowDownHolder = true;
    }

    IEnumerator BrickSlowDown()
    {
        brickslowDownHolder = false;
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.1f);
        brickSlowDown = false;
        brickslowDownHolder = true;
    }
}