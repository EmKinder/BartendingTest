using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarnishFollow : MonoBehaviour
{
    bool isHolding;
    bool isTriggeringBin;
    public string thisName;
    // Start is called before the first frame update
    void Start()
    {
        isHolding = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10.0f));

        }
    }

    private void OnMouseDown()
    {
        if (!isHolding)
        {
            isHolding = true;
        }
        else
        {
            isHolding = false;
        }
    }

    public void isTriggering(bool bin)
    {
        isTriggeringBin = bin;
    }

    public string ReturnName()
    {
        return thisName;
    }


}
