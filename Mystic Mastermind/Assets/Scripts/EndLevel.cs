using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public string level; //Name of next Scene
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(level);
        }
    }
}
