using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeList : MonoBehaviour
{
    List<string> whiskey = new List<string>();
    List<List<string>> recipies = new List<List<string>>();
    // Start is called before the first frame update
    void Start()
    {
        whiskey.Add("Whisky");
        recipies.Add(whiskey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<List<string>> ReturnAllRecipies()
    {
        return recipies;
    }
}
