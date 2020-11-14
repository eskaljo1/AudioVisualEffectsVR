using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell7Enter : MonoBehaviour {

    public GameObject torch;
    private ParticleSystem[] flame;
    private Light[] pLight;
    public Animator anim1;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public static bool enteredCell7 = false;

    // Use this for initialization
    void Start()
    {
        pLight = torch.GetComponentsInChildren<Light>(); ;
        flame = torch.GetComponentsInChildren<ParticleSystem>(); ;
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !enteredCell7)
        {
            enteredCell7 = true;
            anim1.Play("Cell7DoorAnimation2");
            audio1.clip = Resources.Load("Sounds/MetalDoorSlam", typeof(AudioClip)) as AudioClip;
            audio1.Play();
            foreach (Light l in pLight)
            {
                StartCoroutine(SlowLightIntensity(l));
            }
            foreach (ParticleSystem childPS in flame)
            {
                childPS.Stop();
            }
            StartCoroutine(Wait());
        }
    }

    IEnumerator SlowLightIntensity(Light l)
    {
        yield return new WaitForSeconds(0.5f);
        audio3.Play();
        while (l.intensity > 0)
        {
            l.intensity -= 1.0f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        audio2.Play();
        yield return new WaitForSeconds(4.0f);
        audio2.clip = Resources.Load("Sounds/GhostScream", typeof(AudioClip)) as AudioClip;
        audio2.Play();
        yield return new WaitForSeconds(4.0f);
        audio1.clip = Resources.Load("Sounds/MetalDoorOpenShort", typeof(AudioClip)) as AudioClip;
        audio1.Play();
        anim1.Play("Cell7DoorAnimation1");
        yield return new WaitForSeconds(1.0f);
        audio2.Play();
    }
}
