using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_object_shop : MonoBehaviour
{
    public Camera camera;
    GameObject shina;
    // Start is called before the first frame update
    void Start()
    {
        shina = GameObject.Find("Shina");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                shina.GetComponent<CharacterController>().SetDestination(hit.point);
            }
        }
        shina.GetComponent<CharacterController>().Move();
    }
}
