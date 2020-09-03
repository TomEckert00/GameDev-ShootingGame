using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameActive;
    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("Respawn").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}