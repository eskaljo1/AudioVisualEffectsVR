using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell5 : MonoBehaviour {
    public GameObject book;
    public Animator anim1;
    public Animator anim2;
    public Light light;
    public ParticleSystem particles1;
    public ParticleSystem particles2;
    public ParticleSystem particles3;
    public ParticleSystem particles4;
    public ParticleSystem particles5;
    public ParticleSystem particles6;
    public ParticleSystem lightning;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;
    private bool bookTriggered = false;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !bookTriggered)
        {
            bookTriggered = true;
            audio2.Play();
            audio4.Play();
            anim1.Play("BookAnimation1");
            particles1.Play();
            particles2.Play();
            particles3.Play();
            particles4.Play();
            particles5.Play();
            particles6.Play();
            StartCoroutine(Book());
        }
    }

    IEnumerator Book()
    {
        for (int i = 0; i < 8; i++)
        {
            while (light.intensity > 0.2f)
            {
                light.intensity -= 0.05f;
                yield return new WaitForSeconds(0.1f);
            }
            while (light.intensity < 1.0f)
            {
                light.intensity += 0.05f;
                yield return new WaitForSeconds(0.1f);
            }
        }
        audio2.clip = Resources.Load("Sounds/ThrowBook", typeof(AudioClip)) as AudioClip;
        audio2.Play();
        particles1.Stop();
        particles2.Stop();
        particles3.Stop();
        particles4.Stop();
        particles5.Stop();
        particles6.Stop();
        light.intensity = 0.0f;
        yield return new WaitForSeconds(0.8f);
        audio3.Play();
        lightning.Play();
        audio4.Stop();
        Destroy(book);
        yield return new WaitForSeconds(1.8f);
        lightning.Stop();
        yield return new WaitForSeconds(3.0f);
        audio1.clip = Resources.Load("Sounds/MetalDoorOpenShort", typeof(AudioClip)) as AudioClip;
        audio1.Play();
        anim2.Play("Cell5DoorAnimation1");
    }    
}
