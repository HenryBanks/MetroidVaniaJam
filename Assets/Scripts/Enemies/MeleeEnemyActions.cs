using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyActions : MonoBehaviour
{
    [SerializeField]
    float walkSpeed;

    public float WalkSpeed { get { return walkSpeed; } }

    [SerializeField]
    float runSpeed;

    public float RunSpeed { get { return runSpeed; } }

    bool slashing;
    public bool Slashing{get{return slashing;}}

    EnemySlash enemySlash;

    Rigidbody2D rb2D;

    private void Awake()
    {
        enemySlash = GetComponentInChildren<EnemySlash>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void StartSlash()
    {
        slashing=true;
        Debug.Log("StartSlash");
        StartCoroutine(PauseThenSlash());
    }

    IEnumerator PauseThenSlash()
    {
        rb2D.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.5f);
        Slash();
    }

    void Slash()
    {
        Debug.Log("Slash");
        enemySlash.gameObject.SetActive(true);
        StartCoroutine(PauseAfterSlash());
    }

    IEnumerator PauseAfterSlash()
    {
        rb2D.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.2f);
        enemySlash.gameObject.SetActive(false);
        slashing = false;
    }

}
