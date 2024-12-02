using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField]
    private GameObject hose;

    [SerializeField]
    private float amountExtinguished = 1.0f;

    [SerializeField]
    private float range = 100f;

    [SerializeField]
    private ParticleSystem water;

   private float startRange, startEm;

   private Vector3 startScale;

   [SerializeField]
   private bool hoseOn;

   [SerializeField]
   private float emRate;

   [SerializeField]
   private float changeRate = 1.0f;

   private AudioSource waterAudio;

    

    // Start is called before the first frame update
    void Start()
    {
        startRange = range;
        range = 0;
        startEm = water.emission.rateOverTime.constant;
        var emission = water.emission;
        emission.rateOverTime = 0;
        startScale = water.transform.localScale;
        emRate = 0;

        waterAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var emission = water.emission;

       

       if(hoseOn)
       {
           range = startRange;
           if (emRate < startEm){
               emission.rateOverTime = emRate + changeRate * Time.deltaTime;
               emRate += changeRate +Time.deltaTime;
           }
           if (!waterAudio.isPlaying)
           {
               waterAudio.Play();
           }
       }
       else 
       {
           range = 0;
           if(emRate > 0f)
           {
               emission.rateOverTime = emRate + changeRate * Time.deltaTime;
               emRate -= changeRate +Time.deltaTime;
           }
       }

       if(emRate > startEm)
       {
            emission.rateOverTime = startEm;
            emRate = startEm;
       }
       if(emRate < 0)
       {
            emission.rateOverTime = 0;
            emRate = 0f;
            waterAudio.Stop();
        }
         
       if(Physics.Raycast(hose.transform.position, hose.transform.forward, out RaycastHit hit, range)
       && hit.collider.TryGetComponent(out Fire fire))
       {
           //print(hit.collider.name);
       fire.TryExtinguish(amountExtinguished * Time.deltaTime);
       }
       
            
    }

    public void On(bool on)
    {
        hoseOn = on;
    }

    

}
