using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input_name : MonoBehaviour
{
    public InputField name_in;
    Slime_generator Slime_generator;

    // Start is called before the first frame update
    void Start()
    {
        Slime_generator = GameObject.Find("slime_generator").GetComponent<Slime_generator>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void yes_click()
    {
        gameObject.SetActive(true);
    }

    public void ok_click_input()
    {
        Slime_generator.new_slime(name_in.text);
        gameObject.SetActive(false);
    }
}
