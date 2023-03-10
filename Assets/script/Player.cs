using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Transform selfTransform = null;
    public Transform lightTransform = null;
    public float walkSpeed = 1f;
    public float sprintSpeed = 2f;

    private float speed = 0f;
    private Vector2 Movement = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        selfTransform = GetComponent<Transform>();
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // UpdateLight();
        GetComponent<Rigidbody2D>().velocity = Movement * speed;
    }

    void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }

    void UpdateLight()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue()));
        Vector2 direction = new Vector2(mousePos.x - selfTransform.position.x, mousePos.y - selfTransform.position.y);
        direction.Normalize();
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        lightTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnSprintStart()
    {
        speed = sprintSpeed;
    }

    void OnSprintStop()
    {
        speed = walkSpeed;
    }
}
