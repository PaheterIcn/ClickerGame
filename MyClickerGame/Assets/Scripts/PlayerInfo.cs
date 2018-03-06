using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

    public string name;
    public int lvl = 1;
    public static string LvLTEXT;
    public Text levlToText;

    public static int score;
    public static int scoreMax;

    public float mana;
    public static float manaMax;

    public Slider BarLVL;
    public Slider BarMANA;
    /// <money>
    public int silver = 0;
    private int gold = 0;
    private int cristal = 0;

    public Text SilverText;
    public Text GoldText;
    public Text CristalText;

    public int Silver
    {
        get
        {
            return silver;
        }

        set
        {
            if (silver > 0)
            {
                silver -= value;
            }
            else
            {
                silver = 0;
            }
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }

        set
        {
            gold -= value;
        }
    }

    public int Cristal
    {
        get
        {
            return cristal;
        }

        set
        {

            cristal -= value;
        }
    }

    public int Lvl
    {
        get
        {
            return lvl;
        }

        set
        {
            lvl = value;
        }
    }

    /// </money>

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        scoreMax = 100 * lvl;
        manaMax = 10 * lvl;
        Money1(silver);
        Money1(gold);
        Money1(cristal);
        getEXP();
        getMoneyTEXT();

        

    }

    void getMoneyTEXT()
    {
        

        SilverText.text = silver.ToString();
        GoldText.text = gold.ToString();
        CristalText.text = cristal.ToString();
    }
    public void setMoney(int Silvers, int Golds, int Cristals)
    {

        if (silver < 999999)
        {
            silver += Silvers;
        }
        else if(silver < 0)
        {
            silver = 0;
        }
        else
        {
            silver = 999999;
        }


        if (gold < 999999){
            gold += Golds;
        }
        else if (gold < 0)
        {
            gold = 0;
        }
        else
        {
            gold = 999999;
        }


        if (cristal < 999999)
        {
            cristal += Cristals;
        }
        else
        {
            cristal = 999999;
        }

    }
   


    void getEXP()
    {
        LvLTEXT = "LVL \n";
        LvLTEXT += lvl.ToString();
        levlToText.text = LvLTEXT;

        BarLVL.maxValue = scoreMax;
        BarLVL.value = score;
        BarMANA.maxValue = manaMax;
        if(BarMANA.value != manaMax)
        {
            BarMANA.value = (mana += (1f * Time.deltaTime));
        }
    }
    public void setScore(int Score)
    {

        score += Score;
        if(score >= scoreMax)
        {
            lvl++;
            score = 0;
        }
    }
    public int getLvl()
    {
        return lvl;
    }
    public void Money1(int a)
    {
        if (a < 0)
        {
            a = 0;
        }
    }
}
