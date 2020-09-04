using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    public Vector3 lookDir;

    public int health;
    public int points;
    private Vector3 startPos;

    private GameManager gameManager;

    void Start()
    {
        startPos = transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = 100;
        points = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            lookDir = Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            lookDir = Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
            lookDir = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
            lookDir = Vector3.back;
        }
        gameManager.SetHealthUI(health);
        gameManager.SetPointUI(points);
    }

    public Vector3 getLookDir()
    {
        return lookDir;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameManager.SetHealthUI(health);
            gameManager.EndGame();
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
}
