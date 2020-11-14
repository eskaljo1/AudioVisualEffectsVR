using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell1Enter : MonoBehaviour {

    public Animator anim;
    private AudioSource[] audio;
    public AudioSource audioBucket;
    public static bool enteredCell1 = false;
    public GameObject myCollider;
    public GameObject gold;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !enteredCell1)
        {
            audio = gold.GetComponentsInChildren<AudioSource>();
            enteredCell1 = true;
            anim.Play("GoldBarAnimation1");
            foreach (AudioSource a in audio)
                a.Play();
            StartCoroutine(WaitThenDelete());
        }
    }

    IEnumerator WaitThenDelete()
    {
        yield return new WaitForSeconds(6.00f);
        audioBucket.Play();
        yield return new WaitForSeconds(0.05f);
        Destroy(myCollider);
        Destroy(gold);
    }
}
