using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var obj = FindObjectsOfType<canvas_controller>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
