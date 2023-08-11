using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    bool isTriggering;
    GameObject thisOther;
    // Start is called before the first frame update
    void Start()
    {
        isTriggering = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggering && Input.GetMouseButtonDown(0))
        {
            Destroy(thisOther);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Shaker")
        {
            isTriggering = true;
            thisOther = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggering = false;
        thisOther = null;
    }
}
