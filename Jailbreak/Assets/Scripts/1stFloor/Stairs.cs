using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{
    private GameObject player;
    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.FindWithTag("Canvas");
        canvas.SetActive(false);
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
            //Destroy(player);
            SceneManager.LoadScene("Scene3");
            player = GameObject.FindWithTag("MainCamera");
            player.transform.position = new Vector3(24.56746f, 3.474f, 90.76242f);
            player.transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }
}
