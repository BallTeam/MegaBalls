using UnityEngine;
using System.Collections;

public class SplatterScript : MonoBehaviour {

    PersistentScripts perScript;
    ParticleSystem pSys;

    public short[] burstMin;
    public short[] burstMax;

    ParticleSystem.Burst[] bursts; 

    void Start()
    {
        perScript = GameObject.FindGameObjectWithTag("PersistentScript").GetComponent<PersistentScripts>();
        pSys = gameObject.GetComponent<ParticleSystem>();
        bursts = new ParticleSystem.Burst[burstMin.Length];
        for (int i = 0; i < burstMin.Length; i++)
        {
            bursts[i].minCount = (short)(burstMin[i] * perScript.gibsIntensity);
            bursts[i].maxCount = (short)(burstMax[i] * perScript.gibsIntensity);
        }
        pSys.emission.SetBursts(bursts);

    }




}
