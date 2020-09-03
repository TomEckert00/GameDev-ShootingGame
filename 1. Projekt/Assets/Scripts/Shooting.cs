using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Vector3 lookDir;
    private PlayerController playerController;
    public GameObject bulletPrefab;
    private GameObject player;
    private float speed = 30.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        lookDir = playerController.getLookDir();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, player.transform.position + (-2* lookDir), Quaternion.identity);
            Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody>();
            bulletRigidBody.AddForce(-lookDir * speed, ForceMode.Impulse);
        }
    }
}
