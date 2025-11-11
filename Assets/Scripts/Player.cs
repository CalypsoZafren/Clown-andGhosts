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
    private float xRotation;
    private Rigidbody2D rb;
    private Vector3 originalScale;
    private Ghost currentGhost;
    private bool ghostInRange = false;
    [SerializeField]
    private GameObject Pocket;
    public Animator pocketAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        originalScale = spriteTransform.localScale;
        xRotation = originalScale.x;
    }

    private void Update()
    {
        ObjectInput();

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MovementInput();
        MovePlayer();
        RotatePlayer();
  
        
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
            xRotation = originalScale.x * -1;

        }
        else if (xMovement < 0)
        {
            facingRight = true;
            xRotation = originalScale.y * 1;
        }



        spriteTransform.localScale = new Vector3 (xRotation, originalScale.y, originalScale.z);
    }

    private void ObjectInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && ghostInRange) {
            currentGhost.itemCheck(1);
            currentGhost.StartCoroutine(currentGhost.DieAfter2());

        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ghostInRange)
        {
            currentGhost.itemCheck(2);
            currentGhost.StartCoroutine(currentGhost.DieAfter2());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && ghostInRange)
        {
            currentGhost.itemCheck(3);         
            currentGhost.StartCoroutine(currentGhost.DieAfter2());           
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && ghostInRange)
        {
            currentGhost.itemCheck(4);
            currentGhost.StartCoroutine(currentGhost.DieAfter2());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            currentGhost = collision.GetComponentInParent<Ghost>();
            ghostInRange = true;
            pocketAnim.SetBool("Open", true);
            pocketAnim.SetBool("Close", false);
            //Debug.Log("Hit Ghost");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            currentGhost = null;
            ghostInRange = false;
            pocketAnim.SetBool("Open", false);
            pocketAnim.SetBool("Close", true);
            //Debug.Log("Left Ghost");
        }
    }
}
