using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseShake : MonoBehaviour
{

    public bool shake;
    bool holdingShaker;
    public GameObject selectedItem;
    float timer = 0.0f;
    public Image fill;
    List<string> currentIngredients = new List<string>();
    Vector2 oldMouseAxis;
    public Text cocktail;
    float cocktailTimer;
    string tempCollisionName;
    GameObject tempCollisionObject;
    bool isTriggering;
    bool isTriggeringJigger;
    public RecipeList rl;
    //string thisName;

    void Start()
    {
        holdingShaker = false;
        fill.enabled = false;
        fill.fillAmount = 0.0f;
        cocktail.enabled = false;
        isTriggering = false;
        isTriggeringJigger = false;

    }
    void Update()
    {


        if (holdingShaker && currentIngredients.Count != 0)
        {
            fill.enabled = true;
            Vector2 mouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            this.shake = Mathf.Sign(mouseAxis.x) != Mathf.Sign(this.oldMouseAxis.x) ||
                     Mathf.Sign(mouseAxis.y) != Mathf.Sign(this.oldMouseAxis.y);
            this.oldMouseAxis = mouseAxis;
            this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10.0f));

            if (this.shake)
            {
                timer += Time.deltaTime;
                fill.fillAmount = timer * 2;
                Debug.Log(timer);
                if(timer >= 0.5f)
                {
                    //Debug.Log("Here's your " + currentIngredients[0].ToString() + " cocktail!");
                    cocktail.enabled = true;
                    foreach (List<string> list in rl.ReturnAllRecipies())
                    {
                        foreach (string ingredient in list)
                        {
                            if (ingredient == currentIngredients[0])
                            {
                                cocktail.text = "Enjoy your " + list.ToString();
                                
                            }
                            else
                            {
                                cocktail.text = "rip";
                            }
                        }
                    }
                    //if(currentIngredients.Count != 0) { 
                    //    cocktail.text = "Enjoy your " + currentIngredients[0].ToString() + " cocktail!";
                   // }
                    //else
                   // {
                    //    cocktail.text = "Enjoy your spicy air ig";
                   // }
                    holdingShaker = false;
                    timer = 0;
                    fill.enabled = false;
                    currentIngredients.Clear();
                }
            }
        }
        if (cocktail.enabled == true)
        {
            cocktailTimer += Time.deltaTime;
            if(cocktailTimer >= 2.0f)
            {
                cocktail.enabled = false;
                cocktailTimer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && isTriggering)
        {
            AddIngredient(tempCollisionName);
            Destroy(tempCollisionObject);

        }

        if(Input.GetMouseButtonDown(0) && isTriggeringJigger)
        {
            AddIngredient(tempCollisionName);
            tempCollisionObject.gameObject.GetComponent<JiggerFill>().EmptyJigger();
        }
    }

    private void OnMouseDown()
    {
        if (isTriggering)
        {
            return;
        }
        else if (!holdingShaker)
        {
            holdingShaker = true;
        }
        else
        {
            holdingShaker = false;
            fill.enabled = false;
        }
    }

    public void AddIngredient(string name)
    {
        currentIngredients.Add(name);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Olive") {
            tempCollisionObject = collision.gameObject;
            tempCollisionName = tempCollisionObject.GetComponent<GarnishFollow>().ReturnName();
            isTriggering = true;
        }
        if (collision.tag == "Jigger") {
            if (collision.gameObject.GetComponent<JiggerFill>().JiggerFull()) {
                tempCollisionObject = collision.gameObject;
                tempCollisionName = tempCollisionObject.GetComponent<JiggerFill>().GetTypeOfAlcohol();
                isTriggeringJigger = true;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggering = false;
        isTriggeringJigger = false;
        tempCollisionName = "";
    }
}
