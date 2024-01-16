using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime_except : MonoBehaviour
{
    Renderer Graphic;
    BoxCollider BoxCol;

    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Graphic = GameObject.Find("slime_generator").GetComponent<Renderer>();
        BoxCol = GameObject.Find("slime_generator").GetComponent<BoxCollider>();
        gameObject.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void click_n_close()
    {
        gameObject.SetActive(false);
        Graphic.enabled = false;
        BoxCol.enabled = false;
    }
}
