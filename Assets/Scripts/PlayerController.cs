using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public bool canMove = false;
    public float runSpeed;
    public float sensitivityMultiplier;
    public float deltaThreshold;
    Vector2 firstTouchPosition;
    float finalTouchX;
    Vector2 currentTouchPosition;
    public float minXPos;
    public float maxXPos;
    Rigidbody rb;
    public PlayerAnimations playerAnim;
    public GameObject tap;
    public Button nextLevelButton;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tap.SetActive(true);
        nextLevelButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (canMove)
        {
            SwipeMovement();
        }
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            FixedRun();
        }
    }
    public void GameStart()
    {
        canMove = true;
        playerAnim.Run();
        tap.SetActive(false);
    }
    void ResetValues()
    {
        rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
        firstTouchPosition = Vector2.zero;
        finalTouchX = 0f;
        currentTouchPosition = Vector2.zero;

    }
    public void MovementStop()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
        nextLevelButton.gameObject.SetActive(true);
    }

    void FixedRun()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, runSpeed * Time.fixedDeltaTime);
    } 

    void SwipeMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            currentTouchPosition = Input.mousePosition;
            Vector2 touchDelta = (currentTouchPosition - firstTouchPosition);

            if (firstTouchPosition == currentTouchPosition)
            {
                rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
            }

            finalTouchX = transform.position.x;

            if (Mathf.Abs(touchDelta.x) >= deltaThreshold)
            {
                finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
            }

            rb.position = new Vector3(finalTouchX, transform.position.y, transform.position.z);
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, minXPos, maxXPos), rb.position.y, rb.position.z);

            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ResetValues();
        }
    }
}
