using UnityEngine;
using System.Collections;

public class Level2Brick : MonoBehaviour {


    public GameObject brickParticle;
    public int hp = 2;
    public SpriteRenderer spriteRend;
    public Sprite fullHealth;
    public Sprite lowHealth;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            hp--;
            Ouch();
        }
    }

    void Ouch ()
    {
        switch (hp)
        {
            case 0:
                Instantiate(brickParticle, transform.position, Quaternion.identity);
                GM.instance.DestroyBrick();
                Destroy(gameObject, .03f);
                break;
            case 1:
                spriteRend.sprite = lowHealth;
                break;
            case 2:
                spriteRend.sprite = fullHealth;
                break;
            default:
                Debug.Log("Fuck u tez");
                break;
        }


    }
}
