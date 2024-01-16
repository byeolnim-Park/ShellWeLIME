using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title_script : MonoBehaviour
{

    GameObject witch;
    GameObject box;
    GameObject Slime;
    GameObject wingleft;
    GameObject wingright;
    GameObject particle;
    GameObject lightpart;

    GameObject UI;

    float time=0;
    int boo = 0;


    // Start is called before the first frame update
    void Start()
    {
        witch = GameObject.Find("witch");
        box = GameObject.Find("slimebox");

        Slime = (box.transform.Find("slime")).gameObject;
        wingleft = box.transform.Find("wingleft").gameObject;
        wingright = box.transform.Find("wingright").gameObject;
        particle = box.transform.Find("particle1").gameObject;
        lightpart = box.transform.Find("light").gameObject;

        UI = GameObject.Find("Canvas");

        Slime.SetActive(false);
        particle.SetActive(false);
        lightpart.SetActive(false);
        box.SetActive(false);
        UI.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.03)
        {
            if (witch.transform.position.x < 40)
            {
                witch.transform.position += new Vector3(0.7f, 0, 0);
            }    

            if(witch.transform.position.x>0 && box.transform.position.z>-7.6)
            {
                box.SetActive(true);
                box.transform.position += new Vector3(0, -0.452f, -0.51f);
                box.transform.Rotate(new Vector3(-2, 0, 0));
            }

            if (box.transform.position.z < -7.6 && boo<15)
            {
                lightpart.SetActive(true);
                lightpart.GetComponent<Light>().range += 1;
                if (box.transform.position.x > -0.1f)
                {
                    box.transform.position += new Vector3(-0.09f, 0,0);
                    boo++;
                }
                else if (box.transform.position.x < 0.1f)
                {
                    box.transform.position += new Vector3(0.09f, 0, 0);
                    boo++;
                }
                if (boo == 15)
                {
                    box.transform.position = new Vector3(0, box.transform.position.y, box.transform.position.z);
                }
            }

            if (boo == 15 && wingleft.transform.eulerAngles.z<190)
            {
                Debug.Log(wingleft.transform.eulerAngles.z);
                wingleft.transform.Rotate(new Vector3(0, 0, 10));
                wingright.transform.Rotate(new Vector3(0, 0, -10));

                if(wingleft.transform.eulerAngles.z > 10)
                {
                    Slime.SetActive(true);
                    particle.SetActive(true);
                }
            }
            if(wingleft.transform.eulerAngles.z >= 190)
            {
                UI.SetActive(true);
            }

            time = 0;
        }

    }

    public void start()
    {
        SceneManager.LoadScene("movieScene");
    }

    public void exit()
    {
        Application.Quit();
    }
}
