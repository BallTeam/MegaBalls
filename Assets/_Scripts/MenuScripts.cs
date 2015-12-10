using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour {


	public void GoToLevel_01()
    {
        SceneManager.LoadScene("level_01");
        //Application.LoadLevel("level_01");
    }

    public void GoToShop ()
    {
        SceneManager.LoadScene("Shop");
        //Application.LoadLevel("Shop");
    }

    public void GoToPaddleSelect()
    {
        SceneManager.LoadScene("PaddleSelect");
        //Application.LoadLevel("PaddleSelect");
    }
}
