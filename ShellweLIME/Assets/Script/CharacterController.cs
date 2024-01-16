using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float speed = 30.0f;
    Vector3 startPos = new Vector3(30, 0, 95);
    Rigidbody RB;

    bool isMove; 
    Vector3 destination;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        var obj = FindObjectsOfType<CharacterController>();
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
    public void SetDestination(Vector3 dest) {
        if (dest.y > 0)
        {
            dest.y = 0;
        }
        
        destination = dest; 
        isMove = true; 

    }

    public void Move() { 
        if (isMove) { 
            if (Vector3.Distance(destination, transform.position) <= 0.3f) {
                isMove = false;
                animator.SetBool("isWalk", false);
                return; 
            }
            animator.SetBool("isWalk", true);
            var dir = destination - transform.position;
            transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.position += dir.normalized * Time.deltaTime * 5f; 
        } 
    }

    public void dontMove()
    {
        isMove = false;
        animator.SetBool("isWalk", false);
    }

}


