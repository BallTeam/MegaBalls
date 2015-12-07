using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventoryScript : MonoBehaviour {

    public int[] inventory = new int[1];                 //Inventory index
                                                         //0 = empty
                                                         //1 = spawn second ball powerup

    //public int[] potentialPowerups;                      //refer to index above

    public Image powerUp_Slot01;
    public Image powerUp_Slot02;
    public Image powerUp_Slot03;

    public Image slot_Slot01;
    public Image slot_Slot02;
    public Image slot_Slot03;

    public Sprite emptySlot;
    public Sprite powerUp_01;

    PersistentScripts perScript;
    bool powerUpHasBeenAssigned;

    void Start()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        inventory = perScript.playerInventory;
        powerUp_Slot01.sprite = emptySlot;
        powerUp_Slot02.sprite = emptySlot;
        powerUp_Slot03.sprite = emptySlot;
        slot_Slot01.enabled = false;
        slot_Slot02.enabled = false;
        slot_Slot03.enabled = false;

        switch (inventory.Length)
        {
            case 0:
                //do nothing
                break;
            case 1:
                slot_Slot01.enabled = true;
                break;
            case 2:
                slot_Slot01.enabled = true;
                slot_Slot02.enabled = true;
                break;
            case 3:
                slot_Slot01.enabled = true;
                slot_Slot02.enabled = true;
                slot_Slot03.enabled = true;
                break;
            default:
                Debug.Log("TEZ FUCK U MANG");
                break;
        }
    }

    void Update ()
    {
        perScript.playerInventory = inventory;
        for (int i = 0; i < inventory.Length;i++)
        {
            switch (inventory[i])
            {
                case 0:
                    switch (i)
                    {
                        case 0:
                            powerUp_Slot01.sprite = emptySlot;
                            break;
                        case 1:
                            powerUp_Slot02.sprite = emptySlot;
                            break;
                        case 2:
                            powerUp_Slot03.sprite = emptySlot;
                            break;
                        default:
                            Debug.Log("WHAT TEH HECJ TEZ GO EAT A DICK");
                            break;
                    }
                    break;
                case 1:
                    switch (i)
                    {
                        case 0:
                            powerUp_Slot01.sprite = powerUp_01;
                            break;
                        case 1:
                            powerUp_Slot02.sprite = powerUp_01;
                            break;
                        case 2:
                            powerUp_Slot03.sprite = powerUp_01;
                            break;
                        default:
                            Debug.Log("WHAT TEH HECJ TEZ GO EAT A DICK");
                            break;
                    }
                    break;
                default:
                    Debug.Log("OH MY GOD TEZ, SERIOUSLY ?");
                    break;
            }
        }
    }

    public void AddPowerUp ()
    {
        powerUpHasBeenAssigned = false;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == 0 && !powerUpHasBeenAssigned)
            {
                powerUpHasBeenAssigned = true;
                inventory[i] = Random.Range(1,2);
            }
        }
    }

}
