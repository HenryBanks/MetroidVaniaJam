using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected Rigidbody2D rb2D;
    protected enum State { notDetected, detected };

    protected SimpleContactDetection simpleContactDetection;

    State state;
    protected State GetState() { return state; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        simpleContactDetection = GetComponent<SimpleContactDetection>();
        rb2D = GetComponent<Rigidbody2D>();
        state = State.notDetected;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Player.instance.transform.position - transform.position);
        if (hit2D.collider != null)
        {
            //Debug.Log(hit2D.collider.name);
            if (hit2D.collider.CompareTag("Player"))
            {
                DetectedBehaviour();
            }
            else
            {
                NotDetectedBehaviour();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Player.instance.transform.position);
    }

    protected virtual void NotDetectedBehaviour()
    {
        Debug.Log("Not Detected");
        state = State.notDetected;
    }

    protected virtual void DetectedBehaviour()
    {
        Debug.Log("Detected");
        state = State.detected;
    }
}
