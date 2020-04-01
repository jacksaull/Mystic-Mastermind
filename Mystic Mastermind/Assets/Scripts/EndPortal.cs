using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class EndPortal : MonoBehaviour
{
    public GameObject endScreen;
    public TextMeshProUGUI levelTitle;

    public SpellManager spellManager;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;
    void Start()
    {
        endScreen.SetActive(false);
        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        mouseLook = GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>();

        levelTitle.text = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            endScreen.SetActive(true);
            spellManager.enabled = false;
            playerMovement.enabled = false;
            mouseLook.enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
