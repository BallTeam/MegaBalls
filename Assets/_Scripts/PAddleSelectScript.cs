using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PAddleSelectScript : MonoBehaviour {

    PersistentScripts perScript;

    void Start ()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
    }

    void LoadShop()
    {
        SceneManager.LoadScene("Shop");
        //Application.LoadLevel("Shop");
    }

    public void CirclePaddle ()
    {
        perScript.circlePaddle = true;
        perScript.flatPaddle = false;
        perScript.multiPaddle = false;
        perScript.trianglePaddle = false;
        LoadShop();
    }

    public void TrianglePaddle()
    {
        perScript.circlePaddle = false;
        perScript.flatPaddle = false;
        perScript.multiPaddle = false;
        perScript.trianglePaddle = true;
        LoadShop();
    }

    public void FlatPaddle()
    {
        perScript.circlePaddle = false;
        perScript.flatPaddle = true;
        perScript.multiPaddle = false;
        perScript.trianglePaddle = false;
        LoadShop();
    }

    public void MultiPaddle()
    {
        perScript.circlePaddle = false;
        perScript.flatPaddle = false;
        perScript.multiPaddle = true;
        perScript.trianglePaddle = false;
        LoadShop();
    }
}
