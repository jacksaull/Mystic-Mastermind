using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject parent;
    public GameObject arrow; //Ammo Prefab for the Trap
    public GameObject arrowSpawn; //Where Arrows will shoot from
    public float shootInterval; //How often Arrows should shoot from the trap
    public float offset; //Offset for when Trap starts
    public AudioClip shootEffect;
    private AudioSource audioSource;
    void Start()
    {
        InvokeRepeating("ShootArrow", offset, shootInterval);
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void ShootArrow()
    {
        if (parent.activeSelf == true)
        {
            Instantiate(arrow, arrowSpawn.transform.position, arrowSpawn.transform.rotation);
            audioSource.PlayOneShot(shootEffect);
        }
    }
}
