using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    public TextMeshProUGUI objectiveTitle;
    public TextMeshProUGUI objectiveBody;
    public TextMeshProUGUI objectiveTask;
    public TextMeshProUGUI objectiveCounter;

    public string title;
    public string body;
    public string task;
    public int counterGoal;
    int counterCurrent = 0;

    public bool hasCounter;
    void Start()
    {
        objectiveTitle.text = title;
        objectiveBody.text = body;
        objectiveTask.text = task;
        if (hasCounter)
        {
            objectiveCounter.text = counterCurrent.ToString() + "/" + counterGoal.ToString();
        }
        else
        {
            objectiveCounter.text = "";
        }
    }

    void Update()
    {
        
    }

    public void UpdateCounter()
    {
        counterCurrent++;
        objectiveCounter.text = counterCurrent.ToString() + "/" + counterGoal.ToString();
        if (hasCounter && counterCurrent == counterGoal)
        {
            this.gameObject.SetActive(false);
        }
    }
}
