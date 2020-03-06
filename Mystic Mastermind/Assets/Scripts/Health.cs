using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    bool isDead;

    public GameObject spawnPoint; //Where the Player spawns after death
    public GameObject player;
    public GameObject deathScreen;

    private AudioSource audioSource;
    public AudioClip deathSound;
    public AudioClip respawnSound;

    public SpellManager spellManager;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;
    void Start()
    {
        deathScreen.SetActive(false);
        audioSource = this.GetComponent<AudioSource>();
        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        mouseLook = GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>();

        isDead = false;
    }

    void Update()
    {
        
    }

    public void Death()
    {
        if (!isDead)
        {
            isDead = true;
            Invoke("Respawn", 3);

            deathScreen.SetActive(true);
            audioSource.PlayOneShot(deathSound);
            GetComponent<CharacterController>().enabled = false;

            spellManager.enabled = false;
            playerMovement.enabled = false;
            mouseLook.enabled = false;
        }
    }

    void Respawn()
    {
        isDead = false;
        player.transform.position = spawnPoint.transform.position;

        deathScreen.SetActive(false);
        audioSource.PlayOneShot(respawnSound);
        GetComponent<CharacterController>().enabled = true;

        spellManager.enabled = true;
        playerMovement.enabled = true;
        mouseLook.enabled = true;
    }
}
