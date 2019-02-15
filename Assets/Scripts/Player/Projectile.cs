using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log (coll.gameObject.tag);
        Debug.Log ("hit");
        Destroy(gameObject);
    }

}
