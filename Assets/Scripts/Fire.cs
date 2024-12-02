using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{

    [SerializeField, Range (0f,1f)]
    private float currentIntensity = 1.0f;

    [SerializeField]
    private float [] startIntensitys =new float[3];

    [SerializeField]
    private ParticleSystem [] firePS = new ParticleSystem[5];

    float timeLastWater = 0;

    [SerializeField]
    private float regenDelay = 2.5f;

    [SerializeField]
    private float regenRate = .1f;

    [SerializeField]
    private bool lit = true;

    private Vector3 [] startScale = new Vector3[3];
    
    [SerializeField]
    private bool sent;

    [SerializeField]
    private GameObject parent;

    private AudioSource source;


    private void ChangeInternsity()
    {
        //fire.transform.localScale = fire.transform.localScale * currentIntensity;
         for(int i= 0; i< firePS.Length; i++)
         {
             var emission = firePS[i].emission;
            emission.rateOverTime = currentIntensity * startIntensitys[i];
            firePS[i].transform.localScale = startScale[i] * currentIntensity;
         }
        source.volume -= 0.01f;
        Debug.Log(source.volume);
    }

    public bool TryExtinguish(float amount)
    {
        timeLastWater = Time.time;
        currentIntensity -= amount;
        ChangeInternsity();

        

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        startIntensitys = new float[firePS.Length];
        sent = false;
        source = GetComponent<AudioSource>();

        for(int i= 0; i< firePS.Length; i++)
        {
            startIntensitys[i] = firePS[i].emission.rateOverTime.constant;
            startScale[i] = firePS[i].transform.localScale;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    if(currentIntensity<=0)
    {
        lit = false;
        source.Stop();
    }
    if(lit && (Time.time - timeLastWater) >= regenDelay && currentIntensity <1.0f )
    {

        currentIntensity += regenRate * Time.deltaTime;
        ChangeInternsity();
    }

    if(!lit && !sent)
    {
        parent.GetComponent<WinLose>().Putout();
        sent = true;
    }
    }
}
