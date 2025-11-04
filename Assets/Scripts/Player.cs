using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    private Transform spriteTransform;
    private float xMovement;
    private float yMovement;
    public int movementSPeed = 5;
    private Vector2 moveDirection;
    public bool facingRight = true;
    private int xRotation = 1;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MovementInput();
        MovePlayer();
        RotatePlayer();
        ObjectInput();
        
    }

    private void MovementInput() {
        xMovement = Input.GetAxisRaw("Horizontal");
        yMovement = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(xMovement, yMovement).normalized;
    }

    private void MovePlayer()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * movementSPeed, moveDirection.y * movementSPeed);
    }

    private void RotatePlayer()
    {

        if(xMovement > 0)
        {
            facingRight = false;
            xRotation = 1;

        }
        else if (xMovement < 0)
        {
            facingRight = true;
            xRotation = -1;
        }



        spriteTransform.localScale = new Vector3 (xRotation, 1, 1);
    }

    private void ObjectInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("Using Duck");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Using Nose");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Using Rose");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Using Ribbon");
        }

    }
}
