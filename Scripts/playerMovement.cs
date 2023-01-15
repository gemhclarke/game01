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


    void Start()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
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
    }

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

    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Patroller")
            {
                SceneManager.LoadScene(activeScene.name);
                //SceneManager.LoadScene("Game");
            }
    }    
}
