using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
  public float hp;
  public GameObject Destroyed;
  private void OnCollisionEnter(Collision collision){
    if(collision.gameObject.tag == "Axe"){
        hp--;
    }
  }

  private void Update(){
    if(hp == 0){
        Instantiate(Destroyed, transform.position, transform.rotation);
        Destroy(gameObject);
    }
  }
}
