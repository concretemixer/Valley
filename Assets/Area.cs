using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

    const int WALKABLE_LAYER = 8;

    private int xMax = 0;
    private int yMax = 0;
    private int xMin = 0;
    private int yMin = 0;

    private int[,] grid;
    private Trigger[,] triggers;

    // Use this for initialization
    void Start () {
        foreach (var t in GetComponentsInChildren<Transform>())
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
        triggers = new  Trigger[xMax - xMin + 1, yMax - yMin + 1]; 

        foreach (var t in GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.layer == WALKABLE_LAYER)
            {
                grid[(int)t.position.x - xMin, (int)t.position.y-yMin] = 1;
                if (t.gameObject.GetComponent<Trigger>())
                {
                    grid[(int)t.position.x - xMin, (int)t.position.y - yMin] = 2;
                    triggers[(int)t.position.x - xMin, (int)t.position.y - yMin] = t.gameObject.GetComponent<Trigger>();
                }
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

    public bool IsTrigger(int x, int y)
    {
        return grid[x - xMin, y - yMin] == 2;
    }

    public void RunTrigger(int x, int y)
    {
        if (triggers[x - xMin, y - yMin] != null)
            triggers[x - xMin, y - yMin].Run();
    }

}
