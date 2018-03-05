using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 5;
    public float moveSpeed = 4f;
    public float rotateSpeed = 15f;
    public float rotateLimit; //belongs on the Shooter
    public Vector2 velocity;
    public PlayerController playerController;
    public GameObject shooterParent;

    // Use this for initialization
    void Start()
    {
        if (playerController == null)
            playerController = GetComponent<PlayerController>();
        if (shooterParent == null)
            shooterParent = GameObject.Find("ShooterParent");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotateLimit = Mathf.Clamp(rotateLimit, 8, 172);
        playerController.Movement(velocity * Time.deltaTime);
    }
}

public enum PlayerState
{
    CanShoot,
    Dead
}