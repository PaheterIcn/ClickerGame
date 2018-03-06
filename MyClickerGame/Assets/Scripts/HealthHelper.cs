using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHelper : MonoBehaviour {
    static public int MaxHP = 100;
    static public int MinHP = 100;
    static int HP = MaxHP;
    public Text myText;
    public GameObject spawnPosition;
    //public Sprite[] sprite;
    private int Damage;
    public Sprite [] mobs;
    static int mobsChet = 0;
    static int mobsChet1 = 0;
    bool activeSprite = true;
    float a = 500;
    bool b = false;
    bool failMegaBoss = false;
    public Slider timeBar;
    public Text timeText;
    public GameObject timeBackGround;
    bool winMegaBoss = false;
    /// <summary>
    public Slider imageHpBar;
    private int HpBarMax;
    private int HpBar;
    public GameObject playerInfo;

    bool MegaBossActive = false;
    public int TimeValue = 0;
    private Sprite spriteBoss;
    public int HPMegaBoss;
    /// </summary>
    public GameObject effect;
    public GameObject buttonBoss;
    public GameObject buttonTextBoss;
    //public bool activeEffect;
    public int z = 0;


    // Use this for initialization
    void Start () {
        HpBarMax = MaxHP;

        imageHpBar.maxValue = MaxHP;
        timeText.text = "";
        timeBackGround.SetActive(false);
        mobsChet1 = mobs.Length;
        Damage = GetComponent<HitHelper>().DamageHero;
        TimeValue = GetComponent<MegaBoss>().TimeValueMax;
        effect.SetActive(false);
        buttonBoss.SetActive(false);
        buttonTextBoss.SetActive(false);
    }

// Update is called once per frame
void Update ()
    {
        textHP();
        hpBar();

        GetComponent<MegaBoss>().TimeValue = TimeValue;
        MegaBosssTime();
        if(MaxHP == MinHP)
        {
            
        }
        Debug.Log(winMegaBoss);
        
        if (effect.active == true)
        {
            z++;
            if (z == 30)
            {
                buttonBoss.SetActive(true);
                buttonTextBoss.SetActive(true);
                z = 0;

            }
        }
        switch (playerInfo.GetComponent<PlayerInfo>().Lvl)
        {
            case 5:
                MinHP = 200;
                break;

            case 10:
                MinHP = 300;
                break;

            case 15:
                MinHP = 500;
                break;
            case 20:
                MinHP = 800;
                break;
            case 25:
                MinHP = 1500;
                break;
        }



    }

    

    public void GetHit(int damage)
    {
        int health = HP - damage;
        if (health <= 0)
        {

            if (failMegaBoss == false)
            {
                playerInfo.GetComponent<PlayerInfo>().setMoney(Random.Range(1, 13), 0, 0);
                GetComponent<Items>().GetItems();
                

            }
            else
            {
                effect.SetActive(false);
                buttonBoss.SetActive(false);
                buttonTextBoss.SetActive(false);
                playerInfo.GetComponent<PlayerInfo>().setMoney(Random.Range(-1, -3), Random.Range(-1, -3), 0);
            }
            if (MegaBossActive == true && TimeValue > 0)
            {
                effect.SetActive(false);
                buttonBoss.SetActive(false);
                buttonTextBoss.SetActive(false);
                playerInfo.GetComponent<PlayerInfo>().setMoney(0, Random.Range(3, 7), 0);

            }
            HP = health;
            textHP();
            hpBar();
            //Destroy(gameObject);
            activeSprite = false;
            gameObject.SetActive(activeSprite);
            smenaBossov();
            
            playerInfo.GetComponent<PlayerInfo>().setScore(50);
            
            
            
        }
        else
        {
            HP = health;
            //Debug.Log(message: "HP = " + HP);
            
        }
        GetComponent<Animator>().SetTrigger("Hit");

    }

    void textHP()
    {
        myText.text = HP.ToString();
    }

    void smenaBossov()
    {

        if (activeSprite == false)
        {
            mobsChet = Random.Range(0,mobsChet1);
            GetComponent<SpriteRenderer>().sprite = mobs[mobsChet];
            if (mobs[mobsChet] == null)
            {
                
                mobsChet = 0;
                
                gameObject.SetActive(true);
     
                
                HP = MaxHP;
                //MegaBosss();
                effect.SetActive(true);
                smenaBossov();





            }
            else
            {
                
                GetComponent<Transform>().position = spawnPosition.GetComponent<Transform>().position;
                MaxHP = MinHP;
                HP = MaxHP;
                activeSprite = true;
                gameObject.SetActive(activeSprite);
                TimeValue = GetComponent<MegaBoss>().TimeValueMax;
                MegaBossActive = false;
            }

        }
    }

    void hpBar()
    {


        if (HP < 0)
        {
            imageHpBar.value = HP;
        }
        else
        {
            imageHpBar.maxValue = MaxHP;
            imageHpBar.value = HP;
        }
    }
    

    public void MegaBosss()
    {
        effect.SetActive(false);
        buttonBoss.SetActive(false);
        buttonTextBoss.SetActive(false);

        MegaBossActive = true;
        GetComponent<Transform>().position = spawnPosition.GetComponent<Transform>().position;
        TimeValue = GetComponent<MegaBoss>().TimeValueMax;
        MaxHP = GetComponent<MegaBoss>().HP1;
        HP = MaxHP;

        int a = GetComponent<MegaBoss>().numberSprite;
        int b = Random.Range(0,a);
        spriteBoss = GetComponent<MegaBoss>().sprites[b];
        GetComponent<SpriteRenderer>().sprite = spriteBoss;



    }
    void MegaBosssTime()
    {
        if (MegaBossActive == true)
        {

            HPMegaBoss = HP;
            
            
                TimeValue--;

                if (TimeValue <= 0 )
                {
                    failMegaBoss = true;
                    effect.SetActive(false);
                    buttonBoss.SetActive(false);
                    buttonTextBoss.SetActive(false);
                    GetHit(MaxHP);

                    
                    TimeValue = 0;
                    smenaBossov();
                    TimeValue = GetComponent<MegaBoss>().TimeValueMax;
                    MegaBossActive = false;
                    failMegaBoss = false;

                }
                else if (HPMegaBoss < 0)
                {

                    
                    winMegaBoss = true;
                    
                    GetHit(Damage);
                    TimeValue = 0;
                    TimeValue = GetComponent<MegaBoss>().TimeValueMax;
                    smenaBossov();
                    
                    MegaBossActive = false;
                    winMegaBoss = false;
                }
            
            
        }
        else
        {
            HPMegaBoss = 0;
        }
    }
}
