using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCell4Door : MonoBehaviour {
    public Animator anim;
    public GameObject tPoint1;
    public GameObject tPoint2;
    public GameObject tPoint3;
    public GameObject tPoint4;
    public ParticleSystem hintParticles;
    private bool openedDoor = false;
	
	// Update is called once per frame
	void Update () {
		if(!openedDoor && Cell7Enter.enteredCell7 && Cell6Enter.enteredCell6 && Cell5Enter.enteredCell5 && Cell3Enter.enteredCell3)
        {
            tPoint1.transform.position = new Vector3(-0.998f, 1.844f, 34.535f);
            tPoint2.transform.position = new Vector3(6.39f, 1.844f, 38.5f);
            tPoint3.transform.position = new Vector3(4.11f, 1.844f, 46.99f);
            tPoint4.transform.position = new Vector3(1.75f, 1.844f, 29.3f);
            openedDoor = true;
            anim.Play("Cell4DoorAnimation1");
            StartCoroutine(HintParticles());
        }
	}

    IEnumerator HintParticles()
    {
        yield return new WaitForSeconds(10.0f);
        hintParticles.Play();
    }
}
