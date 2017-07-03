using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceTrigger : Trigger {

    [SerializeField]
    bool outside;

    [SerializeField]
    GameObject toHide;

    [SerializeField]
    GameObject toShow;

    [SerializeField]
    Area area;

    public override void Run()
    {
        if (toHide!=null)
            toHide.SetActive(false);
        if (toShow!= null)
            toShow.SetActive(true);
        
        Camera.main.orthographicSize = outside ? 9.5f : 4.75f;

        GameObject hero = GameObject.FindGameObjectWithTag("Player");
        if (hero != null)
        {
            hero.GetComponent<Hero>().area = area;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
