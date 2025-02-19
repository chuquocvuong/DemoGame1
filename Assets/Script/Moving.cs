using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform postA;
    public Transform postB;
    public float speed = 2.0f;
    private Vector3 target;
    private Transform player;
    void Start()
    {
        target = postA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            if(target == postA.position)
            {
                target = postB.position;
            }
            else
            {
                target = postA.position;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
