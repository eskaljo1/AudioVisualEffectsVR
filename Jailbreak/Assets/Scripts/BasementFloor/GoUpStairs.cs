using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoUpStairs : MonoBehaviour {
    public GameObject player;
    public GameObject canvas;
    public ParticleSystem hintParticles;
    private bool started = false;

    void Start()
    {
        canvas.SetActive(false);
    }

    void Update()
    {
        if (!started && Cell1Exit.didAnimation)
        {
            started = true;
            StartCoroutine(HintParticles());
        }
    }

    IEnumerator HintParticles()
    {
        yield return new WaitForSeconds(10.0f);
        hintParticles.Play();
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
            //Destroy(player);
            SceneManager.LoadScene("Scene2");
            player.transform.position = new Vector3(-21.04942f, 1.844f, 17.53f);
            //player.transform.position = new Vector3(4.15f, 1.844f, 46.395f);
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
