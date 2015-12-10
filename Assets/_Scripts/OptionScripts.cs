using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionScripts : MonoBehaviour {

    PersistentScripts perScript;
    public Slider vlambeerSlider;

    void Start ()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        vlambeerSlider.value = perScript.screenShakeIntensity;
    }





    public void Vlambeer ()
    {
        perScript.screenShakeIntensity = vlambeerSlider.value;
    }




}
