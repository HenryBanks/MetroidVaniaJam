using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleContactDetection : MonoBehaviour
{
    Vector2 size;
    Vector2 boxSize;
    Vector2 boxSizeWall;
    Vector2 boxCentreRight;
    Vector2 boxCentreLeft;
    Vector2 boxCentre;
    Vector2 boxSizeEdge;
    Vector2 boxCentreEdgeRight;
    Vector2 boxCentreEdgeLeft;

    float wallSkin = 0.1f;
    float groundedSkin = 0.1f;



    bool grounded = false;
    public bool Grounded { get { return grounded; } }
    bool onWallRight;
    public bool OnWallRight { get { return onWallRight; } }
    bool onWallLeft;
    public bool OnWallLeft { get { return onWallLeft; } }
    bool groundRight;
    public bool GroundRight { get { return groundRight; } }
    bool groundLeft;
    public bool GroundLeft { get { return groundLeft; } }

    void Awake()
    {
        size = GetComponent<BoxCollider2D>().size;
        boxSizeWall = new Vector2(wallSkin, size.y * 0.8f);
        boxSize = new Vector2(size.x * 0.8f, groundedSkin);
        boxSizeEdge = new Vector2(1f, 0.1f);
    }


    // Update is called once per frame
    void Update()
    {

        boxCentreRight = (Vector2)transform.position + Vector2.right * 0.55f * (size.x + boxSizeWall.x);
        boxCentreLeft = (Vector2)transform.position + Vector2.left * 0.55f * (size.x + boxSizeWall.x);
        boxCentre = (Vector2)transform.position + Vector2.down * 0.55f * (size.y + boxSize.y);
        boxCentreEdgeRight = (Vector2)transform.position + Vector2.right * 0.55f * (size.x + boxSizeEdge.x) + Vector2.down * 0.55f * transform.localScale.y * (size.y + boxSizeEdge.y);
        boxCentreEdgeLeft = (Vector2)transform.position + Vector2.left * 0.55f * (size.x + boxSizeEdge.x) + Vector2.down * 0.55f * transform.localScale.y * (size.y + boxSizeEdge.y);

        //onWallRight = Physics2D.OverlapBox(boxCentreRight, boxSizeWall, 0f) != null;
        //onWallLeft = Physics2D.OverlapBox(boxCentreLeft, boxSizeWall, 0f) != null;
        //grounded = Physics2D.OverlapBox(boxCentre, boxSize, 0f) != null;

        grounded = Physics2D.OverlapBox(boxCentre, boxSize, 0f) != null;

        onWallLeft = Physics2D.OverlapBox(boxCentreLeft, boxSizeWall, 0f) != null;
        onWallRight = Physics2D.OverlapBox(boxCentreRight, boxSizeWall, 0f) != null;

        groundLeft = Physics2D.OverlapBox(boxCentreEdgeLeft, boxSizeEdge, 0f) != null;
        groundRight = Physics2D.OverlapBox(boxCentreEdgeRight, boxSizeEdge, 0f) != null;

        if (!GroundLeft)
        {
            Debug.Log(groundLeft);
            Debug.Log("Not GroundLeft");
        }

        if (!GroundRight)
        {
            Debug.Log(groundRight);
            Debug.Log("Not GroundRight");
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(boxCentreRight, boxSizeWall);
        Gizmos.DrawCube(boxCentreLeft, boxSizeWall);

        Gizmos.color = Color.green;
        Gizmos.DrawCube(boxCentre, boxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCentreEdgeRight, boxSizeEdge);
        Gizmos.DrawCube(boxCentreEdgeLeft, boxSizeEdge);
    }
}
