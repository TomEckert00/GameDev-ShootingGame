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
    private bool isMultiShotActive = false;
    
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
        if (Input.GetKeyDown(KeyCode.Space)&&isMultiShotActive)
        {
            CreateBullet(player.transform.position + (-2 * lookDir),-lookDir);
            CreateBullet(player.transform.position + (2 * lookDir),lookDir);
            CreateBullet(player.transform.position + (2 * Vector3.right),Vector3.right); 
            CreateBullet(player.transform.position + (2 * Vector3.left),Vector3.left); 
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet(player.transform.position + (-2 * lookDir), -lookDir);
        }
    }

    private void CreateBullet(Vector3 spawnPos, Vector3 moveDir)
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody>();
        bulletRigidBody.AddForce(moveDir * speed, ForceMode.Impulse);
    }

    public void SetMultiShot(bool b)
    {
        isMultiShotActive = b;
    }
}