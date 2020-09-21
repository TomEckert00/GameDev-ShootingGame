using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerUp;
    private float cooldown = 1.0f;
    private float xMin = -14;
    private float xMax = 14;
    private float zMin = -9;
    private float zMax = 9;
    private bool gameIsActive;

    public void StartGame()
    {
        gameIsActive = true;
        StartCoroutine(spawnEnemies());
        StartCoroutine(spawnPowerUps());
    }

    IEnumerator spawnEnemies()
    {
        while (gameIsActive)
        {
            Instantiate(enemy, createRandomSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }

    private Vector3 createRandomSpawnPos()
    {
        return new Vector3(Random.Range(xMin, xMax), 0.5f, Random.Range(zMin, zMax));
    }

    IEnumerator spawnPowerUps()
    {
        while (gameIsActive)
        {
            Instantiate(powerUp, createRandomSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }

    public void SetGameInactiv()
    {
        gameIsActive = false;
    }
}
