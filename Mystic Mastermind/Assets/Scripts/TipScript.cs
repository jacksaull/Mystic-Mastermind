using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TipScript : MonoBehaviour
{
    public GameObject tipScreen; //The Tip Interface
    public TextMeshProUGUI tipTitle; //The Tip Title
    public TextMeshProUGUI tipBody; //The Tip Description
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
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            tipScreen.SetActive(true);
            Debug.Log(other.gameObject.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            tipScreen.SetActive(false);
        }
    }
}
