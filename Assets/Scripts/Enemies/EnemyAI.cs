using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum State { notDetected, detected};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Player.instance.transform.position - transform.position,10f);
        if (hit2D.collider != null)
        {
            Debug.Log(hit2D.collider.name);
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
    }

    protected virtual void DetectedBehaviour()
    {
        Debug.Log("Detected");
    }
}
