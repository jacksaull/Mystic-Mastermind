using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //The Character Controller component on the Player
    public GameObject playerTransform; //GameObject component of the Player
    public GameObject crouchCheck; //Raycast for checking above Player
    RaycastHit hit; //The Raycast
    bool stand;

    private float characterControllerHeight; //Height of the Character Controller
    private Vector3 characterHeight; //Height of the Player Model
    public float speed = 5f; //Speed of the Player
    public float gravity = -19f; // Gravity strength on the Player
    public float jumpHeight = 3f; //Strength of the Players jump

    public Transform groundCheck; //Position of where the ground check will be made from
    public float groundDistance = 0.4f; //Range of the ground check
    public LayerMask groundMask; //Checks whether a certain layer has been made contact with

    public Vector3 velocity; //Velocity of the Player falling
    bool isGrounded; //Bool for whether the Player is currently on the ground

    public AudioSource player; //Sound for Player
    public AudioClip Walk; //Walk Sound
    public AudioClip Jump; //Jump Sound
    bool playSound;
    bool running;
    bool crouching;
    float walkingInterval = 0.5f;
    float runningInterval = 0.3f;
    float crouchingInterval = 0.6f;
    void Start()
    {
        characterControllerHeight = controller.height; //Gets the Player height upon starting
        characterHeight = playerTransform.transform.localScale; //Gets the Scale of the Player upon starting
        playSound = true;
        StartCoroutine("MovementSound");
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
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            player.PlayOneShot(Jump, 1);
        }

        /*Increases the falling velocity for the Player when not contacting the ground*/
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        /*Causes the Player to sprint upon pressing the Shift key*/
        if (Input.GetButton("Sprint") && isGrounded)
        {
            speed = 9f;
            running = true;
        }
        else if (Input.GetButton("Sprint") && Input.GetButton("Jump"))
        {
            speed = 9f;
        }
        else if (isGrounded)
        {
            speed = 5f;
            running = false;
        }

        if (Physics.Raycast(crouchCheck.transform.position, crouchCheck.transform.TransformDirection(Vector3.up), out hit, 1.7f))
        {
            stand = false;
        }
        else
        {
            stand = true;
        }

        /*Shrinks the Player upon crouching*/
        if (Input.GetButton("Crouch"))
        {
            speed = 2.5f;
            controller.height = 1.5f;
            characterHeight = new Vector3(1, 0.75f, 1);
            playerTransform.transform.localScale = characterHeight;
            crouching = true;
        }
        else if (Input.GetButtonDown("Crouch") == false && stand == true)
        {
            controller.height = characterControllerHeight;
            characterHeight = new Vector3(1, 1.5f, 1);
            playerTransform.transform.localScale = characterHeight;
            crouching = false;
        }

        if (isGrounded && !playSound)
        {
            playSound = true;
            StartCoroutine("MovementSound");
        }
        if (!isGrounded && playSound)
        {
            playSound = false;
            StopCoroutine("MovementSound");
        }
    }

    IEnumerator MovementSound()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            player.PlayOneShot(Walk, 0.7f);
            if (running == false)
            {
                yield return new WaitForSeconds(walkingInterval);
            }
            else if (running == true)
            {
                yield return new WaitForSeconds(runningInterval);
            }
            else if (crouching == true)
            {
                yield return new WaitForSeconds(crouchingInterval);
            }
        }
        playSound = false;
    }
}
