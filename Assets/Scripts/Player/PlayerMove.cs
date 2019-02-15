using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	Rigidbody2D rb;
    ContactDetection contactDetection;

    float prevAbsInp = 0.0f;

    float maxSpeed = 12f;
    float accel = 25f;
    float turnAccel = 50f;

    void Awake () {
		rb = GetComponent<Rigidbody2D> ();
        contactDetection = GetComponent<ContactDetection>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Mathf.Sign(Input.GetAxis("Horizontal")));
        if (Mathf.Abs(Input.GetAxis("Horizontal")) < prevAbsInp || 
        (Mathf.Abs(Input.GetAxis("Horizontal"))<Mathf.Epsilon && contactDetection.Grounded))
        {    
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
        else if(Mathf.Abs(Input.GetAxis("Horizontal"))>Mathf.Epsilon)
        {
            if(Mathf.Abs(Mathf.Sign(rb.velocity.x) - Mathf.Sign(Input.GetAxis("Horizontal"))) < Mathf.Epsilon)//SAME SIGN
            {
                if (Mathf.Abs(rb.velocity.x) < maxSpeed)
                {
                    rb.AddForce(new Vector2(accel * Mathf.Sign(Input.GetAxis("Horizontal")), 0.0f));
                }
            }else if (Mathf.Abs(Mathf.Sign(rb.velocity.x) + Mathf.Sign(Input.GetAxis("Horizontal"))) < Mathf.Epsilon)
            {
                rb.AddForce(new Vector2(turnAccel * Mathf.Sign(Input.GetAxis("Horizontal")), 0.0f));
            }
        }
        rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x)*Mathf.Min(Mathf.Abs(rb.velocity.x),maxSpeed),rb.velocity.y);
        prevAbsInp = Mathf.Abs(Input.GetAxis("Horizontal"));
    }

    private void FixedUpdate()
    {

    }
}
