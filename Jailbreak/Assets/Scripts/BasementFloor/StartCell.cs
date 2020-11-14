using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCell : MonoBehaviour {

    public Animator anim;
    public AudioSource audio;
    private bool doorOpened = false;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !doorOpened)
        {
            doorOpened = true;
            anim.Play("CellStartDoorAnimation");
            audio.Play();
        }
    }
}
