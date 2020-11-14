using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTPoint : MonoBehaviour {

    public GameObject tPoint;
    private bool triggered = false;

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" && !triggered)
        {
            triggered = true;
            tPoint.transform.position = new Vector3(-1111.0f, -1111.0f, -1111.0f);
        }
    }
}
