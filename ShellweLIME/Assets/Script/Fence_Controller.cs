using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence_Controller : MonoBehaviour
{
    GameObject shina;
    float speed = 5.0f;
    public float roty;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        shina = GameObject.Find("Shina");
    }

    // Update is called once per frame
    void Update()
    {
        roty = transform.rotation.y;
        if ( Vector3.Distance(shina.transform.position, this.transform.position)< 2.8f && transform.eulerAngles.y<180.0f)
        {
            transform.Rotate(0, speed, 0);
        }
        else
        {
            if (transform.rotation.eulerAngles.y >= 90.0f && Vector3.Distance(shina.transform.position, this.transform.position) > 2.5f)
            {
                transform.Rotate(0, -speed, 0);
            }
        }
    }
}
