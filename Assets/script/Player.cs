using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    Transform selfTransform = null;
    public Transform lightTransform = null;
    public float walkSpeed = 1f;
    public float sprintSpeed = 2f;
    public bool canMove = true;
    private GameManager gameManager;

    public float speed = 0f;
    public Vector2 Movement = Vector2.zero;

    public bool isOnGamepad = false;
    public Animator animator;

    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        selfTransform = GetComponent<Transform>();
        speed = walkSpeed;
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnGamepad)
        {
            UpdateLight();
        }
        GetComponent<Rigidbody2D>().velocity = Movement * speed;
    }

    void OnMove(InputValue value)
    {
        if (canMove)
        {
            Movement = value.Get<Vector2>();
            if (Math.Abs(Movement.x) > Math.Abs(Movement.y)){
                if (Movement.x > 0)
                {
                    animator.SetInteger("mouvement", 4);
                    transform.GetChild(1).transform.position = new Vector3(0.88f, 0.11f, 0f) + transform.position;
                }
                else
                {
                    animator.SetInteger("mouvement", 3);
                    transform.GetChild(1).transform.position = new Vector3(-0.88f, 0.11f, 0f) + transform.position;
                }
            }
            else if (Math.Abs(Movement.x) < Math.Abs(Movement.y))
            {
                if (Movement.y > 0)
                {
                    animator.SetInteger("mouvement", 1);
                    transform.GetChild(1).transform.position = new Vector3(0.50f, 0.09f, 0f) + transform.position;
                }
                else
                {
                    animator.SetInteger("mouvement", 2);
                    transform.GetChild(1).transform.position = new Vector3(0.50f, 0.09f, 0f) + transform.position;
                }
            }
            else animator.SetInteger("mouvement", 0);
        }
    }

    void UpdateLight()
    {
        if (canMove)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue()));
            Vector2 direction = new Vector2(mousePos.x - selfTransform.position.x, mousePos.y - selfTransform.position.y);
            direction.Normalize();
            float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
            lightTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnSprintStart()
    {
        speed = sprintSpeed;
        GetComponent<SoundCreator>().isPlaying = true;
    }

    void OnSprintStop()
    {
        speed = walkSpeed;
        GetComponent<SoundCreator>().isPlaying = false;
    }

    void OnInteract()
    {
        transform.GetChild(3).GetComponent<PickUpItem>().OnInteract();
    }

    void OnToggleGamepad()
    {
        if (!isOnGamepad) isOnGamepad = true;
    }

    void OnToggleKeyboard()
    {
        if (isOnGamepad) isOnGamepad = false;
    }

    void OnPause()
    {
        if (gameManager.PauseMenu.activeSelf)
        {
            gameManager.ResumeGame();
        }
        else
        {
            gameManager.PauseGame();
        }
    }

    void OnLightGamepad(InputValue value)
    {
        Vector2 LightOriantation = value.Get<Vector2>();
        if (LightOriantation != Vector2.zero)
        {
            lightTransform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-LightOriantation.x, LightOriantation.y) * Mathf.Rad2Deg);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Mob" && !isDead)
        {
            animator.SetTrigger("dead");
            isDead = true;
            gameManager.Death();
        }
    }
}
