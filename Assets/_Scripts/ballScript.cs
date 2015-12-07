using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour {

    public float ballInitialVelocity = 1000;
    public float strikeForce = 5;
    public bool isBallInPlay;
    public Rigidbody2D rb2D;
    public bool isEggBall;
    public bool hasRainbowTrail;
    public TrailRenderer rainbowTrail;

    public SpriteRenderer spriteRend;
    bool isStruck;
    PersistentScripts perScript;
    CircleCollider2D circleCollider;
    PolygonCollider2D polyCollider;

    CameraScript camScript;

    public bool hasSplit;

    bool hasDrunkBallBeenCalled;

    Vector2 randomForce;                    //Used for the drunkball

    IEnumerator BecomeGhostBall ()
    {
        yield return new WaitForSeconds(.03f);

        if (perScript.ghostBalls && isEggBall)
        {
            polyCollider.isTrigger = true;
            spriteRend.color = new Vector4(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, .5f);
        }
        else if (perScript.ghostBalls)
        {
            circleCollider.isTrigger = true;
            spriteRend.color = new Vector4(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, .5f);
        }
    }

    IEnumerator BecomeNotGhostBall ()
    {
        yield return new WaitForSeconds(.03f);
        if (isEggBall)
        {
            polyCollider.isTrigger = false;
            spriteRend.color = new Vector4(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, 1);
        }
        else
        {
            circleCollider.isTrigger = false;
            spriteRend.color = new Vector4(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, 1);
        }
    }

    void Start ()
    {
        camScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        if (perScript.rainbowTrail)
        {
            hasRainbowTrail = true;
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        camScript.Shake(.075f);

        if (other.gameObject.tag == "Paddle")
        {
            if (other.gameObject.GetComponentInParent<PaddleScript>().strike)
            {
                rb2D.AddForce(new Vector2(rb2D.velocity.x*strikeForce, rb2D.velocity.y*strikeForce));               //FIX YOUR SHIT TEZ //IM TRYIGN TO //I DID IT
                isStruck = true;
                spriteRend.color = new Vector4(0, 0, 0, spriteRend.color.a);
            }

            StartCoroutine("BecomeGhostBall");
        }
        else if (other.gameObject.tag == "Brick")
        {
            if (isStruck)
            {
                isStruck = false;
                spriteRend.color = new Vector4(1, 1, 1, spriteRend.color.a);
            }

            if (perScript.splitBalls && !hasSplit)
            {
                hasSplit = true;
                GameObject newBall;
                newBall = Instantiate(gameObject) as GameObject;
                newBall.GetComponent<ballScript>().hasSplit = true;
                newBall.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().velocity * 51);
            }
        }

    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == ("Wall") || other.tag == ("Paddle"))
        {
            StartCoroutine("BecomeNotGhostBall");
        }
    }


    void Awake ()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        if (isEggBall)
        {
            polyCollider = gameObject.GetComponent<PolygonCollider2D>();
        }
        else
        {
            circleCollider = gameObject.GetComponent<CircleCollider2D>();
        }
    }

    void Update ()
    {
        if (hasRainbowTrail && isBallInPlay)
        {
            rainbowTrail.enabled = true;
        }
        else
        {
            rainbowTrail.enabled = false;
        }

        if (!hasDrunkBallBeenCalled && perScript.drunkBalls)
        {
            StartCoroutine("DrunkBall");
        }


        /*if (isStruck)
        {
            spriteRend.color = new Vector4(0,0,0,1);
        }
        else
        {
            spriteRend.color = new Vector4(1, 0, 0, 1);
        }*/
        if (!isBallInPlay && Input.GetButtonDown("Fire1"))
        {
            transform.parent = null;
            isBallInPlay =  true;
            rb2D.isKinematic = false;
            //if (GM.instance.isPlayModeVertical)
            //{
                rb2D.AddForce(new Vector3(0, ballInitialVelocity, 0));
            //}
            //else
            //{
            //    rb2D.AddForce(new Vector3(ballInitialVelocity, 0, 0));
            //}

            if (perScript.ghostBalls)
            {
                if (isEggBall)
                {
                    polyCollider.isTrigger = true;
                }
                else
                {
                    circleCollider.isTrigger = true;
                }
                spriteRend.color = new Vector4(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, .5f);
            }

        }
    }

    void FixedUpdate ()
    {
        rb2D.AddForce(randomForce);
    }

    IEnumerator DrunkBall()
    {
        hasDrunkBallBeenCalled = true;
        randomForce = new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
        yield return new WaitForSeconds(Random.Range(.5f, 1f));
        StartCoroutine("DrunkBall");
    }

}