using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    const int WALKABLE_LAYER = 8;

    [SerializeField]
    private GameObject helpersRoot;

    private int xMax = 0;
    private int yMax = 0;
    private int xMin = 0;
    private int yMin = 0;

    private int[,] grid;

    // Use this for initialization
    void Start () {
        foreach (var t in helpersRoot.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.layer == WALKABLE_LAYER)
            {
                if (xMax < t.position.x)
                    xMax = (int)t.position.x;
                if (xMin > t.position.x)
                    xMin = (int)t.position.x;
                if (yMax < t.position.y)
                    yMax = (int)t.position.y;
                if (yMin > t.position.y)
                    yMin = (int)t.position.y;
            }
        }

        xMax++;
        xMin--;
        yMax++;
        yMin--;

        grid = new int[xMax-xMin+1,yMax-yMin+1];

        foreach (var t in helpersRoot.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.layer == WALKABLE_LAYER)
            {
                grid[(int)t.position.x - xMin, (int)t.position.y-yMin] = 1;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsFree(int x, int y)
    {
        return grid[x-xMin,y-yMin] != 0;
    }
}
