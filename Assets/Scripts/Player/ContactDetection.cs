using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDetection : MonoBehaviour {

    Vector2 playerSize;
    Vector2 boxSize;
    Vector2 boxSizeWall;
    Vector2 boxCentreRight;
    Vector2 boxCentreLeft;
    Vector2 boxCentre;

    float wallSkin = 0.05f;
    float groundedSkin = 0.05f;



    bool grounded=false;
    public bool Grounded { get { return grounded; } }
    bool onWallRight;
    public bool OnWallRight { get { return onWallRight; } }
    bool onWallLeft;
    public bool OnWallLeft { get { return onWallLeft; } }

    void Awake()
    {
        playerSize = GetComponent<BoxCollider2D>().size;
        boxSizeWall = new Vector2(wallSkin, playerSize.y * 0.8f);
        boxSize = new Vector2(playerSize.x * 0.8f,groundedSkin);
    }


    // Update is called once per frame
    void Update () {

        boxCentreRight = (Vector2)transform.position + Vector2.right * 0.5f * (playerSize.x + boxSizeWall.x);
        boxCentreLeft = (Vector2)transform.position + Vector2.left * 0.5f * (playerSize.x + boxSizeWall.x);
        boxCentre = (Vector2)transform.position + Vector2.down * 0.5f * (playerSize.y + boxSize.y);

        //onWallRight = Physics2D.OverlapBox(boxCentreRight, boxSizeWall, 0f) != null;
        //onWallLeft = Physics2D.OverlapBox(boxCentreLeft, boxSizeWall, 0f) != null;
        //grounded = Physics2D.OverlapBox(boxCentre, boxSize, 0f) != null;

        if(Physics2D.OverlapBox(boxCentre, boxSize, 0f) != null)
        {
            grounded = true;
        }
        else
        {
            StartCoroutine(LeftGround());
        }

        if (Physics2D.OverlapBox(boxCentreLeft, boxSizeWall, 0f) != null)
        {
            onWallLeft = true;
        }
        else
        {
            StartCoroutine(LeftLeftWall());
        }

        if (Physics2D.OverlapBox(boxCentreRight, boxSizeWall, 0f) != null)
        {
            onWallRight = true;
        }
        else
        {
            StartCoroutine(LeftRightWall());
        }

    }

    IEnumerator LeftGround()
    {
        yield return new WaitForSeconds(0.05f);
        grounded = false;
    }

    IEnumerator LeftLeftWall()
    {
        yield return new WaitForSeconds(0.05f);
        onWallLeft = false;
    }

    IEnumerator LeftRightWall()
    {
        yield return new WaitForSeconds(0.05f);
        onWallRight = false;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(boxCentreRight, boxSizeWall);
        Gizmos.DrawCube(boxCentreLeft, boxSizeWall);

        Gizmos.color = Color.green;
        Gizmos.DrawCube(boxCentre, boxSize);
    }

}
