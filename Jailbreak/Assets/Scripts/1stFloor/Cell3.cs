using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell3 : MonoBehaviour {
    private bool triggered = false;
    public GameObject p;
    private ParticleSystem[] flame;
    private Light[] lightsFlame;
    public Animator anim;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;
    public AudioSource audio5;

    // Use this for initialization
    void Start()
    {
        flame = p.GetComponentsInChildren<ParticleSystem>(); ;
        lightsFlame = p.GetComponentsInChildren<Light>();
        foreach (ParticleSystem childPS in flame)
        {
            childPS.Stop();
        }
        foreach (Light childL in lightsFlame)
        {
            childL.intensity = 0;
        }
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !triggered)
        {
            triggered = true;
            audio2.Play();
            audio3.Play();
            audio4.Play();
            audio5.Play();
            foreach (ParticleSystem childPS in flame)
            {
                childPS.Play();
            }
            foreach (Light l in lightsFlame)
            {
                StartCoroutine(TurnOnLights(l));
            }
            StartCoroutine(Sounds());
            StartCoroutine(Door());
        }
    }

    IEnumerator TurnOnLights(Light l)
    {
        while (l.intensity < 2)
        {
            l.intensity += 0.25f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator TurnOffLights(Light l)
    {
        while (l.intensity > 0)
        {
            l.intensity -= 0.25f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Sounds()
    {
        yield return new WaitForSeconds(2.0f);
        audio4.Play(); audio5.Play();
        yield return new WaitForSeconds(2.0f);
        audio3.Play(); audio4.Play(); audio5.Play();
        yield return new WaitForSeconds(2.0f);
        audio4.Play(); audio5.Play();
        yield return new WaitForSeconds(2.0f);
        audio3.Play(); audio4.Play(); audio5.Play();
        yield return new WaitForSeconds(2.0f);
        audio4.Play(); audio5.Play();
    }

    IEnumerator Door()
    {
        yield return new WaitForSeconds(10.0f);
        audio2.Stop();
        foreach (ParticleSystem childPS in flame)
        {
            childPS.Stop();
        }
        foreach (Light l in lightsFlame)
        {
            StartCoroutine(TurnOffLights(l));
        }
        yield return new WaitForSeconds(4.0f);
        audio1.clip = Resources.Load("Sounds/MetalDoorOpenShort", typeof(AudioClip)) as AudioClip;
        audio1.Play();
        anim.Play("Cell3DoorAnimation2");
    }
}
