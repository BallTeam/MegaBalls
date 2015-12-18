using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionScripts : MonoBehaviour {

    PersistentScripts perScript;
    public Slider vlambeerSlider;
    public Slider paddleSensibility;
    public Slider gibsIntensity;
    public Slider splatterIntensity;

    void Start ()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        vlambeerSlider.value = perScript.screenShakeIntensity;
        paddleSensibility.value = perScript.paddleSensibility;
        gibsIntensity.value = perScript.gibsIntensity;
        splatterIntensity.value = perScript.splatterIntensity;
    }

    public void SplatterIntensity()
    {
        perScript.splatterIntensity = splatterIntensity.value;
    }

    public void GibsIntensity()
    {
        perScript.gibsIntensity = gibsIntensity.value;
    }

    public void PaddleSensibility()
    {
        perScript.paddleSensibility = paddleSensibility.value;
    }

    public void Vlambeer ()
    {
        perScript.screenShakeIntensity = vlambeerSlider.value;
    }




}
