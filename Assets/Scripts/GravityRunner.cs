using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GravityRunner : MonoBehaviour {
    public static GravityRunner Instance;
    private float speed = 0f;
    public float groundCheckRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask ground;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool gravityInverted = false;
    
    //ui
    public GameObject gameStartUI;
    public GameObject gameOverUI;
    
    //animator
    public Animator animator;
    private bool isRunning = false;
    
    // Audio Manager 
    [SerializeField] private AudioManager audioManager;
    
    // Buttons
    [SerializeField] private Button dButton;
    [SerializeField] private Button spaceButton;

    private void Awake() {
        Instance = this;
    }
    //start
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    
    //update method
    void Update() {

        if (transform.position.y >= -14f && transform.position.y >= -28f) {
            gameOverUI.SetActive(true);
            GameMechanics.Instance.SceneReload();
            Destroy(gameObject);
        }
        
        // Start the game on D key
        if (Input.GetKeyDown(KeyCode.D)) {
            gameStartUI.SetActive(false);
            isRunning = true;
            audioManager.PlayRunningAudio();
            speed = 3f;
        }
        // Move the player if game has started
        // Move the player if game has started and not frozen
        if (isRunning) {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }

        // Ground check
        Collider2D groundHit = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        isGrounded = groundHit != null;

        // Gravity flip and jump on Space key only when grounded
        if (Input.GetKeyDown(KeyCode.Space)) {
            FlipGravity();
        }
        

        // Handle animations
        if (isGrounded) {
            Debug.Log("grounded");
            animator.SetBool("isRunning", isRunning);
            animator.SetBool("isJumping", false);
        } else {
            Debug.Log("Not grounded");
            animator.SetBool("isJumping", true);
        }
        
    }

    public void Freeze() {
        speed = 0f;
        isRunning = false;
        animator.SetBool("isRunning", false);
    }

    public void UnFreeze() {
        speed = 3f;
        isRunning = true;
        animator.SetBool("isRunning", true);
    }

    public void EmulateD() {
        gameStartUI.SetActive(false);
        isRunning = true;
        audioManager.PlayRunningAudio();
        speed = 3f;
        dButton.gameObject.SetActive(false);
        spaceButton.gameObject.SetActive(true);
    }
    
    public IEnumerator FreezeCoroutine() {
        Freeze();
        yield return new WaitForSeconds(3f);
        UnFreeze();
    }
    
    public void FlipGravity() {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        gravityInverted = !gravityInverted;
        rb.gravityScale *= -1;

        // Flip the player visually
        transform.Rotate(0f, 0f, 180f);

        Debug.Log("Gravity flipped. New gravity scale: " + rb.gravityScale);
    }
    
    
    
}