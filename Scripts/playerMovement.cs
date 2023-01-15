using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Vector3 velocity;
    bool isGrounded;
    public Vector3 currrentPlayerPosition;
    private Scene activeScene;
    private bool wasdKeyPressed = false;

    void Start()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged; // Register for events from the GameStateManager
        activeScene = SceneManager.GetActiveScene();
    }

    void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        currrentPlayerPosition = move;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // This section is a bit of a temporary hack to disable scene reload when we're not
        // moving and a Patroller collides with us
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            wasdKeyPressed = true;
        } else {
            wasdKeyPressed = false;
        }
    }

    // We're subscribing to the GameStateManager events here so that we can pause the player 
    // When we reach a dialog box (the same is true for the Patrollers)
    private void OnGameStateChanged(GameState newGameState)
    {
        print("GameState changed to " + newGameState + " for " + this);
        if (newGameState == GameState.Paused)
        {
            enabled = false;
        }
        else if (newGameState == GameState.GamePlay)
        {
            enabled = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Patroller" && activeScene.name=="Game")
        {
            SceneManager.LoadScene(activeScene.name);
        } else if (other.gameObject.tag == "Patroller" && activeScene.name=="Level2" && wasdKeyPressed){
            SceneManager.LoadScene(activeScene.name);
        }
    }    
}
