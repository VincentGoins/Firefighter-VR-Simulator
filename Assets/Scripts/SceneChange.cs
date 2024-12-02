using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Detected!");
        SceneManager.LoadScene("Indoors Scene", LoadSceneMode.Single);
    }
}
