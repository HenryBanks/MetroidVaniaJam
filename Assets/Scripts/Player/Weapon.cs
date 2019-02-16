using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    GameObject shotPrefab;

    [SerializeField]
    float shotSpeed = 50f;

    [SerializeField]
    float reloadTime = 0.5f;

    float timeToNextShot = 0.0f;

    Player player;

    void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    void Update()
    {

        if (Time.timeScale > Mathf.Epsilon)
        {
            //Vector3 direction = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;
            //Debug.Log(direction);
            //transform.localPosition = direction;
            //transform.up = direction;

            if (Input.GetKey(KeyCode.Mouse0) && Time.time > timeToNextShot)
            {
                Shoot();
            }
        }

    }


    void Shoot()
    {
        timeToNextShot = Time.time + reloadTime;
        var shot = Instantiate(shotPrefab, transform.position + transform.up, transform.rotation);
        shot.GetComponent<Rigidbody2D>().velocity = transform.up * shotSpeed;
    }
}
