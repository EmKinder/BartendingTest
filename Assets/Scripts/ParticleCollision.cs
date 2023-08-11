using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem part;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Jigger")
            Debug.Log("Hitting Jigger!!!!");
        other.GetComponent<JiggerFill>().Fill();
        other.GetComponent<JiggerFill>().TypeOfAlcohol(this.tag);
       
    }
}


