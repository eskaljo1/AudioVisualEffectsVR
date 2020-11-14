using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell5Enter : MonoBehaviour {

    public Animator anim1;
    public AudioSource audio;
    public static bool enteredCell5 = false;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !enteredCell5)
        {
            enteredCell5 = true;
            anim1.Play("Cell5DoorAnimation2");
            audio.clip = Resources.Load("Sounds/MetalDoorSlam", typeof(AudioClip)) as AudioClip;
            audio.Play();
        }
    }
}
