using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell4 : MonoBehaviour {
    public GameObject tPoint1;
    public GameObject tPoint2;
    public GameObject tPoint3;
    public GameObject tPoint4;
    public GameObject tPoint5;
    public GameObject tPoint6;
    public GameObject tPoint7;
    public GameObject tPoint8;
    public ParticleSystem hintParticles;
    public static bool enteredCell4 = false;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !enteredCell4)
        {
            enteredCell4 = true;
        }
    }

    // Update is called once per frame
    void Update () {
        if (enteredCell4)
        {
            hintParticles.Stop();
            tPoint1.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            tPoint2.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            tPoint3.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            tPoint4.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            tPoint5.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            tPoint6.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            tPoint7.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            tPoint8.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
        }
    }
}
