using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportHelper : MonoBehaviour {
    public GameObject AttackPrefab;

    public int damage = 10;
    public float AttackSpeed = 2.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine(Attack());
	}
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(AttackSpeed);

        GameObject bullet = Instantiate(AttackPrefab) as GameObject;
        bullet.transform.position = transform.position;
        bullet.GetComponent<AttackSupHelper>().Damage = damage;
        StartCoroutine(Attack());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
