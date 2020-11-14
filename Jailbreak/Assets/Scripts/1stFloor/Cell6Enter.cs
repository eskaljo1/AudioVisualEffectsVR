using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell6Enter : MonoBehaviour {

    public Animator anim1;
    public AudioSource audio;
    public static bool enteredCell6 = false;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !enteredCell6)
        {
            enteredCell6 = true;
            anim1.Play("Cell6DoorAnimation2");
            audio.clip = Resources.Load("Sounds/MetalDoorSlam", typeof(AudioClip)) as AudioClip;
            audio.Play();
        }
    }
}
