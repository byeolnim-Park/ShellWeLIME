using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lime_generator : MonoBehaviour
{
    public GameObject prefab;

    AudioSource lime_gen;
    // Start is called before the first frame update
    void Start()
    {
        lime_gen = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void make_lime(Vector3 dest)
    {
        dest.y = 2;
        lime_gen.Play();

        GameObject Lime = Instantiate(prefab);
        Lime.transform.position = dest;
        Lime.SetActive(true);
    }
}
