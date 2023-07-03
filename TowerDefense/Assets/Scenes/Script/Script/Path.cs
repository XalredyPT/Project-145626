using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path{


    int auxiliares = 0;
    int auxiliares2 = 0;

    List<int [,]> coord = new List<int[,]>();




    public List<int [,]> Patha (int x, int y, int xi, int yi){
    


    for(int i = 0; i < x; i++){
        for(int j = 0; j < y; j++){
            if(i == xi && j == yi){
                int [,] caminho = { { xi,yi } };
                coord.Add(caminho);
                int numrandom = Random.Range(0,3);
                if(auxiliares!= 0){
                    xi = xi+1;
                    auxiliares = 0;
                    auxiliares2 = auxiliares2+1;
                }
                else if(auxiliares2!= 0){
                    xi = xi+1;
                    auxiliares2 = 0;
                }
                else if(i == 0){
                    xi = xi+1;
                }
                else if(i == x-2){
                    xi = xi+1;

                }
                else if(i == x-1){
                   
                }
                else if(numrandom == 0){
                    if(xi+1 < x){
                        xi = xi+1;
                    }
                    
                }
                else if(numrandom == 1){
                    if(yi+1 < y){
                        yi = yi+1;
                        auxiliares = 1;
                    }
                    else{
                        if(xi+1 < x){
                            xi = xi+1;
                            
                        }
                    }
                    
                }
                else{
                    if(yi-1 >= 0){
                        yi = yi-1;
                        i = i-1;
                        auxiliares = 1;
                    }
                    else{
                        if(xi+1 < x){
                            xi = xi+1;
                        }
                    }
                }
            

            }
        }
    }

    return coord;
    }
}
