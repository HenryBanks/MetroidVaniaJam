using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    string ignoredTag;

    [SerializeField]
    int damage;

    [SerializeField]
    float xForce;

    [SerializeField]
    float yForce;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag != ignoredTag)
        {
            Damagable collDamagable = coll.GetComponent<Damagable>();
            if (collDamagable != null)
            {
                collDamagable.LoseHealth(damage);
            }
            Rigidbody2D rb2D = coll.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                rb2D.AddForce(new Vector2(Player.instance.transform.localScale.x*xForce, yForce));
            }
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }

}
