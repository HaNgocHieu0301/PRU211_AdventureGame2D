using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public Transform playerPos;
    //[ShowInInspector]
    //public Dictionary<GameObject, Transform> enemies;
    // Start is called before the first frame update
    public void Init()
    {
        GameObject xxx = Instantiate(player, this.transform.parent);
        xxx.transform.position = playerPos.position;
        Debug.LogError("xxx" + xxx.transform.position);
        // foreach (var enemy in enemies.Keys)
        // {
        //     enemy.transform.position = enemies[enemy].position;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
