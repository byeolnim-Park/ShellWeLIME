using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Get_Object : MonoBehaviour
{
    public Camera camera;
    GameObject shina;
    GameObject slimeConditionUI;
    Slime_inst Slime_inst;
    Slime_generator Slime_generator;
    lime_generator lime_generator;
    game_director game_director;

    float time=0;

    void Start()
    {
        shina = GameObject.Find("Shina");
        this.slimeConditionUI = (GameObject.Find("Canvas")).transform.Find("slimecondition").gameObject;
        this.slimeConditionUI.SetActive(false);

        lime_generator = GameObject.Find("Lime_generator").GetComponent<lime_generator>();
        game_director = GameObject.Find("Game_director").GetComponent<game_director>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    string ObjectName = hit.collider.gameObject.name;
                    if (hit.collider.gameObject.tag == "slime")
                    {
                        Slime_inst = hit.collider.gameObject.GetComponent<Slime_inst>();
                        Slime_inst.isStop = true;
                        slimeConditionUI.SetActive(true);
                        slimeConditionUI.GetComponent<Set_slimeCondition>().Set_Condition(Slime_inst.name, Slime_inst.starve, Slime_inst.stress, Slime_inst.clever,Slime_inst.condition_sel,Slime_inst.hurt_sel);
                    }
                    else if(ObjectName == "slime_generator")
                    {
                        Slime_generator = hit.collider.gameObject.GetComponent<Slime_generator>();
                        Slime_generator.isClick();
                    }
                    else if(ObjectName == "Mailbox")
                    {
                        hit.collider.gameObject.GetComponent<adopt_mail>().click_mailbox();
                    }

                    shina.GetComponent<CharacterController>().SetDestination(hit.point);
                }    
            }

        }
        else if (Input.GetMouseButtonDown(1)) //라임 놓기
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (game_director.lime > 0)
                {
                    lime_generator.make_lime(hit.point);
                    game_director.up_lime_sum();
                    game_director.change_lime(-1);
                }
            }
        }
        shina.GetComponent<CharacterController>().Move();
    }
}
