using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        return;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.position += Vector3.up;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            transform.position += Vector3.down;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.position += Vector3.left;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.position += Vector3.right;


    }
}
