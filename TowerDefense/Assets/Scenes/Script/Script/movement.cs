using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
     Grid grid;
    public TilePlacer tilePlacer;
    public Spawn_Tower_1 Tower1;

    public float speed_char = 40f;



    void Start()
    {
        grid = new Grid(16,9,10);

        transform.position = new Vector3(150, 55, -1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < 84){
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 1, -1), speed_char * Time.deltaTime);
            }

        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > 6)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - 1, -1), speed_char * Time.deltaTime);

            }
        }
        if (Input.GetKey(KeyCode.X))
        {
            
            bool hasTower = false;
           
            foreach(GameObject tower in GlobalPath.towers){
                int[,] aux2 = (new int[,] { { (int)(((tower.transform.position.x)-5)/10), (int)(((tower.transform.position.y)-5)/10) } });
                if(aux2[0,0] == grid.GetXY(transform.position)[0] && aux2[0,1] == grid.GetXY(transform.position)[1]){
                    hasTower = true;
                }
            }




            if(!hasTower){
                if (GlobalPath.money >= 10)
                {
                    GlobalPath.money -= 10;
                    Tower1.SpawnTower1(grid.GetXY(transform.position));

                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (GlobalPath.money >= 300)
            {
                GlobalPath.money -= 300;
                GlobalPath.damage += 10;
            }
        }
        

        
    }
}
