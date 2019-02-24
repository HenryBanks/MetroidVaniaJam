using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingRangedActions : MonoBehaviour
{

    [SerializeField]
    float walkSpeed;

    public float WalkSpeed { get { return walkSpeed; } }

    [SerializeField]
    float runSpeed;

    public float RunSpeed { get { return runSpeed; } }

    Rigidbody2D rb2D;
    public float TimeToNextShot { get; private set; }


    [SerializeField]
    float reloadTime;

    [SerializeField]
    Projectile shotPrefab;



    private void Awake()
    {
        TimeToNextShot = 0.0f;
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        TimeToNextShot = Time.time + reloadTime;
        var shot = Instantiate(shotPrefab, (Vector2)transform.position + direction*1.5f, Quaternion.LookRotation(Vector3.forward,direction));
        //shot.GetComponent<Rigidbody2D>().velocity = transform.up * shotSpeed;
    }

}
