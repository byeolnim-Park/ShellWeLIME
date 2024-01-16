using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_director : MonoBehaviour
{
    public int coin;
    GameObject coin_Text;
    public int lime;
    GameObject lime_Text;
    public int gem;
    GameObject gem_Text;
    public int slime_cnt;
    public int slime_max;
    public GameObject slimecnt_Text;

    GameObject shina;
    public GameObject BM_slime;

    //�������� ����
    int slime_sum = 0;
    int heal_sum = 0;
    int lime_sum = 0;
    int train_sum = 0;
    bool BM_tog = true;
    int adopt_sum = 0;
    GameObject achive_UI;
    GameObject achive_Text;

    float time = 0;
    float slime_limit = 50;
    float adopt_limit = 120;
    bool first_tog = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Default_UI = (GameObject.Find("Canvas_2")).transform.Find("default_UI").gameObject;
        GameObject achive_UI = (GameObject.Find("Canvas_2")).transform.Find("achive").gameObject;
        GameObject achive_Text = achive_UI.transform.Find("Text").gameObject;
        achive_UI.SetActive(false);

        coin = 500;
        coin_Text = (Default_UI.transform.Find("coinImage").gameObject).transform.Find("coin").gameObject;
        coin_Text.GetComponent<Text>().text = coin.ToString();

        lime = 5;
        lime_Text = (Default_UI.transform.Find("limeImage").gameObject).transform.Find("limeText").gameObject;
        lime_Text.GetComponent<Text>().text = lime.ToString();

        gem = 1;
        gem_Text = (Default_UI.transform.Find("gemImage").gameObject).transform.Find("gemText").gameObject;
        gem_Text.GetComponent<Text>().text = gem.ToString();
        slime_cnt = 0;
        slime_max = 5;
        slimecnt_Text.GetComponent<Text>().text = slime_cnt.ToString()+" /  "+slime_max.ToString();

        shina = GameObject.Find("Shina");

        var obj = FindObjectsOfType<game_director>();
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

    public void change_coin(int num)
    {
        coin += num;
        coin_Text.GetComponent<Text>().text = coin.ToString();
    }

    public void change_lime(int num)
    {
        lime += num;
        lime_Text.GetComponent<Text>().text = lime.ToString();
    }

    public void change_gem(int num)
    {
        gem += num;
        gem_Text.GetComponent<Text>().text = gem.ToString();
    }

    public void change_slimecnt(int num)
    {
        slime_cnt += num;
        slimecnt_Text.GetComponent<Text>().text = slime_cnt.ToString() + " /  " + slime_max.ToString();
    }

    public void change_slimemax(int num)
    {
        slime_max += num;
        slimecnt_Text.GetComponent<Text>().text = slime_cnt.ToString() + " /  " + slime_max.ToString();
    }

    public void texting()
    {
        coin_Text.GetComponent<Text>().text = coin.ToString();
        lime_Text.GetComponent<Text>().text = lime.ToString();
        gem_Text.GetComponent<Text>().text = gem.ToString();
        slimecnt_Text.GetComponent<Text>().text = slime_cnt.ToString() + " /  " + slime_max.ToString();
    }

    public void up_slime_sum() //������ �� ��������
    {
        GameObject achive_UI = (GameObject.Find("Canvas_2")).transform.Find("achive").gameObject;
        GameObject achive_Text = achive_UI.transform.Find("Text").gameObject;

        slime_sum++;
        if (slime_sum % 5 == 0)//10�������� �ִ� �� ����
        {
            change_slimemax(1);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = slime_sum.ToString()+"������ �޼�!\n +������ �ִ� �� ����";
            Invoke("hide_ui", 3);
        }

        if (slime_sum == 1)
        {
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "ù ������!\n +1000 Coin +10 Lime +5 Gem";
            Invoke("hide_ui",3);
            change_coin(1000);
            change_gem(5);
            change_lime(10);
        }
        else if (slime_sum == 5)
        {
            change_coin(1000);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "���� �ټ��̳�!\n +1000 Coin";
            Invoke("hide_ui", 3);
        }


    }

    public void up_heal_sum()
    {
        GameObject achive_UI = (GameObject.Find("Canvas_2")).transform.Find("achive").gameObject;
        GameObject achive_Text = achive_UI.transform.Find("Text").gameObject;

        heal_sum++;
        if (heal_sum == 1)
        {
            change_coin(1000);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "code blue!\n +1000 Coin";
            Invoke("hide_ui", 3);
        }
        else if (heal_sum == 5)
        {
            change_coin(5000);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "cooooode blue!\n +5000 Coin";
            Invoke("hide_ui", 3);
        }
    }
    
    public void up_lime_sum()
    {
        GameObject achive_UI = (GameObject.Find("Canvas_2")).transform.Find("achive").gameObject;
        GameObject achive_Text = achive_UI.transform.Find("Text").gameObject;

        lime_sum++;
        if (lime_sum == 1)
        {
            change_lime(10);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "���Ը�!\n +10 Lime";
            Invoke("hide_ui", 3);
        }
        else if (lime_sum == 100)
        {
            change_lime(20);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "���Ը�!\n +20 Lime";
            Invoke("hide_ui", 3);
        }

    }

    public void up_train_sum()
    {
        GameObject achive_UI = (GameObject.Find("Canvas_2")).transform.Find("achive").gameObject;
        GameObject achive_Text = achive_UI.transform.Find("Text").gameObject;

        train_sum++;
        if (train_sum == 1)
        {
            change_gem(5);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "ù �Ʒü���!\n +5 Gem";
            Invoke("hide_ui", 3);
        }
        if (train_sum == 10)
        {
            change_gem(10);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "10��10��!\n +10 Gem";
            Invoke("hide_ui", 3);
        }
    }

    public void first_BM()
    {
        GameObject achive_UI = (GameObject.Find("Canvas_2")).transform.Find("achive").gameObject;
        GameObject achive_Text = achive_UI.transform.Find("Text").gameObject;

        if (BM_tog == true)
        {
            change_coin(500);
            BM_tog = false;
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "�ݱ��� �ܾ� ��å!\n +500 Coin";
            Invoke("hide_ui", 3);
        }
    }

    public void up_adopt_sum()
    {
        GameObject achive_UI = (GameObject.Find("Canvas_2")).transform.Find("achive").gameObject;
        GameObject achive_Text = achive_UI.transform.Find("Text").gameObject;

        adopt_sum++;
        if (adopt_sum == 1)
        {
            change_gem(5);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "�߰�, �ǰ���!\n +5 Gem";
            Invoke("hide_ui", 3);
        }
        else if (adopt_sum == 5)
        {
            change_gem(10);
            achive_UI.SetActive(true);
            achive_Text.GetComponent<Text>().text = "�߰�, �ູ��!\n +10 Gem";
            Invoke("hide_ui", 3);
        }
    }

    void hide_ui()
    {
        GameObject achive_UI = (GameObject.Find("Canvas_2")).transform.Find("achive").gameObject;
        achive_UI.SetActive(false);
    }
}
