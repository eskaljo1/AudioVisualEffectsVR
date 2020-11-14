using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell3Enter : MonoBehaviour {

    public Animator anim1;
    public AudioSource audio;
    public static bool enteredCell3 = false;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !enteredCell3)
        {
            enteredCell3 = true;
            anim1.Play("Cell3DoorAnimation1");
            audio.clip = Resources.Load("Sounds/MetalDoorSlam", typeof(AudioClip)) as AudioClip;
            audio.Play();
        }
    }
}
