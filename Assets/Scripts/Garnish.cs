using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garnish : MonoBehaviour
{
    public GameObject olive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        Instantiate(olive);
    }
}
