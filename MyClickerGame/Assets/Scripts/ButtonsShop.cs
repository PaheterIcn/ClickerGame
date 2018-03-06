using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsShop : MonoBehaviour {
    public GameObject info;

    public int gold;
    public int silver;
    public int cristal;

    public int priseSilver;
    public int priseGold;
    public int priseCristal;
    public int colichestvo = 0;
    public Text prodanoText;

    public bool isSup;
    public GameObject SupPrefab;

    public int Colichestvo
    {
        get
        {
            return colichestvo;
        }

        set
        {
            colichestvo -= value;
        }
    }

    // Use this for initialization
    void Start() {
        activeButton(false);
        prodanoText.gameObject.active = false;

    }
	
	// Update is called once per frame
	void Update () {
        activeButton(false);
        Money();
        if (silver >= priseSilver && colichestvo > 0)
        {
            activeButton(true);
            
        }
        else
        {
            activeButton(false);
        }

        if(colichestvo == 0 && GetComponent<Button>().interactable == false)
        {
            prodanoText.gameObject.active = true;
        }

        
            
        
	}
    
    void activeButton(bool b)
    {
        GetComponent<Button>().interactable = b;
        
        
    }

    void Money()
    {
        gold = info.GetComponent<PlayerInfo>().Gold;
        silver = info.GetComponent<PlayerInfo>().Silver;
        cristal = info.GetComponent<PlayerInfo>().Cristal;
    }

    public void setSupport()
    {
        GameObject Supp = Instantiate(SupPrefab) as GameObject;
        Vector3 SuppPos = new Vector3(
            Random.Range(310.0f, 439.0f),
            Random.Range(-109.9f, -151.0f),
            -4.0f);
        Supp.transform.position = SuppPos;
    }
}
