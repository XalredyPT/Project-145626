using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class testing : MonoBehaviour
{
    public TilePlacer tilePlacer;




    List<int [,]> coord = new List<int[,]>();
    void Start()
    {
        
        GlobalPath.damage += PlayerPrefs.GetInt("damage");
        GlobalPath.speed += PlayerPrefs.GetInt("speed");


        coord = tilePlacer.PlaceTile(15, 9);
        if(SceneManager.GetActiveScene().name == "SampleScene"){
            GlobalPath.totalenemies = 0;
        }
        else{
            GlobalPath.totalenemies = int.MaxValue;
        }

    }


    void Update()
    {
        
    }
}
