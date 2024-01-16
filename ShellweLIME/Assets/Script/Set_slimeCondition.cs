using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_slimeCondition : MonoBehaviour
{
    GameObject starve_SL;
    GameObject stress_SL;
    GameObject clever_SL;
    GameObject SlimeName;
    GameObject condition;
    GameObject hurt;

    GameObject slime;

    game_director game_director;

    string[] emotion_ex = { "행복", "행복", "행복", "아픔", "아픔", "행복", "아픔" };
    string[] hurt_ex = { "슬라임저농도증", "슬라임감기", "슬라임형태이상증" };

    // Start is called before the first frame update
    void Start()
    {
        SlimeName = transform.Find("name").gameObject;
        starve_SL = (transform.Find("starve").gameObject).transform.Find("starveSlider").gameObject;
        stress_SL = (transform.Find("stress").gameObject).transform.Find("stressSlider").gameObject;
        clever_SL = (transform.Find("clever").gameObject).transform.Find("cleverSlider").gameObject;
        condition= transform.Find("condition").gameObject;
        hurt = transform.Find("hurt").gameObject;

        game_director = GameObject.Find("Game_director").GetComponent<game_director>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Set_Condition(string name, int starve_num, int stress_num, int clever_num, int condition_num, int hurt_num)
    {

        SlimeName.GetComponent<Text>().text=name+"의 상태";
        starve_SL.GetComponent<Slider>().value = starve_num;
        stress_SL.GetComponent<Slider>().value = stress_num;
        clever_SL.GetComponent<Slider>().value = clever_num;
        condition.GetComponent<Text>().text = emotion_ex[condition_num] + "상태";

        if (hurt_num < 4 &&hurt_num>0)
        {
            hurt.GetComponent<Text>().text = hurt_ex[hurt_num-1];
        }

        slime = GameObject.Find(name);
    }

    public void close()
    {
        slime.GetComponent<Slime_inst>().isStop = false;
        gameObject.SetActive(false);
    }

    public void toggle_bookmountain()
    {
        bool toggle_book = slime.GetComponent<Slime_inst>().isBook;
        slime.GetComponent<Slime_inst>().isBook=!toggle_book;
        if(slime.GetComponent<Slime_inst>().isBook == true)
        {
            game_director.BM_slime = slime;
            game_director.first_BM();
        }
        if (slime.GetComponent<Slime_inst>().isBook == false)
        {
            slime.transform.position = new Vector3(Random.Range(24, 34), 0, Random.Range(31, 42));
            game_director.BM_slime = null;
        }
    }

    public void toggle_train()
    {
        if (game_director.gem > 0)
        {
            bool toggle_train = slime.GetComponent<Slime_inst>().isTrain;
            slime.GetComponent<Slime_inst>().isTrain = !toggle_train;
            game_director.change_gem(-1);
        }

    }
}
