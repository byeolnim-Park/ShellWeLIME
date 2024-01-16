using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adopt_mail : MonoBehaviour
{
    GameObject mail;
    GameObject effect;
    GameObject[] slimes;

    int[] adoptable = new int[3] { 0, 0, 0 };
    GameObject sel_slime;

    game_director game_director;

    string mail_text;

    int coin = 1000;

    float time = 0.0f;
    float limit = 120.0f;
    // Start is called before the first frame update
    void Start()
    {
        mail = (GameObject.Find("Canvas")).transform.Find("adopt").gameObject;
        effect = transform.Find("Sphere").gameObject;
        game_director = GameObject.Find("Game_director").GetComponent<game_director>();

        effect.SetActive(false);
        mail.SetActive(false);
        GetComponent<MeshCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > limit)
        {
            slimes = GameObject.FindGameObjectsWithTag("slime");

            if (null != slimes)
            {
                int i = 0;
                int num = 0;
                int j;
                foreach (GameObject slime in slimes)
                {
                    if (slime.GetComponent<Slime_inst>().can_adopt())
                    {
                        for(j = i; j<3; j++)
                        {
                            adoptable[j] = num+1;
                        }
                        i++;
                    }
                    num++;
                }
            }

            if (0 != adoptable[0])
            {
                sel_slime = slimes[adoptable[Random.Range(0, adoptable.Length)]-1];
                effect.SetActive(true);
                GetComponent<MeshCollider>().enabled = true;
                time = 0;
            }
        }
    }

    public void click_mailbox()
    {
        mail_text = "존경하는 마법사 샤이나님께\n다음 아이들을 입양하고자 합니다\n" + sel_slime.GetComponent<Slime_inst>().name
            + "\n입양 신청을 허가해주셨으면 하는 바입니다\n" + "입양보증금은 1000coin을 지급하겠습니다";

        mail.SetActive(true);
        mail.transform.Find("Text2").gameObject.GetComponent<Text>().text = mail_text;

        effect.SetActive(false);
        GetComponent<MeshCollider>().enabled = false;
    }

    public void click_ok()
    {
        Destroy(sel_slime);
        game_director.up_adopt_sum();
        game_director.change_coin(coin);
        game_director.change_slimecnt(-1);
        mail.SetActive(false);
    }

    public void click_no()
    {
        mail.SetActive(false);
    }
}
