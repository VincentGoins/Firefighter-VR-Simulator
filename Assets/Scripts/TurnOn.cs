using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{

    [SerializeField]
    private GameObject waterGun;

    [SerializeField]
    private bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hose")
        {
            on = true;
            waterGun.GetComponent<Extinguisher>().On(on);
        }
    }

    void OnCollisionExit (Collision collision){
        if (collision.gameObject.tag == "Hose")
        {
            on = false;
            waterGun.GetComponent<Extinguisher>().On(on);
        }
    }
}
