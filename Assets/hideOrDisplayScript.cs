using UnityEngine;
using System.Collections;

public class hideOrDisplayScript : MonoBehaviour {

    RectTransform rectTr;
    bool isOnScreen;
    public int xPos;
    void Awake()
    {
        rectTr = gameObject.GetComponent<RectTransform>();
    }

    public void hideOrDisplayPanel()
    {
        if (!isOnScreen)
            rectTr.Translate(Vector3.left * xPos);
        else
            rectTr.Translate(Vector3.left * -xPos);
        isOnScreen = !isOnScreen;

    }
}
