using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Player player;
    bool mouseEnabled = false;
    bool joystickEnabled = false;
    Vector3 rightAnalogDir;
    // Use this for initialization
    void Start()
    {
        if (player == null)
            player = GetComponent<Player>();
        if (Input.GetJoystickNames().Length > 0)
            joystickEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (mouseEnabled)
            RotateByMouse();
        if (joystickEnabled && (Input.GetAxis("RightVertical") != 0 || Input.GetAxis("RightHorizontal") != 0))
            RotateByJoystick();
    }

    private void RotateByJoystick()
    {
        player.shooterParent.transform.eulerAngles = new Vector3(0, 0, (-Mathf.Atan2(Input.GetAxis("RightVertical"), Input.GetAxis("RightHorizontal")) * 180 / Mathf.PI) - 90);
    }

    private void HandleInput()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            player.velocity.x = Input.GetAxis("Horizontal");
            player.velocity *= player.moveSpeed;
        }
        else
            player.velocity.x = 0;
    }

    private void RotateByMouse()
    {
        player.shooterParent.transform.eulerAngles = Vector3.forward * Vector3.Angle(transform.position, Input.mousePosition);
    }

    internal void Movement(Vector2 velocity)
    {
        player.transform.Translate(velocity);
    }
}
