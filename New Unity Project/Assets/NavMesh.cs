using UnityEngine;
using System.Collections;

public class NavMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class Grid
{
    public int gridX;
    public int gridY;
    public Node[,] grid;

    public void CreateGrid ()
    {
        grid = new Node[gridX, gridY];
    }
}

public class Node
{
    bool walkable;
}
