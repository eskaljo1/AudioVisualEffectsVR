using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell1Exit : MonoBehaviour {

    public Animator anim;
    public AudioSource audio;
    public GameObject tPoint;
    public static bool didAnimation = false;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !didAnimation && Cell1Enter.enteredCell1)
        {
            tPoint.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            didAnimation = true;
            anim.Play("Cell1DoorAnimation1");
            audio.Play();
        }
    }
}
