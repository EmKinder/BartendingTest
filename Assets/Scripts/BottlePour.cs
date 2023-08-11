using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePour : MonoBehaviour
{

    bool holdingBottle;
    bool animationPlayed;
    Animator anim;
    float pourTimer;
    float animTimer;
    public ParticleSystem ps;
    bool shotPoured;
    float pouringAnimTimer;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        holdingBottle = false;
        animationPlayed = false;
        shotPoured = false;
        pourTimer = 0.0f;
        animTimer = 0.0f;
        pouringAnimTimer = 0.0f;
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBottle)
        {
            this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10.0f));

        }
       /* if (animationPlayed && !shotPoured)
        {
            pourTimer += Time.deltaTime;
           // Debug.Log(pourTimer);
            if (pourTimer >= 3.0f)
            {
                shotPoured = true;
                Debug.Log("Shot Poured");
            }
        
        }
        if (shotPoured)
        {
            
            anim.SetBool("isPouring", false);
            pourTimer = 0.0f;
            ps.Stop();
            pouringAnimTimer += Time.deltaTime;
            if (pouringAnimTimer >= 1.5f)
            {
                Debug.Log("bottlebackup");
                animationPlayed = false;
                pouringAnimTimer = 0.0f;
                shotPoured = false;
            }
        }*/
    
    }

    private void OnMouseDown()
    {
        if (!holdingBottle)
        {
            holdingBottle = true;
        }
        else
        {
            holdingBottle = false;
        }
    }

    private void OnMouseDrag()
    {
       // if (!shotPoured) { 
            anim.SetBool("isPouring", true);
            if (!animationPlayed)
            {
            animTimer += Time.deltaTime;
            if (animTimer >= 2.0f)
            {
                animationPlayed = true;
                ps.Play();
                animTimer = 0.0f;
            }
        }
       // }

    }
    private void OnMouseUp()
    {
        Debug.Log("Mouse up");
        anim.SetBool("isPouring", false);
        animationPlayed = false;
        animTimer = 0.0f;
        pouringAnimTimer = 0.0f;
        shotPoured = false;
        animationPlayed = false;
        ps.Stop();
    }
}
