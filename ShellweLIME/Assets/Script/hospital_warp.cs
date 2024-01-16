using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hospital_warp : MonoBehaviour
{
    GameObject shina;
    GameObject[] slimes;
    // Start is called before the first frame update
    void Start()
    {
        this.shina = GameObject.Find("Shina");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        shina.GetComponent<CharacterController>().dontMove();
        shina.transform.position = new Vector3(-7.6f, 0, 96);
        shina.GetComponent<Rigidbody>().isKinematic = true;
        try
        {
            slimes = GameObject.FindGameObjectsWithTag("slime");

            foreach(GameObject slime in slimes)
            {
                slime.GetComponent<Rigidbody>().isKinematic = true;
                slime.GetComponent<AudioSource>().enabled = false;
            }

        }
        catch { }
        SceneManager.LoadScene("hospitalScene");
    }
}
