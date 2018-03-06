using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaBoss : MonoBehaviour {
    public Sprite[] sprites;
    public int numberSprite;
    private bool active = false;
    private int Damage;
    private int HP;
    public GameObject playerInfo;

    public Slider timeBar;
    private Text timeText;
    public GameObject timeBackGround;
    private int timeValueMax = 500;
    private int timeValue = 500;
    public bool Active
    {
        get
        {
            return active;
        }

        set
        {
            active = value;
        }
    }

    public int HP1
    {
        get
        {
            return HP;
        }

        set
        {
            HP = value;
        }
    }

    public Text TimeText
    {
        get
        {
            return timeText;
        }

        set
        {
            timeText.text = value.ToString();
        }
    }

    public int TimeValue
    {
        get
        {
            return timeValue;
        }

        set
        {
            timeValue = value;
        }
    }

    public int TimeValueMax
    {
        get
        {
            return timeValueMax;
        }

        set
        {
            timeValueMax = value;
        }
    }



    // Use this for initialization
    void Start ()
    {
        numberSprite = sprites.Length;
        //timeBackGround.active = false;

        HP = Random.Range(1000, 10000);
        TimeValue = TimeValueMax;
        Damage = GetComponent<HitHelper>().DamageHero;
    }


    // Update is called once per frame
    void Update () {
        setTimeBar();
        HP = Random.Range(1000, 10000);
    }

    void setTimeBar()
    {
        timeBar.maxValue = TimeValueMax;
        timeBar.value = TimeValue;
    }
   

    


}
