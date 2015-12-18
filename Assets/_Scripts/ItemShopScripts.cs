using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ItemShopScripts : MonoBehaviour {

    PersistentScripts perScript;

    public ItemShopScripts[] previousItems;

    public Sprite continuumBalls;
    public Sprite bumper;
    public Sprite ultrahot;
    public Sprite inventorySlots;
    public Sprite drunkBalls;
    public Sprite ghostBalls;
    public Sprite eggBalls;
    public Sprite paddleTriangle;
    public Sprite superhot;
    public Sprite splitBalls;
    public Sprite rainbowTrail;

    Image sRend;

    bool sameItem;
    public int item;


    //item index
    //01 = Continuum balls
    //02 = bumper
    //03 = ultrahot
    //04 = more inventory space
    //05 = drunk balls
    //06 = ghost balls
    //07 = egg balls
    //08 = Triangle paddle
    //09 = SUPERHOT
    //10 = split balls (splits when hitting a brick for the first time)
    //11 = rainbow trail (holy mantle)

    void Start ()
    {
        sRend = gameObject.GetComponent<Image>();
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();

        do
        {
            sameItem = false;
            item = Random.Range(1, 12);
            if (previousItems.Length > 0)
            {
                for (int i = 0; i < previousItems.Length; i++)
                {
                    if (previousItems[i].item == item)
                    {
                        sameItem = true;
                    }
                }
            }


                switch (item)
                {
                    case 1:
                        if (perScript.continuumBalls)
                        {
                            sameItem = true;
                        }
                        break;
                    case 2:
                        if (perScript.bumper)
                        {
                            sameItem = true;
                        }
                        break;
                    case 3:
                        if (perScript.ultrahot)
                        {
                            sameItem = true;
                        }
                        break;
                    case 4:
                        if (perScript.playerInventory.Length > 1)
                        {
                            sameItem = true;
                        }
                        break;
                    case 5:
                        if (perScript.drunkBalls)
                        {
                            sameItem = true;
                        }
                        break;
                    case 6:
                        if (perScript.ghostBalls)
                        {
                            sameItem = true;
                        }
                        break;
                    case 7:
                        if (perScript.eggBalls)
                    {
                        sameItem = true;
                    }
                        break;
                case 8:
                    if (perScript.trianglePaddle)
                    {
                        sameItem = true;
                    }
                    break;
                case 9:
                    if (perScript.superhot)
                    {
                        sameItem = true;
                    }
                    break;
                case 10:
                    if (perScript.splitBalls)
                    {
                        sameItem = true;
                    }
                    break;
                case 11:
                    if (perScript.rainbowTrail)
                    {
                        sameItem = true;
                    }
                    break;
                default:
                        Debug.Log("Seriosuly ?...");
                        break;
                }
            
        } while (sameItem);

        //

        switch(item)
        {
            case 1:
                sRend.sprite = continuumBalls;
                break;
            case 2:
                sRend.sprite = bumper;
                break;
            case 3:
                sRend.sprite = ultrahot;
                break;
            case 4:
                sRend.sprite = inventorySlots;
                break;
            case 5:
                sRend.sprite = drunkBalls;
                break;
            case 6:
                sRend.sprite = ghostBalls;
                break;
            case 7:
                sRend.sprite = eggBalls;
                break;
            case 8:
                sRend.sprite = paddleTriangle;
                break;
            case 9:
                sRend.sprite = superhot;
                break;
            case 10:
                sRend.sprite = splitBalls;
                break;
            case 11:
                sRend.sprite = rainbowTrail;
                break;
            default:
                Debug.Log("what the hell tezzy");
                break;
        }
    }


    public void PickupItem ()
    {

        //Uncomment when more levels are made
        /*switch (perScript.currentLevel)
        {
            case 0:
                Application.LoadLevel("Level_01");
                break;
            case 1:
                Application.LoadLevel("Level_02");
                break;
            case 2:
                Application.LoadLevel("Level_03");
                break;
            default:
                Debug.Log("Didnt plan that far ahead");
                break;
        }*/
        //Application.LoadLevel("level_01");
        SceneManager.LoadScene("level_01");


        switch (item)
        {
            case 1:
                perScript.continuumBalls = true;
                break;
            case 2:
                perScript.bumper = true;
                break;
            case 3:
                perScript.ultrahot = true;
                break;
            case 4:
                perScript.playerInventory = new int[] { perScript.playerInventory[0], 0, 0};
                break;
            case 5:
                perScript.drunkBalls = true;
                break;
            case 6:
                perScript.ghostBalls = true;
                break;
            case 7:
                perScript.eggBalls = true;
                break;
            case 8:
                perScript.circlePaddle = false;
                perScript.flatPaddle = false;
                perScript.multiPaddle = false;
                perScript.trianglePaddle = true;
                break;
            case 9:
                perScript.superhot = true;
                break;
            case 10:
                perScript.splitBalls = true;
                break;
            case 11:
                perScript.rainbowTrail = true;
                break;
            default:
                Debug.Log("I hate you so much dude");
                break;
        }
    }

}
