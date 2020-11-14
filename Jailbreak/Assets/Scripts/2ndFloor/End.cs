using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {
    public ParticleSystem hintParticles;
    private GameObject canvas;

    void Start()
    {
        StartCoroutine(HintParticles());
        canvas = GameObject.FindWithTag("Canvas");
        canvas.SetActive(false);
    }

    IEnumerator HintParticles()
    {
        yield return new WaitForSeconds(15.0f);
        hintParticles.Play();
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            Application.Quit();
        }
    }
}
