using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update


     void OnCollisionEnter(Collision collide){
        if(collide.gameObject.tag == "Main"){
             SceneManager.LoadScene("SecondScene");
        }
    }

    // Update is called once per frame
   
}
