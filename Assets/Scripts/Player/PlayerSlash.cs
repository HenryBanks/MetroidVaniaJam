using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    [SerializeField]
    string ignoredTag;

    [SerializeField]
    int damage;

    [SerializeField]
    float attackTime;

    float timeOfLastAttack = 0f;

    private Vector2 slashSize = new Vector2(1f, 1f);
    Vector2 slashCentre;
    Vector2 size;

    private void Awake()
    {
        size = GetComponent<BoxCollider2D>().size;
    }

    // Update is called once per frame
    void Update()
    {
        slashCentre = (Vector2)transform.position + Vector2.right * Mathf.Sign(transform.localScale.x) * 0.55f * (size.x + slashSize.x);


        if (InputManager.instance.AttackInputDown() && Time.time > timeOfLastAttack + attackTime)
        {
            timeOfLastAttack = Time.time;
            Slash();
        }
    }

    void Slash()
    {
        Debug.Log("Slash");

        slashCentre = (Vector2)transform.position + Vector2.right * Mathf.Sign(transform.localScale.x) * 0.55f * (size.x + slashSize.x);
        
        Collider2D[] colliders = Physics2D.OverlapBoxAll(slashCentre, slashSize, 0f);

        foreach (Collider2D coll in colliders)
        {
            if (coll.gameObject.tag != ignoredTag)
            {
                Debug.Log(coll.gameObject.name);

                Damagable collDamagable = coll.GetComponent<Damagable>();
                if (collDamagable != null)
                {
                    collDamagable.LoseHealth(damage);
                }
                Debug.Log("hit");
            }
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(slashCentre, slashSize);
    }


}
