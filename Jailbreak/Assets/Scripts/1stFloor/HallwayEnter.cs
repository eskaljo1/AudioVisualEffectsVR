using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayEnter : MonoBehaviour {

    private bool hallwayEntered = false;
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !hallwayEntered)
        {
            hallwayEntered = true;
            anim1.Play("Cell3DoorAnimation2");
            audio1.Play();
            anim2.Play("Cell5DoorAnimation1");
            audio2.Play();
            anim3.Play("Cell6DoorAnimation1");
            audio3.Play();
            anim4.Play("Cell7DoorAnimation1");
            audio4.Play();
        }
    }
}
