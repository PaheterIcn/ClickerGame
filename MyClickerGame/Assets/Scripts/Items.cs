using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour {
    public GameObject items;
    public Sprite sprite;

    int random;
    int predmet = 0;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;

    //public Text textMoney;
    //public Text textMoneyDonate;
    //public int money;
    //public int moneyDonate;
    public GameObject playerInfo;
    // Use this for initialization
    void Start() {
        items.GetComponent<SpriteRenderer>().sprite = null;
        item1.GetComponent<SpriteRenderer>().sprite = null;
        item2.GetComponent<SpriteRenderer>().sprite = null;
        item3.GetComponent<SpriteRenderer>().sprite = null;
        //item1 = items;
        //item2 = items;
        //item3 = items;
        
    }

    // Update is called once per frame
    void Update() {
        
       // setTextMoney();
       // setTextMoneyDonate();

    }

    public void GetItems()
    {
        random = 51;
        if (random > 50)
        {
            //SetSpriteAndAnimtator(items);
            switch (predmet)
            {
                case 0:
                    SetSpriteAndAnimtator(items);
                    break;
                case 1:
                    SetSpriteAndAnimtator(item1);
                    break;
                case 2:
                    SetSpriteAndAnimtator(item2);
                    break;
                case 3:
                    SetSpriteAndAnimtator(item3);
                    
                    break;
                case 4:
                    SetSpriteAndAnimtator(item4);
                    break;
                case 5:
                    SetSpriteAndAnimtator(item5);
                    break;
                case 6:
                    SetSpriteAndAnimtator(item6);
                    predmet = 0;
                    break;

            }

        }

    }

    private void SetSpriteAndAnimtator(GameObject @object)
    {
        @object.GetComponent<SpriteRenderer>().sprite = sprite;
        @object.GetComponent<Animator>().SetTrigger("Hit");
        predmet++;
        //money++;
        // Over999999Money();
        //playerInfo.GetComponent<PlayerInfo>().setMoney(Random.Range(1, 10), 0, 0);


    }

}
