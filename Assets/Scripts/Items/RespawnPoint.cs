using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPoint : MonoBehaviour
{
    [SerializeField]
    Vector2 interactBox;

    CanvasGroup canvasGroup;

    [SerializeField]
    int respawnIndex;

    private void Awake()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll((Vector2)transform.position, interactBox, 0);
        bool playerDetected = false;
        foreach (Collider2D coll in colliders)
        {
            if (coll.CompareTag("Player"))
            {
                Debug.Log("Player in range");
                playerDetected = true;
            }
        }

        if (playerDetected)
        {
            canvasGroup.alpha = 1f;
            if (PlayerInput.InteractInput())
            {
                Player.instance.respawnScene = SceneManager.GetActiveScene().buildIndex;
                Player.instance.respawnIndex = respawnIndex;
            }
        }
        else
        {
            canvasGroup.alpha = 0f; 
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, interactBox);

    }

}
