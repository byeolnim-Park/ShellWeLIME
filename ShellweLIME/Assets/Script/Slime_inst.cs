using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slime_inst : MonoBehaviour
{
    int max = 100;

    public int starve;
    public int clever;
    public int stress;
    public int age;
    public string name;
    public int condition_sel;
    public int hurt_sel=99;
    int decre = 1;
    

    public Texture[] emotion;
    public Texture[] color;
    string[] emotion_ex = { "행복", "행복", "행복", "아픔", "아픔", "행복", "아픔" };
    string[] hurt = { "슬라임저농도증", "슬라임감기", "슬라임형태이상증" };
    float time = 0.0f;
    GameObject Face;
    GameObject Color;
    Vector3 randPos;
    bool isMove=false;
    public bool isBook = false;
    public bool isTrain = false;
    public bool isStop = false;
    int adopt_sum = 210;
    int train_percent;

    GameObject shina;
    game_director game_director;
    GameObject slimeConditionUI;

    public AudioClip walkAud;
    public AudioClip eatAud;
    public AudioClip trainSuccess;
    public AudioClip trainFail;
    AudioSource AudioPlay;



    //디렉터 오브젝트
    // Start is called before the first frame update

    void Start()
    {
        starve = Random.Range(20, 80);
        clever = Random.Range(10, 50);
        stress = Random.Range(30, 80);
        age = Random.Range(1, 15);
        name= gameObject.name;
        condition_sel = Random.Range(0,7);
        if(condition_sel==4 || condition_sel==3 || condition_sel == 6)
        {
            hurt_sel = Random.Range(1, 4);
            decre = 2;
        }

        Face = (transform.Find("Slime").gameObject).transform.Find("Face").gameObject;
        Color = (transform.Find("Slime").gameObject).transform.Find("Slime").gameObject;
        Face.GetComponent<SkinnedMeshRenderer>().material.mainTexture = emotion[condition_sel];
        Color.GetComponent<SkinnedMeshRenderer>().material.mainTexture = color[Random.Range(0, 11)];

        GameObject.Find("Game_director").GetComponent<game_director>().change_slimecnt(1);
        shina = GameObject.Find("Shina");

        game_director = GameObject.Find("Game_director").GetComponent<game_director>();
        slimeConditionUI = (GameObject.Find("Canvas")).transform.Find("slimecondition").gameObject;

        AudioPlay = GetComponent<AudioSource>();

        var obj = FindObjectsOfType<Slime_inst>();
        if (obj.Length == game_director.slime_cnt)
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
        if (isBook)
        {
            book_mountain();
            if (time %5<0.5f && stress<max)
            {
                stress++;
                if (stress > max)
                {
                    stress = max;
                }
            }
        }
        else if (isTrain)
        {
            train();
        }
        else if (isStop)
        {
            transform.Find("Slime").gameObject.GetComponent<Animator>().SetBool("isWalk", false);
        }
        else if (null!=GameObject.FindWithTag("lime")) //라임 발생
        {
            eat(GameObject.FindWithTag("lime"));
        }
        else
        {
            IDLE();
        }

        time += Time.deltaTime;
        if (time > 60)
        {
            starve-=decre;
            stress-=decre;
            time = 0;
        }
    }

    void Change_condition(int condition_num)
    {
        condition_sel = condition_num;
        Face.GetComponent<SkinnedMeshRenderer>().material.mainTexture = emotion[condition_sel];
    }

    void IDLE() //자유롭게 움직이는 상태
    {
        if (isMove)
        {
            if (Vector3.Distance(randPos, transform.position) <= 0.3f)
            {
                isMove = false;
                transform.Find("Slime").gameObject.GetComponent<Animator>().SetBool("isWalk",false);
                return;
            }
            transform.Find("Slime").gameObject.GetComponent<Animator>().SetBool("isWalk",true);
            var dir = randPos - transform.position;
            transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.position += dir.normalized * Time.deltaTime * 2f;
        }
        else if (!isMove)
        {
            randPos = new Vector3(Random.Range(24, 34), 0, Random.Range(31, 42));
            isMove = true;
            AudioPlay.clip = walkAud;
            AudioPlay.Play();
        }
    }

    void stop()
    {
        isMove = false;
        transform.Find("Slime").gameObject.GetComponent<Animator>().SetBool("isWalk", false);
    }

    void eat(GameObject lime_obj)
    {
        if (starve < max)
        {
            if (Vector3.Distance(lime_obj.transform.position, transform.position)<0.3f) //먹기
            {
                transform.Find("Slime").gameObject.GetComponent<Animator>().SetBool("isWalk", false);
                Destroy(lime_obj);
                starve += 5;
                AudioPlay.clip = eatAud;
                AudioPlay.Play();
            }
            else //근접하기
            {   
                var dir = lime_obj.transform.position - transform.position;
                transform.Find("Slime").gameObject.GetComponent<Animator>().SetBool("isWalk", true);
                transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
                transform.position += dir.normalized * Time.deltaTime * 5f;
            }
        }
        if (starve > max)
        {
            starve = max;
        }

    }

    void train()
    {
        train_percent = game_director.slime_max*2;
        int tmp = Random.Range(0, 100);
        if (tmp < train_percent) //성공
        {
            clever += 10;
            AudioPlay.clip = trainSuccess;
            AudioPlay.Play();
            slimeConditionUI.SetActive(true);
            slimeConditionUI.GetComponent<Set_slimeCondition>().Set_Condition(name, starve,stress,clever, condition_sel, hurt_sel);
            game_director.up_train_sum();
        }
        else //실패
        {
            AudioPlay.clip = trainFail;
            AudioPlay.Play();
        }
        isTrain = false;
    }

    void book_mountain()
    {

        if (Vector3.Distance(shina.transform.position, transform.position) < 2.0f) //근접 완료
        {
            transform.Find("Slime").gameObject.GetComponent<Animator>().SetBool("isWalk", false);
        }
        else //근접하기
        {
            var dir = shina.transform.position - transform.position;
            transform.Find("Slime").gameObject.GetComponent<Animator>().SetBool("isWalk", true);
            transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.position += dir.normalized * Time.deltaTime * 5f;
        }
    }

    void set_param(int Set_starve, int Set_clever, int Set_stress, int Set_age, int set_condition)
    {

    }

    public bool can_adopt()
    {
        int sum = stress + starve + clever;
        if (sum > 210) { return true; }
        else { return false; }
    }

    public void be_happy()
    {
        condition_sel = Random.Range(0, 3);
        hurt_sel = 99;
        decre = 1;
        Change_condition(condition_sel);
    }
}
