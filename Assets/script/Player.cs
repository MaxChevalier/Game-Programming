using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    Transform selfTransform = null;
    public Transform lightTransform = null;
    public float walkSpeed = 1f;
    public float sprintSpeed = 2f;

    private float speed = 0f;
    private Vector2 Movement = Vector2.zero;

    public bool isOnGamepad = false;
    // Start is called before the first frame update
    void Start()
    {
        selfTransform = GetComponent<Transform>();
        speed = walkSpeed;
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
        GetComponent<SoundCreator>().isPlaying = true;
    }

    void OnSprintStop()
    {
        speed = walkSpeed;
        GetComponent<SoundCreator>().isPlaying = false;
    }

    void OnInteract()
    {
        GamePlayManager lvlActionManager = GameObject.Find("lvlActionManager").GetComponent<GamePlayManager>();
        if (lvlActionManager != null)
        {
            lvlActionManager.OnInteract();
        }
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
        if (other.gameObject.tag == "Mob")
        {
            // SceneManager.LoadScene("lvl 4");
        }
    }
}
