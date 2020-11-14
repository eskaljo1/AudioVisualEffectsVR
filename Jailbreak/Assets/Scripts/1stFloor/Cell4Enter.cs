using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell4Enter : MonoBehaviour {
    
    public Animator crate;
    public AudioSource audio;
    public static bool enteredCell4 = false;
    
    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !enteredCell4)
        {
            enteredCell4 = true;
            audio.Play();
            crate.Play("PackageAnimation1");
        }
    }
}
