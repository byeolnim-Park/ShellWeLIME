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
    
    string[] hurt_ex = { "������������", "�����Ӱ���", "�����������̻���" };
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
            talkbar.GetComponent<Text>().text = "������ ģ���� �Բ� ���ּ���~";
        }
        else if (heal_toggle==true)
        {
            healwindow.SetActive(true);
            count_text.SetActive(true);
            (healwindow.transform.Find("Text")).GetComponent<Text>().text = name + "�� ġ���";
            count_text.GetComponent<Text>().text = price.ToString() + " coin";
            talkbar.GetComponent<Text>().text = name + "�� ������ "+hurt_ex[hurt_slime.GetComponent<Slime_inst>().hurt_sel - 1]+"�Դϴ�.";
        }
        else if(hurt_slime.GetComponent<Slime_inst>().hurt_sel < 1 || hurt_slime.GetComponent<Slime_inst>().hurt_sel > 3)
        {
            talkbar.GetComponent<Text>().text = name+"��/(��) �ǰ��ؿ�~";
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
            talkbar.GetComponent<Text>().text = name+" ȸ���� �Ϸ�Ǿ����ϴ�~";
            heal_toggle = false;
        }
        else
        {
            talkbar.GetComponent<Text>().text = "���� �����ϼ���.";
        }
    }

    public void shop_exit()
    {
        SceneManager.LoadScene("shelterScene");
    }
}
