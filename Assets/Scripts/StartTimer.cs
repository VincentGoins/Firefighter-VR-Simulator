using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTimer : MonoBehaviour
{
    [SerializeField]    
    private GameObject trigger;

    [SerializeField]    
    private GameObject timer;

// Start is called before the first frame update
    void Start()
    {
        timer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

    private void OnTriggerExit(Collider other)
    {
        timer.SetActive(true);
        Debug.Log("Trigger Detected!");
        timer.GetComponent<Timer>().StartTime();
        trigger.SetActive(false);
    }
}
