using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    Player player;
    Vector3 cameraOffset;

    void Awake()
    {
        player = GetComponentInParent<Player>();
        cameraOffset = transform.position - Camera.main.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > Mathf.Epsilon)
        {
            Vector3 direction = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;
            Debug.Log(direction);
            transform.localPosition = direction;
            transform.up = direction;
        }
    }

}
