using UnityEngine;
using System.Collections;

public class SpecialBrick : MonoBehaviour {

    public int[] potentialPowerUps;                 //Cf PlayerInventoryScript for more detail
    int heldPowerUp;

    PlayerInventoryScript inventoryScript;
    //bool isInventoryFull = true;

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            inventoryScript = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventoryScript>();
            //isInventoryFull = true;
            inventoryScript.AddPowerUp();
            
        }
    }
}
