using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {

    public Sprite[] sprites;
    public Sprite[] defaultsprites;

    public float altSpriteChance = 100; //0 to 100

    SpriteRenderer spriterend;

    void Awake ()
    {
        spriterend = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start ()
    {
        float r = Random.Range(0, 100);
        if (r < altSpriteChance)
            spriterend.sprite = sprites[Random.Range(0, sprites.Length)];
        else
            spriterend.sprite = defaultsprites[Random.Range(0,defaultsprites.Length)];
    }
}
