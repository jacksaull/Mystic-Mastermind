using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject prompt;
    bool inRange;
    bool cooldown;
    bool inPlace;

    public PuzzleDoor puzzleDoor;
    public GameObject puzzleDoorLayer;
    public int puzzleDoorLayerNum;
    void Start()
    {
        inRange = false;
        cooldown = false;
        inPlace = false;
        puzzleDoor = GameObject.FindWithTag("Puzzle Door").GetComponent<PuzzleDoor>();
    }

    void Update()
    {
        if (Input.GetKeyDown("t") && cooldown == false)
        {
            if (inRange == true)
            {
                puzzleDoor.source.Play();
                cooldown = true;
                Invoke("Cooldown", 5);

                puzzleDoorLayer.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);

                puzzleDoorLayerNum++;
                if (puzzleDoorLayerNum == 4)
                {
                    puzzleDoorLayerNum = 0;
                }
            }
            if (puzzleDoorLayerNum == 0)
            {
                inPlace = true;
                puzzleDoor.correctPlacement++;
            }
            else if (puzzleDoorLayerNum != 0 && inPlace == true)
            {
                puzzleDoor.correctPlacement--;
                inPlace = false;
            }
        }
    }

    void Cooldown()
    {
        cooldown = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            prompt.SetActive(true);
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            prompt.SetActive(false);
            inRange = false;
        }
    }
}
