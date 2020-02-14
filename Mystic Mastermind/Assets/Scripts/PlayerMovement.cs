using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //The Character Controller component on the Player
    public GameObject playerTransform; //GameObject component of the Player

    private float characterControllerHeight; //Height of the Character Controller
    private Vector3 characterHeight; //Height of the Player Model
    public float speed = 5f; //Speed of the Player
    public float gravity = -19f; // Gravity strength on the Player
    public float jumpHeight = 3f; //Strength of the Players jump

    public Transform groundCheck; //Position of where the ground check will be made from
    public float groundDistance = 0.4f; //Range of the ground check
    public LayerMask groundMask; //Checks whether a certain layer has been made contact with

    Vector3 velocity; //Velocity of the Player falling
    bool isGrounded; //Bool for whether the Player is currently on the ground
    void Start()
    {
        characterControllerHeight = controller.height; //Gets the Player height upon starting
        characterHeight = playerTransform.transform.localScale; //Gets the Scale of the Player upon starting
    }


    void Update()
    {
        /*Checks whether the Player is currently touching the ground and sets the velocity to a locked value*/
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        /*Gets the movement for forward and side movement from the keyboard*/
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        /*Calculates the movement based on the forward and side movement and sents values to the controller attached to the Player to move the Player*/
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        /*Causes the Player to jump upon pressing the Space key*/
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        /*Increases the falling velocity for the Player when not contacting the ground*/
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        /*Causes the Player to sprint upon pressing the Shift key*/
        if (Input.GetButton("Sprint") && isGrounded)
        {
            speed = 12f;
            Debug.Log("Sprint");
        }
        else if (Input.GetButton("Sprint") && Input.GetButton("Jump"))
        {
            speed = 12f;
            Debug.Log("Sprint Jump");
        }
        else if (isGrounded)
        {
            speed = 5f;
            Debug.Log("Walk"); 
        }

        /*Shrinks the Player upon crouching*/
        if (Input.GetButton("Crouch"))
        {
            controller.height = 1.5f;
            characterHeight = new Vector3(1, 0.75f, 1);
            playerTransform.transform.localScale = characterHeight;
        }
        else if (Input.GetButtonDown("Crouch") == false)
        {
            controller.height = characterControllerHeight;
            characterHeight = new Vector3(1, 1.5f, 1);
            playerTransform.transform.localScale = characterHeight;
        }
    }
}
