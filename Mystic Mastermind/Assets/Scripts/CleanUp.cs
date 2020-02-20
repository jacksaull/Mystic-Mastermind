using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Clean", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Clean()
    {
        Destroy(this.gameObject);
    }
}
