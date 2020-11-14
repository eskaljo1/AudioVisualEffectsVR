using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffTorch : MonoBehaviour {
    
    private ParticleSystem[] flame;
    private Light[] pLight;
    private bool done = false;

	// Use this for initialization
	void Start () {
        pLight = gameObject.GetComponentsInChildren<Light>();
        flame = gameObject.GetComponentsInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!done && Cell2Enter.animationOver)
        {
            foreach (Light l in pLight)
            {
                StartCoroutine(SlowLightIntensity(l));
            }
            foreach (ParticleSystem childPS in flame)
            {
                childPS.Stop();
            }
            done = true;
        }
	}
    
    IEnumerator SlowLightIntensity(Light l)
    {
        while (l.intensity > 0)
        {
            l.intensity -= 1.0f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
