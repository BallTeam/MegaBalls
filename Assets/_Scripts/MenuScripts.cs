using UnityEngine;
using System.Collections;

public class MenuScripts : MonoBehaviour {

	public void GoToLevel_01()
    {
        Application.LoadLevel("level_01");
    }

    public void GoToShop ()
    {
        Application.LoadLevel("Shop");
    }

    public void GoToPaddleSelect()
    {
        Application.LoadLevel("PaddleSelect");
    }
}
