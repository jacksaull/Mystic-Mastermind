using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : BaseSpell
{
    Vector3 boost; //Boost Vectors
    float gravity = -19f; // Gravity strength on the Player
    public float jumpBoost; //Strength of Spell Jump Boost

    public PlayerMovement playerMovement; //The Script for Player Movement to apply the boost
    public GameObject effectPos; //The position to apply the Wind Effect
    public ParticleSystem windEffect; //The Particle System for the Wind Effect

    void Start()
    {
        spellName = "Wind";
    }   


    void Update()
    {

    }

    /*This method manages what occurs when the Spell is selected and Cast*/
    public override void CastSpell()
    {
        playerMovement.velocity.y = Mathf.Sqrt(jumpBoost * -2f * gravity);
        windEffect.Play();
    }
}
