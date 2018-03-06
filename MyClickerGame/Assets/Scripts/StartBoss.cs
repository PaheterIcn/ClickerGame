using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour {
    public GameObject effect;
    public bool active;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        qwe();
    }
    public void qwe()
    {
        effect.GetComponent<HealthHelper>().MegaBosss();
    }
}
