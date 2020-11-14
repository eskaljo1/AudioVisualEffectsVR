using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllTPoints : MonoBehaviour {
    public GameObject tPoint1;
    public GameObject tPoint2;
    public GameObject tPoint3;
    public GameObject tPoint4;
    public GameObject tPoint5;
    public GameObject tPoint6;
    public GameObject tPoint7;

    public ParticleSystem hintParticlesCell3;
    public ParticleSystem hintParticlesCell5;
    public ParticleSystem hintParticlesCell6;
    public ParticleSystem hintParticlesCell7;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            if (Cell3Enter.enteredCell3)
            {
                tPoint1.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
                tPoint2.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            }
            if (Cell5Enter.enteredCell5)
            {
                tPoint3.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
                tPoint4.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            }
            if (Cell6Enter.enteredCell6)
            {
                tPoint5.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
                tPoint6.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            }
            if (Cell7Enter.enteredCell7)
            {
                tPoint7.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            }
            StartCoroutine(HintParticles());
        }
    }

    IEnumerator HintParticles()
    {

        if (!Cell3Enter.enteredCell3) hintParticlesCell3.Play();
        if (!Cell5Enter.enteredCell5) hintParticlesCell5.Play();
        if (!Cell6Enter.enteredCell6) hintParticlesCell6.Play();
        if (!Cell7Enter.enteredCell7) hintParticlesCell7.Play();
        yield return new WaitForSeconds(3.0f);
        hintParticlesCell3.Stop();
        hintParticlesCell5.Stop();
        hintParticlesCell6.Stop();
        hintParticlesCell7.Stop();
    }
}
