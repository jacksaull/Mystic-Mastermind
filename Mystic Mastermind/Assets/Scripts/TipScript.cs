using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TipScript : MonoBehaviour
{
    bool isTriggered;

    public GameObject tipScreen; //The Tip Interface
    public TextMeshProUGUI tipTitle; //The Tip Title
    public TextMeshProUGUI tipBody; //The Tip Description

    public TextMeshProUGUI promptText;
    public GameObject prompt;

    public Image image1; //Image to help with Tip
    public Image image2; //Image to help with Tip

    public Sprite tipImage1; //Sprite to go on Image 1
    public Sprite tipImage2; //Sprite to go on Image 2
    public string tipTitleText; //Text to be the Tip Title
    public string tipBodyText; //Text to be the Tip Body
    void Start()
    {
        tipScreen.SetActive(false);
        tipTitle.text = tipTitleText;
        tipBody.text = tipBodyText;
        image1.sprite = tipImage1;
        image2.sprite = tipImage2;
        prompt.SetActive(false);

        isTriggered = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("t") && isTriggered && tipScreen.activeSelf == false)
        {
            tipScreen.SetActive(true);
            prompt.SetActive(false);
        }
        else if (Input.GetKeyDown("t") && isTriggered && tipScreen.activeSelf == true)
        {
            tipScreen.SetActive(false);
            prompt.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            prompt.SetActive(true);
            isTriggered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            tipScreen.SetActive(false);
            prompt.SetActive(false);
            isTriggered = false;
        }
    }
}
