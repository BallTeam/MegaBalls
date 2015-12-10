using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

    GameObject[] balls;
    //public bool isVerticalMode;
    //public bool isVerticalModeCornerWall;
    //public bool isHorizontalModecornerWall;

    ballScript ball_script;

    //void Update ()
    //{
    //    if (isVerticalModeCornerWall && !GM.instance.isPlayModeVertical)
    //    {
    //        Destroy(gameObject);
    //    }
    //    if (isHorizontalModecornerWall && GM.instance.isPlayModeVertical)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

	void OnCollisionEnter2D (Collision2D other)
    {
        //if (isVerticalMode && GM.instance.isPlayModeVertical)
        //{
            if (other.gameObject.tag == "Ball")
            {
                ball_script = other.gameObject.GetComponent<ballScript>();
                if (ball_script.hasRainbowTrail)
                {
                    ball_script.hasRainbowTrail = false;
                }
                else
                {
                    Destroy(other.gameObject);
                    balls = GameObject.FindGameObjectsWithTag("Ball");
                    Debug.Log("Busted a ball " + balls.Length);
                    if (balls.Length == 1)
                    {
                        GM.instance.LoseLife();
                        Debug.Log("Ball busting led to life loss");
                    }
                }
        //    }
        //}
        //else if (!isVerticalMode && !GM.instance.isPlayModeVertical)
        //{
        //    if (other.gameObject.tag == "Ball")
        //    {
        //        ball_script = other.gameObject.GetComponent<ballScript>();
        //        if (ball_script.hasRainbowTrail)
        //        {
        //            ball_script.hasRainbowTrail = false;
        //        }
        //        else
        //        {
        //            Destroy(other.gameObject);
        //            balls = GameObject.FindGameObjectsWithTag("Ball");
        //            Debug.Log("Busted a ball" + balls.Length);
        //            if (balls.Length == 1)
        //            {
        //                GM.instance.LoseLife();
        //                Debug.Log("Ball busting led to life loss");
        //            }
        //        }
        //    }
        }
    }
}
