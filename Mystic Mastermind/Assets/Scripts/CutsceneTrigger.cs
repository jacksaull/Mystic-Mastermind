using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject cutsceneCameraObject;
    public Animator cutscene;
    public Camera cutsceneCamera;
    public Camera mainCamera;

    public SpellManager spellManager;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;
    bool activated;
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        cutsceneCamera = cutsceneCameraObject.GetComponent<Camera>();
        cutscene = cutsceneCameraObject.GetComponent<Animator>();
        cutsceneCamera.enabled = false;

        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        mouseLook = GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>();
    }

    void Update()
    {
        if (cutscene.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            mainCamera.enabled = true;
            cutsceneCamera.enabled = false;

            spellManager.enabled = true;
            playerMovement.enabled = true;
            mouseLook.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && activated == false)
        {
            activated = true;
            mainCamera.enabled = false;
            cutsceneCamera.enabled = true;
            cutscene.SetBool("isTriggered", true);

            spellManager.enabled = false;
            playerMovement.enabled = false;
            mouseLook.enabled = false;
        }
    }
}