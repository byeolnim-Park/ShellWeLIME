using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hospital_Buy : MonoBehaviour
{
    GameObject healwindow;
    GameObject count_text;
    GameObject talkbar;

    game_director game_director;
    GameObject hurt_slime;
    
    string[] hurt_ex = { "슬라임저농도증", "슬라임감기", "슬라임형태이상증" };
    int[] heal_price = { 1000, 500, 1500 };
    int price = 0;
    string name="";

    bool heal_toggle = false;

    // Start is called before the first frame update
    void Start()
    {
        healwindow = transform.Find("healwindow").gameObject;
        count_text = transform.Find("count").gameObject;
        talkbar = transform.Find("talk").gameObject;

        game_director = (GameObject.Find("Game_director")).GetComponent<game_director>();

        healwindow.SetActive(false);
        count_text.SetActive(false);

        game_director.change_lime(0);
        game_director.change_coin(0);
        game_director.change_gem(0);
        game_director.change_slimecnt(0);

        if (null != game_director.BM_slime)
        {
            hurt_slime = game_director.BM_slime;
            if(hurt_slime.GetComponent<Slime_inst>().hurt_sel > 0 && hurt_slime.GetComponent<Slime_inst>().hurt_sel < 4)
            {
                price = heal_price[hurt_slime.GetComponent<Slime_inst>().hurt_sel - 1];
                heal_toggle = true;
            }
            name = hurt_slime.GetComponent<Slime_inst>().name;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void heal_button_click()
    {
        if (game_director.BM_slime == null)
        {
            talkbar.GetComponent<Text>().text = "슬라임 친구와 함께 와주세요~";
        }
        else if (heal_toggle==true)
        {
            healwindow.SetActive(true);
            count_text.SetActive(true);
            (healwindow.transform.Find("Text")).GetComponent<Text>().text = name + "의 치료비";
            count_text.GetComponent<Text>().text = price.ToString() + " coin";
            talkbar.GetComponent<Text>().text = name + "의 병명은 "+hurt_ex[hurt_slime.GetComponent<Slime_inst>().hurt_sel - 1]+"입니다.";
        }
        else if(hurt_slime.GetComponent<Slime_inst>().hurt_sel < 1 || hurt_slime.GetComponent<Slime_inst>().hurt_sel > 3)
        {
            talkbar.GetComponent<Text>().text = name+"은/(는) 건강해요~";
        }
    }

    public void heal_close()
    {
        healwindow.SetActive(false);
        count_text.SetActive(false);
    }

    public void heal_ok()
    {
        if (price <= game_director.coin)
        {
            game_director.change_coin(-1 * (price));
            game_director.up_heal_sum();
            hurt_slime.GetComponent<Slime_inst>().be_happy();
            heal_close();
            talkbar.GetComponent<Text>().text = name+" 회복이 완료되었습니다~";
            heal_toggle = false;
        }
        else
        {
            talkbar.GetComponent<Text>().text = "돈이 부족하세요.";
        }
    }

    public void shop_exit()
    {
        SceneManager.LoadScene("shelterScene");
    }
}
