using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2Enter : MonoBehaviour {

    public Animator anim1;
    public Animator anim2;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;
    public AudioSource audio5;
    public Animator keyAnimator;
    public ParticleSystem hintParticles;
    public static bool enteredCell2 = false;
    public static bool animationOver = false;

    void Start()
    {
        StartCoroutine(HintParticles());
    }

    IEnumerator HintParticles()
    {
        yield return new WaitForSeconds(15.0f);
        if(!enteredCell2) hintParticles.Play();
    }

    void Update()
    {
        if(enteredCell2)
            hintParticles.Stop();
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !enteredCell2)
        {
            enteredCell2 = true;
            StartCoroutine(WaitThenPlayAnimation(1));
            StartCoroutine(WaitThenPlayAnimation(2));
        }
    }

    IEnumerator WaitThenPlayAnimation(int i)
    {
        yield return new WaitForSeconds(1.0f);
        anim1.Play("Cage1Animation1");
        audio2.Play();
        yield return new WaitForSeconds(2.0f);
        audio2.clip = Resources.Load("Sounds/MetalDoorOpenShort", typeof(AudioClip)) as AudioClip;
        if (i == 1)
        {
            keyAnimator.Play("Keys1Animation1");
            yield return new WaitForSeconds(1.1f);
            audio1.Play();
            yield return new WaitForSeconds(3.9f);
            animationOver = true;
            audio5.Play();
        }
        else if(i == 2)
        {
            yield return new WaitForSeconds(9.0f);
            audio2.Play();
            anim1.Play("Cage1Animation2");
            yield return new WaitForSeconds(1.5f);
            audio2.Play();
            yield return new WaitForSeconds(1.5f);
            audio2.Play();
            yield return new WaitForSeconds(1.5f);
            audio2.Play();
            yield return new WaitForSeconds(3.0f);
            audio3.clip = Resources.Load("Sounds/MonsterRoar", typeof(AudioClip)) as AudioClip;
            audio3.Play();
            yield return new WaitForSeconds(6.0f);
            anim2.Play("WoodDoor1Animation1");
            audio4.Play();
        }
    }
}
