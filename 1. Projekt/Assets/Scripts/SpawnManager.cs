using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] powerUps;
    private float cooldown = 1.0f;
    private float xMin = -14;
    private float xMax = 14;
    private float zMin = -9;
    private float zMax = 9;
    private bool gameIsActive;

    public void StartGame()
    {
        gameIsActive = true;
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnEnemies()
    {
        while (gameIsActive)
        {
            Instantiate(enemy, CreateRandomSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }

    private Vector3 CreateRandomSpawnPos()
    {
        return new Vector3(Random.Range(xMin, xMax), 0.5f, Random.Range(zMin, zMax));
    }

    IEnumerator SpawnPowerUps()
    {
        while (gameIsActive)
        {
            int randomIndex = CreateRandomIndex(powerUps);
            Instantiate(powerUps[randomIndex], CreateRandomSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }

    private int CreateRandomIndex(GameObject[] array)
    {
        return Random.Range(0, array.Length);
    }

    public void SetGameInactiv()
    {
        gameIsActive = false;
    }
}
