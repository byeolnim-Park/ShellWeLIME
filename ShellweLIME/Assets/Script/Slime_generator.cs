using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_generator : MonoBehaviour
{
    public GameObject prefab;
    GameObject UI;
    Renderer Graphic;
    BoxCollider BoxCol;
    float time = 0.0f;
    float limit = 60.0f;
    bool first_tog = true;

    game_director game_director;

    // Start is called before the first frame update
    void Start()
    {
        game_director = GameObject.Find("Game_director").GetComponent<game_director>();
        UI = (GameObject.Find("Canvas")).transform.Find("new_slime").gameObject;
        Graphic = GetComponent<Renderer>();
        BoxCol = GetComponent<BoxCollider>();
        Graphic.enabled = false;
        BoxCol.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (first_tog)
        {
            Graphic.enabled = true;
            BoxCol.enabled = true;
            first_tog = false;
        }
        else if (time > limit)
        {
            Graphic.enabled = true;
            BoxCol.enabled = true;
            time = 0;
        }
    }

    public void new_slime(string name)
    {
        GameObject new_slime = Instantiate(prefab);
        new_slime.transform.position = new Vector3(Random.Range(24, 34), 0, Random.Range(31, 42));
        new_slime.name = name;
        new_slime.SetActive(true);
        //game_director.up_slime_sum();
    }

    public void isClick()
    {
        UI.SetActive(true);
    }
}
