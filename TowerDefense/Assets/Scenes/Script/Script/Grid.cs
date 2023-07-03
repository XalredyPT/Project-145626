using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid{

    private int width;
    private int height;

    private float cellSize;
    int [,] gridArray;

    public Sprite img;
    public GameObject image;



    public Grid (int width, int height, float cellSize){
    this.width = width;
    this.height = height;
    this.cellSize = cellSize;
    gridArray = new int[width, height];
    Path path = new Path();


    Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
    Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
}


    private Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x, y) * cellSize;
    }

    
    public int printPositionarray(int x, int y){
        return gridArray[x, y];
    }

    public Vector3Int GetXY(Vector3 worldPosition){
        return new Vector3Int(Mathf.FloorToInt(worldPosition.x / cellSize), Mathf.FloorToInt(worldPosition.y / cellSize),-1);
    }
    

}
