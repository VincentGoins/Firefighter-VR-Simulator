using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    
    [SerializeField]
    private float timeRemaining = 3;

    private int minutes, seconds;

    [SerializeField]
    private bool start;

    [SerializeField]    
    private GameObject winLose;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(start && timeRemaining >0)
        {
        timeRemaining -= Time.deltaTime;
        minutes = Mathf.FloorToInt(timeRemaining/60);
        seconds = Mathf.FloorToInt(timeRemaining %60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if(timeRemaining<=0)
        {
          winLose.GetComponent<WinLose>().Lose();
        }
        
    }

    public void StartTime()
    {
        start = true;
    }
}
