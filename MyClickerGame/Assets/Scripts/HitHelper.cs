using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHelper : MonoBehaviour {
    public int damageHero;

    public GameObject hero;
    public GameObject heroAttack;
    public GameObject heroAttack2;
    public GameObject heroAttack3;
    public GameObject heroAttack4;
    public int randomHeroAttack;
    public int DamageHero
    {
        get
        {
            return damageHero;
        }

        set
        {
            damageHero += value;
        }
    }





    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnMouseDown()
    {
        
        Debug.Log(message: "onClickDown");
        
        GetComponent<HealthHelper>().GetHit(DamageHero);
        //GetComponent<Items>().GetItems();
        hero.GetComponent<Animator>().SetTrigger("Hit");

        randomHeroAttack = Random.Range(1, 4);
        switch (randomHeroAttack)
        {
            case 1:
                heroAttack.GetComponent<Animator>().SetTrigger("Hit");
                break;
            case 2:
                heroAttack2.GetComponent<Animator>().SetTrigger("Hit");
                break;
            case 3:
                heroAttack3.GetComponent<Animator>().SetTrigger("Hit");
                break;
            case 4:
                heroAttack4.GetComponent<Animator>().SetTrigger("Hit");
                break;
        }
        

    }
    
    
}
