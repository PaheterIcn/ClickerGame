using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public GameObject heroAttack;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack()
    {
        GetComponent<Animator>().SetTrigger("Hit");
        heroAttack.GetComponent<Animator>().SetTrigger("Hit");
    }
}
