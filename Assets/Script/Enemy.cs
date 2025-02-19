using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float distance = 5f;
    private Vector3 startPos;
    private bool MovingRight = true;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftBoard = startPos.x - distance;
        float rightBoard = startPos.x + distance;
        if (MovingRight)
        {
            transform.Translate(Vector2.right*speed*Time.deltaTime);
            if(transform.position.x > rightBoard)
            {
                MovingRight = false;
                flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
            if(transform.position.x < leftBoard)
            {
                MovingRight= true;
                flip();
            }
        }
    }
    private void flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
