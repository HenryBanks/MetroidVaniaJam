using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlash : MonoBehaviour
{
    [SerializeField]
    string ignoredTag;

    [SerializeField]
    int damage;

    private void Update()
    {
        Collider2D[] colliders=Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().size, 0f);

        foreach(Collider2D coll in colliders)
        {
            if (coll.gameObject.tag != ignoredTag)
            {
                Damagable collDamagable = coll.GetComponent<Damagable>();
                if (collDamagable != null)
                {
                    collDamagable.LoseHealth(damage);
                }
                Debug.Log("hit");
                gameObject.SetActive(false);
            }
        }

    }

    //void OnTriggerStay2D(Collider2D coll)
    //{
    //    Debug.Log(coll.gameObject.tag);
    //    if (coll.gameObject.tag != ignoredTag)
    //    {
    //        Damagable collDamagable = coll.GetComponent<Damagable>();
    //        if (collDamagable != null)
    //        {
    //            collDamagable.LoseHealth(damage);
    //        }
    //        Debug.Log("hit");
    //        gameObject.SetActive(false);
    //    }
    //}
}
