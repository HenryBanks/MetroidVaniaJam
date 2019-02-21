using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour
{
    [SerializeField]
    Vector2 hackTargetBox;

    Hackable currentTarget;
    Vector2 hackBoxCentre;

    private void Awake()
    {
        hackBoxCentre = (Vector2)transform.position + new Vector2(transform.localScale.x * hackTargetBox.x / 2, 0f);
        currentTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        getHackTarget();

        if (PlayerInput.HackInputUp())
        {
            if (currentTarget != null)
            {
                currentTarget.SetHacked();
            }
        }

    }

    void getHackTarget()
    {
        currentTarget = null;
        hackBoxCentre = (Vector2)transform.position + new Vector2(transform.localScale.x * hackTargetBox.x / 2, 0f);
        Collider2D[] colliders=Physics2D.OverlapBoxAll(hackBoxCentre, hackTargetBox, 0);
        foreach(Collider2D coll in colliders)
        {
            if (coll.GetComponent<Hackable>()!=null)
            {
                if (currentTarget == null)
                {
                    currentTarget = coll.GetComponent<Hackable>();
                }
                else
                {
                    if(Vector2.Distance(transform.position, coll.transform.position) < Vector2.Distance(transform.position, currentTarget.transform.position))
                    {
                        currentTarget = coll.GetComponent<Hackable>();
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(hackBoxCentre, hackTargetBox);
        
        if (currentTarget != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(currentTarget.transform.position, new Vector2(1.2f, 1.2f));
        }
    }
}
