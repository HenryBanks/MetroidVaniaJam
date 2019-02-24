using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBombActions : MonoBehaviour
{

    [SerializeField]
    float walkSpeed;

    public float WalkSpeed { get { return walkSpeed; } }

    [SerializeField]
    float runSpeed;

    public float RunSpeed { get { return runSpeed; } }


    [SerializeField]
    Explosion explosion;

    Rigidbody2D rb2D;

    private void Awake()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void JumpAndExplode()
    {
        StartCoroutine(IEJumpAndExplode());
    }

    IEnumerator IEJumpAndExplode()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, 10f);
        yield return new WaitForSeconds(0.5f);
        Explode();
    }

    void Explode()
    {
        Debug.Log("Explode");
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
