using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BONUS : MonoBehaviour
{

    public Spawn_Tower_1 Tower1;
    public Grid grid;
    // Start is called before the first frame update
    private int[] aux = new int[9];
    void Start()
    {
        grid = new Grid(16,9,10);

        for (int i = 0; i < 9; i++)
        {
            aux[i] = i*10;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("ntowers"); i++)
        {
            Vector3 pos = new Vector3(150 ,aux[i] + 5, 0);

            Tower1.SpawnTower1(grid.GetXY(pos));
        }

    }
    void update()
    {

    }

    // Update is called once per frame

}
