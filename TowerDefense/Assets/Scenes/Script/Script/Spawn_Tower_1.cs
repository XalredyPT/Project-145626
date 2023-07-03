using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Tower_1 : MonoBehaviour
{
    public GameObject tower;
    public void SpawnTower1(Vector3 coord)
    {
        GameObject clone = Instantiate(tower);
        clone.name = "Tower_1";

        Destroy(clone.GetComponent<Spawn_Tower_1>());
        clone.AddComponent<Tower_1>();

        clone.transform.position = new Vector3(coord.x * 10 + 5, coord.y * 10 + 5, -1);
        GlobalPath.towers.Add(clone);




    }
}
