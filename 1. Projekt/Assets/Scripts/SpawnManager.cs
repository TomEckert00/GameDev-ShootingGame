using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private float cooldown = 1.0f;
    private bool gameIsActive;
    private Vector3 spawnPosition;
    private float xMin = -14;
    private float xMax = 14;
    private float zMin = -9;
    private float zMax = 9;
    

    void Start()
    {
        gameIsActive = true;
        StartCoroutine(spawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnEnemies()
    {
        while (gameIsActive)
        {
            spawnPosition = new Vector3(Random.Range(xMin, xMax), 0.5f, Random.Range(zMin, zMax));
            Instantiate(enemy,spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }

}
