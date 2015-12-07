using UnityEngine;
using System.Collections;

public class PowerUpControllerScript : MonoBehaviour {

    PlayerInventoryScript inventory;

    void Start ()
    {
        inventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventoryScript>();
    }

    void Update ()
    {
        if (Input.GetButtonDown("PowerUp01"))
        {
            UsePowerUp(inventory.inventory[0]);
            inventory.inventory[0] = 0;
        }
        if (Input.GetButtonDown("PowerUp02"))
        {
            UsePowerUp(inventory.inventory[1]);
            inventory.inventory[1] = 0;
        }
        if (Input.GetButtonDown("PowerUp03"))
        {
            UsePowerUp(inventory.inventory[2]);
            inventory.inventory[2] = 0;
        }
        if (Input.GetButtonDown("PowerUp04"))
        {
            UsePowerUp(inventory.inventory[3]);
            inventory.inventory[3] = 0;
        }
        if (Input.GetButtonDown("PowerUp05"))
        {
            UsePowerUp(inventory.inventory[4]);
            inventory.inventory[4] = 0;
        }
    }

    void UsePowerUp (int powerUp)
    {
        switch(powerUp)
        {
            case 0:
                //do nothing
                break;
            case 1:
                PowerUp01();
                break;
            default:
                Debug.Log("OMG TEZ WTF FIX YOUR GODDAM CODE SERIOUSLY MAN U SUCK");
                break;
        }
    }

    void PowerUp01 ()
    {
        GameObject originalBall;
        GameObject newBall;
        ballScript newBallBallScript;
        originalBall = GameObject.FindGameObjectWithTag("Ball");
        newBall = (GameObject) Instantiate(originalBall, originalBall.transform.position, Quaternion.identity);
        newBallBallScript = newBall.GetComponent<ballScript>();
        newBallBallScript.isBallInPlay = true;
        newBallBallScript.rb2D.isKinematic = false;
        newBallBallScript.rb2D.AddForce(originalBall.GetComponent<Rigidbody2D>().velocity*75);

    }
}
