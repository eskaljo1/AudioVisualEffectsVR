using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell6 : MonoBehaviour {

    public Animator anim1;
    public Animator anim2;
    public AudioSource audio1;
    public AudioSource audio2;
    private bool triggered = false;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (!triggered && hitInfo.gameObject.tag == "Player")
        {
            audio1.clip = Resources.Load("Sounds/MetalDoorOpenShort", typeof(AudioClip)) as AudioClip;
            triggered = true;
            StartCoroutine(Door());
        }
    }

    IEnumerator Door()
    {
        yield return new WaitForSeconds(2.0f);
        audio2.Play();
        anim2.Play("CageDropAnimation1");
        yield return new WaitForSeconds(8.0f);
        audio1.Play();
        anim1.Play("Cell6DoorAnimation3");
        yield return new WaitForSeconds(2.8f);
        audio1.clip = Resources.Load("Sounds/MetalDoorSlam", typeof(AudioClip)) as AudioClip;
        audio1.Play();
        yield return new WaitForSeconds(4.0f);
        audio1.clip = Resources.Load("Sounds/MetalDoorOpenShort", typeof(AudioClip)) as AudioClip;
        audio1.Play();
        anim1.Play("Cell6DoorAnimation1");
    }
}
