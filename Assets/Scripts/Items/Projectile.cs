using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    string ignoredTag;

    [SerializeField]
    int damage;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
   }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log (coll.gameObject.tag);
        if (coll.gameObject.tag != ignoredTag)
        {
            Damagable collDamagable=coll.GetComponent<Damagable>();
            if (collDamagable!=null)
            {
                collDamagable.LoseHealth(damage);
            }
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }

}
