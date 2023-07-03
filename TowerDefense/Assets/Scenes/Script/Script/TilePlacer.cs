using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilePlacer : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase relva;
    public TileBase caminho_direito;
    public TileBase caminho_baixo;
    public TileBase caminho_cima;
    public TileBase caminho_cima_direito;
    public TileBase caminho_baixo_direito;
    public TileBase caminho_direito_2;
    public TileBase relva_pedra;
    public TileBase relva_tronco;
    public TileBase relva_2;
    public TileBase Torre;

    public int aux = 3;
    public int aux2 = 3;
    public bool cima = false;
    public bool baixo = false;
    public bool existe = false;
    public List<int [,]> PlaceTile(int x, int y)
    {

        Path path = new Path();
        GlobalPath.coord = path.Patha (x, y, 0, 4);

        
        for(int a = 0; a<y;a++){
            Vector3Int tilePosition = new Vector3Int(x, a, 20);
            tilemap.SetTile(tilePosition, Torre);
        }
        for(int a = 0; a<x;a++){
            for(int b = 0; b<y;b++){

                for(int i = 0; i <  GlobalPath.coord.Count; i++){
                    int[,] auxt =  GlobalPath.coord[i];
                    if(auxt[0,0] == a && auxt[0,1] == b){
                        existe = true;
                    }
                }
                if(!existe){
                    Vector3Int tilePosition = new Vector3Int(a, b, 20);
                    int rand = Random.Range(0, 4);
                if(rand == 0){
                    tilemap.SetTile(tilePosition, relva);
                }
                else if(rand == 1 && aux ==3){
                    aux--;
                    tilemap.SetTile(tilePosition, relva_pedra);
                }
                else if(rand == 2 && aux2 == 3){
                    aux2--;
                    tilemap.SetTile(tilePosition, relva_tronco);
                }
                else if(rand == 3){
                    tilemap.SetTile(tilePosition, relva_2);
                }
                else{
                    tilemap.SetTile(tilePosition, relva);
                }
                aux--;
                aux2--;
                if(aux2 == -5){
                    aux2 = 3;
                }
                if(aux == -5){
                    aux = 3;
                }
                }
                existe = false;
                
            }

        }

        int [,] anterior = GlobalPath.coord[1];
        for(int i = 0; i <  GlobalPath.coord.Count; i++){
            int[,] auxt =  GlobalPath.coord[i];
            
            if(i+1 <  GlobalPath.coord.Count){
                anterior = GlobalPath.coord[i+1];
            }
            else{
                Vector3Int tilePosition = new Vector3Int(auxt[0,0], auxt[0,1], 0);
                tilemap.SetTile(tilePosition, caminho_direito);
            }
            if(i == 0){
                
                Vector3Int tilePosition = new Vector3Int(auxt[0,0], auxt[0,1], 0);
                tilemap.SetTile(tilePosition, caminho_direito);
            }
            else if (baixo == true){
                Vector3Int tilePosition = new Vector3Int(auxt[0,0], auxt[0,1], 0);
                tilemap.SetTile(tilePosition, caminho_baixo_direito);
                baixo = false;
                
            }
            else if (cima == true ){
                Vector3Int tilePosition = new Vector3Int(auxt[0,0], auxt[0,1], 0);
                tilemap.SetTile(tilePosition, caminho_cima_direito);
                cima = false;
                
            }
            else if (auxt[0,1]== anterior[0,1] + 1){
                Vector3Int tilePosition = new Vector3Int(auxt[0,0], auxt[0,1], 0);
                tilemap.SetTile(tilePosition, caminho_baixo);
                baixo = true;
            }
            else if (auxt[0,1] + 1== anterior[0,1]){
                Vector3Int tilePosition = new Vector3Int(auxt[0,0], auxt[0,1], 0);
                tilemap.SetTile(tilePosition, caminho_cima);
                cima = true;
            }
            else{
                Vector3Int tilePosition = new Vector3Int(auxt[0,0], auxt[0,1], 0);
                tilemap.SetTile(tilePosition, caminho_direito);
            }
            
        }
      
        return  GlobalPath.coord;
        


    }
    

}
