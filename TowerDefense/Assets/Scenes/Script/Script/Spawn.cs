using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{

    float time = 2f;
    float aux = 0f;
    public GameObject boss;

    public bool auxb = true;
    public float xt = 0;

    // Start is called before the first frame update
    void Start()
    {

        MakeClone(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (GlobalPath.nenemys < getenemies())
        {
            if(GlobalPath.HasKilledfst==true){
                aux += Time.deltaTime;
            
                if(aux>=time){
                    if(GlobalPath.enemycount % 20 == 0 && GlobalPath.enemycount != 0    ){

                    }
                    else if (auxb == true){
                        if(GlobalPath.speed_enemy == 0){

                        }
                        else{
                            MakeClone();
                            aux = 0f;
                        }

                    }


                }
            }
            
        }
        
         
        
        if(GlobalPath.enemycount % 20 == 0 && GlobalPath.enemycount != 0    ){
            if(auxb){
                xt +=1;
                GlobalPath.enemylife += 20 * (float)Math.Pow(2,xt);
                auxb = false;       
                MakeBoss();
                aux = 0f;

            }

        }
        else{
            auxb = true;
        }
        
    }
    public int getenemies(){
        if(GlobalPath.totalenemies>0){
            return GlobalPath.totalenemies;
        }
        else{
            return 5;
        }
    }
    public void MakeClone(){

        GameObject original = gameObject;
        GameObject clone = Instantiate(original);
        GlobalPath.nenemys++;
        clone.name = "Enemy" + " " + GlobalPath.nenemys;

        Destroy(clone.GetComponent<Spawn>());
        clone.AddComponent<EnemyMov>();
        GlobalPath.enemies.Add(clone);

        

    }

    public void MakeBoss(){


        GameObject clone = Instantiate(boss);
        GlobalPath.nenemys++;
        clone.name = "Boss" ;


        clone.AddComponent<BossMov>();
        GlobalPath.enemies.Add(clone);

        

    }
}
