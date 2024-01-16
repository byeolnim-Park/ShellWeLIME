using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    GameObject shina;

    // Start is called before the first frame update
    void Start()
    {
        this.shina = GameObject.Find("Shina");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position =  shina.transform.position + new Vector3(0, 3.5f, 5);
    }
}
