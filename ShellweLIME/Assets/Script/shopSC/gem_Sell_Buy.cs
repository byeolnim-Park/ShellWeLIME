using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gem_Sell_Buy : MonoBehaviour
{
    GameObject buywindow;
    GameObject sellwindow;
    GameObject count_text;
    GameObject talkbar;

    game_director game_director;

    int count = 0;
    int price = 100;
    // Start is called before the first frame update
    void Start()
    {
        buywindow = transform.Find("buywindow").gameObject;
        sellwindow = transform.Find("sellwindow").gameObject;
        count_text = transform.Find("count").gameObject;
        talkbar = transform.Find("talk").gameObject;

        game_director = (GameObject.Find("Game_director")).GetComponent<game_director>();

        buywindow.SetActive(false);
        sellwindow.SetActive(false);
        count_text.SetActive(false);
        talkbar.GetComponent<Text>().text = "어서오세요. 보석 상점입니다.";

        game_director.change_lime(0);
        game_director.change_coin(0);
        game_director.change_gem(0);
        game_director.change_slimecnt(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buy_button_click()
    {
        buywindow.SetActive(true);
        count_text.SetActive(true);
    }

    public void sell_button_click()
    {
        sellwindow.SetActive(true);
        count_text.SetActive(true);
    }

    public void buy_close()
    {
        count = 0;
        count_text.GetComponent<Text>().text = count.ToString();
        buywindow.SetActive(false);
        count_text.SetActive(false);
    }

    public void sell_close()
    {
        count = 0;
        count_text.GetComponent<Text>().text = count.ToString();
        sellwindow.SetActive(false);
        count_text.SetActive(false);
    }

    public void count_up()
    {
        count++;
        count_text.GetComponent<Text>().text = count.ToString();
    }

    public void count_down()
    {
        if (count > 0)
        {
        count--;
        count_text.GetComponent<Text>().text = count.ToString();
        }
    }

    public void buy_ok()
    {
        if ((count * price) <= game_director.coin)
        {
            game_director.change_gem(count);
            game_director.change_coin(-1 * (count * price));
            count = 0;
            count_text.GetComponent<Text>().text = count.ToString();
        }
        else
        {
            talkbar.GetComponent<Text>().text = "돈이 부족하세요.";
        }

    }

    public void sell_ok()
    {
        if (count < game_director.gem)
        {
        game_director.change_gem(-1 * count);
        game_director.change_coin((count * price));
        count = 0;
        count_text.GetComponent<Text>().text = count.ToString();
        }
        else
        {
            talkbar.GetComponent<Text>().text = "보석이 부족하세요.";
        }

    }

    public void shop_exit()
    {
        SceneManager.LoadScene("shelterScene");
    }
}
