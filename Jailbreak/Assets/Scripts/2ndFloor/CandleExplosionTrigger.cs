using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleExplosionTrigger : MonoBehaviour {

    private bool triggered = false;
    public Animator anim;
    public AudioSource audio1;
    public AudioSource audio2;
    public GameObject candle;
    public GameObject barrels;
    public ParticleSystem smoke;
    public ParticleSystem explosion1;
    public ParticleSystem explosion2;
    public ParticleSystem explosion3;
    public ParticleSystem explosion4;
    public ParticleSystem explosion5;
    public ParticleSystem explosion6;
    public Light smokeLight;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (!triggered && hitInfo.gameObject.tag == "Player")
        {
            triggered = true;
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(1.0f);
        anim.Play("CandleAnimation1");
        yield return new WaitForSeconds(0.5f);
        audio1.Play();
        yield return new WaitForSeconds(1.0f);
        audio1.clip = Resources.Load("Sounds/Ignite", typeof(AudioClip)) as AudioClip;
        audio1.Play();
        smoke.Play();
        StartCoroutine(LightUp());
        yield return new WaitForSeconds(5.0f);
        smoke.Stop();
        explosion1.Play(); explosion2.Play(); explosion3.Play();
        explosion4.Play(); explosion5.Play(); explosion6.Play();
        audio2.Play();
        Destroy(candle); Destroy(barrels);
        smokeLight.intensity = 0;
        yield return new WaitForSeconds(3.0f);
        explosion1.Stop(); explosion2.Stop(); explosion3.Stop();
        explosion4.Stop(); explosion5.Stop(); explosion6.Stop();
    }

    IEnumerator LightUp()
    {
        while (smokeLight.intensity < 4.01f)
        {
            smokeLight.intensity += 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
