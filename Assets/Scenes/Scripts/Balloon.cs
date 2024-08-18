using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    //Linked Objects
    public GameObject player;
    public Sprite basketOpen;
    public Sprite basketClosed;
    public GameObject[] leftBags;
    public GameObject[] rightBags;
    public Rigidbody2D rb;

    //Sand Bags Count
    private int leftCount = 2;
    private int rightCount = 2;
    private int carriedCount = 0;

    //Attributes
    public float maxVelocity = 15f;

    //Private Variables
    private bool engaged = false;
    private bool wasEngaged = false;
    private float addedVelocity = 0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            wasEngaged = true;
            Gas(true);
        }
        else if(wasEngaged == true)
        {
            wasEngaged = false;
            addedVelocity = 0f;
            Gas(false);
        }

        //print(rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if (engaged)
        {

            if ((rb.velocity.y + 0.002f) == 0.25f)
            {
                addedVelocity = 0.25f;
            }
            else if (addedVelocity < 0.25f)
            {
                addedVelocity += 0.002f;
            }

            if (rb.velocity.y < maxVelocity)
            {
                if ((rb.velocity.y + addedVelocity) > maxVelocity)
                {
                    rb.velocity = new Vector3(0, maxVelocity, 0);
                }
                else
                {
                    rb.velocity = new Vector3(0, rb.velocity.y + addedVelocity, 0);
                }
            }
        }
    }

    private void Gas(bool turned)
    {
        engaged = turned;
    }
}
