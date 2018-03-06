using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSupHelper : MonoBehaviour {
    HealthHelper _healthHelper;
    public int Damage { get; set; }
                                       // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_healthHelper == null)
        {
            _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _healthHelper.transform.position,
                Time.deltaTime * 150);

            if (Vector3.Distance(transform.position,
                _healthHelper.transform.position) < 0.1f)
            {// Popal
                _healthHelper.GetHit(Damage);

                Destroy(gameObject);
            }
        }

    }
}
