using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinLose : MonoBehaviour
{

    [SerializeField]
    private int fires;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fires <=0)
        {
            SceneManager.LoadScene("Win Scene", LoadSceneMode.Single);
        }
    }

    public void Putout()
    {
        fires--;
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose Scene", LoadSceneMode.Single);
    }
}
