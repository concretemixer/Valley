using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    [SerializeField]
    private Area area;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            pos+= Vector3.up;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            pos+= Vector3.down;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            pos+= Vector3.left;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            pos+= Vector3.right;

        if (farm.IsFree((int)pos.x, (int)pos.y))
        {
            transform.position = pos;
            Camera.main.transform.position = pos + Vector3.back*10;
        }

    }
}
