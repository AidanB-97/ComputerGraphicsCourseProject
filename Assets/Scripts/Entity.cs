using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //All code here was made with code from previous projects during year 1


    public float moveXAmt;
    public float moveYAmt;
    public float moveZAmt;
    public float moveTime;

    private Vector3 posStart;
    private Vector3 posEnd;

    private float moveTimer = 0.0f;
    private bool forwards = true;

    void Start()
    {
        posStart = transform.position;
        posEnd = posStart + new Vector3(moveXAmt, moveYAmt, moveZAmt);
    }

    void Update()
    {
        moveTimer += Time.deltaTime;

        Vector3 p1 = (forwards) ? posStart : posEnd;
        Vector3 p2 = (forwards) ? posEnd : posStart;

        float t = Mathf.Clamp(moveTimer / moveTime, 0.0f, 1.0f);
        transform.position = Vector3.Lerp(p1, p2, t);

        if (moveTimer >= moveTime)
        {
            moveTimer = 0.0f;
            forwards = !forwards;
        }
    }
}
