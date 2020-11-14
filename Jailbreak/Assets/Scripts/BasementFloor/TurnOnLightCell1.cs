using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLightCell1 : MonoBehaviour
{
    private AudioSource[] audio;
    public Light light;
    public GameObject gold;
    private bool turnedOn = false;
    public GameObject tPoint;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !turnedOn)
        {
            tPoint.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
            audio = gold.GetComponentsInChildren<AudioSource>();
            turnedOn = true;
            foreach (AudioSource a in audio)
                a.Play();
            StartCoroutine(SlowLightIntensity());
        }
    }

    IEnumerator SlowLightIntensity()
    {
        while (light.intensity < 7)
        {
            light.intensity += 1.0f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
