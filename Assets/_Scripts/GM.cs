using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    public int lives = 3;
    public int brickNbr = 42;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    //public GameObject brickPrefabVertical;
    //public GameObject brickPrefabHorizontal;
    public GameObject paddleVertical_Circle;
    //public GameObject paddleHorizontal_Circle;
    public GameObject paddleVertical_Flat;
    //public GameObject paddleHorizontal_Flat;
    public GameObject paddleVertical_Standard;
    //public GameObject paddleHorizontal_Standard;
    public GameObject paddleVertical_Multi;
    //public GameObject paddleHorizontal_Multi;
    public GameObject paddleVertical_Triangle;
    //public GameObject paddleHorizontal_Triangle;

    public GameObject deathParticles;
    public static GM instance = null;
    //public bool isPlayModeVertical;
    //public float levelHeight;
    //public bool isPlayModeVertical;
    //public GameObject brick_SquareBricks_Big;
    //public GameObject brick_RectangleLaidBricks_Big;
    //public GameObject brick_RectangleStandBricks_Big;
    //public GameObject brick_CircleBricks_Big;
    //public GameObject specialBrick;
    //public GameObject[] premadeRoomsHorizontal;
    public GameObject[] premadeRoomsVertical;

    CameraScript camScript;
    GameObject[] bricksGameObjects;
    GameObject clonePaddle;
    PersistentScripts perScript;
    //GameObject[] brickPrefabArray;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameOver);
        }

    }

    void Start()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        camScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        Setup();

    }

    public void Setup()
    {

        SetupPaddle();

                    Instantiate(premadeRoomsVertical[Random.Range(0,premadeRoomsVertical.Length)], Vector3.zero, Quaternion.identity);
          

        CountBricks();
    }

    void CheckGameOver()
    {
        Debug.Log("GM counted " + brickNbr  + " bricks at " + Time.time);
        if (brickNbr < 1)
        {
            youWon.SetActive(true);
            perScript.endRoomSlowDown = true;
            perScript.roomNbr++;
            if (perScript.roomNbr == 3)
            {
                if (perScript.currentLevel < 2)
                {
                    perScript.currentLevel++;
                    Application.LoadLevel("Shop");
                }
                else
                {
                    //end game
                }
                
            }
            else
            {
                Invoke("Reset2", resetDelay);
            }
        }
        if (lives < 1)
        {
            gameOver.SetActive(true);
            perScript.endRoomSlowDown = true;
            //Invoke("Reset2", resetDelay);
            //reset perScript and goes back to main menu
            Invoke("LostGame", resetDelay);
        }
    }

    void LostGame ()
    {
        Destroy(GameObject.FindGameObjectWithTag("PersistentScript"));
        Application.LoadLevel("MainMenu");
    }

    void Reset2()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        camScript.Shake(1);
        lives--;
        livesText.text = "" + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }


    void SetupPaddle()
    {
            if (perScript.circlePaddle)
            {
                clonePaddle = Instantiate(paddleVertical_Circle, transform.position, Quaternion.identity) as GameObject;
            }
            else if (perScript.flatPaddle)
            {
                clonePaddle = Instantiate(paddleVertical_Flat, transform.position, Quaternion.identity) as GameObject;
            }
            else if (perScript.multiPaddle)
            {
                clonePaddle = Instantiate(paddleVertical_Multi, transform.position, Quaternion.identity) as GameObject;
            }
            else if (perScript.trianglePaddle)
            {
                clonePaddle = Instantiate(paddleVertical_Triangle, transform.position, Quaternion.identity) as GameObject;
            }
            else
            {
                clonePaddle = Instantiate(paddleVertical_Standard, transform.position, Quaternion.identity) as GameObject;
            }

    }

    public void DestroyBrick()
    {
        camScript.Shake(.75f);
        brickNbr--;
        CheckGameOver();
    }

 

    void CountBricks()
    {
        brickNbr = 0;
        bricksGameObjects = GameObject.FindGameObjectsWithTag("Brick");
        foreach (GameObject brick in bricksGameObjects)
        {
            brickNbr++;
        }
    }

}
