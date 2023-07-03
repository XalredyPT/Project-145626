using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;

    void Start()
    {
        Vector3Int tilePosition = new Vector3Int(0, 0, 0); 
        tile = Resources.Load<TileBase>("Palettes/Relva");
        tilemap.SetTile(tilePosition, tile); 
    }
}