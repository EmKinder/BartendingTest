using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JiggerFill : MonoBehaviour
{
    float timer;
    public Image jiggerFill;
    bool thisFull;
    bool isHolding;
    string alcohol;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        jiggerFill.fillAmount = 0.0f;
        thisFull = false;
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(jiggerFill.fillAmount == 1.0f)
        {
            thisFull = true;
        }
        if (isHolding)
        {
            this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10.0f));

        }
    }

    public void Fill()
    {
        timer += Time.deltaTime;
        jiggerFill.fillAmount = timer;
        if(alcohol == "Whisky")
        {
            jiggerFill.color = new Color(0.4f, 0.24f, 0, 0.9f);
        }
        else if(alcohol == "Vodka")
        {
            jiggerFill.color = Color.white;
        }
        
    }

    public bool JiggerFull()
    {
        return thisFull;
    }

    public void EmptyJigger()
    {
        jiggerFill.fillAmount = 0.0f;
        thisFull = false;
        timer = 0.0f;
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

    public void TypeOfAlcohol(string tag)
    {
        alcohol = tag;
    }

    public string GetTypeOfAlcohol()
    {
        return alcohol;
    }

}
