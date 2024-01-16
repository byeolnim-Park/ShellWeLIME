using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_change : MonoBehaviour
{
    GameObject shina;
    GameObject[] slimes;
    game_director game_director;
    // Start is called before the first frame update
    void Start()
    {
        shina = GameObject.Find("Shina");
        shina.GetComponent<Rigidbody>().isKinematic = false;
        try
        {
            slimes = GameObject.FindGameObjectsWithTag("slime");

            foreach (GameObject slime in slimes)
            {
                slime.GetComponent<Rigidbody>().isKinematic = false;
                slime.GetComponent<AudioSource>().enabled = true;
            }

        }
        catch { }

        game_director = GameObject.Find("Game_director").GetComponent<game_director>();
        game_director.texting();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
