using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int speed;
    float minX, maxX;
    [SerializeField] bool isGoingRight;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 RightCorner = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 LeftCorner = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        float SpriteSizeInX = GetComponent<SpriteRenderer>().bounds.size.x;

        maxX = RightCorner.x - SpriteSizeInX / 2;
        minX = LeftCorner.x + SpriteSizeInX / 2;

    }

    // Update is called once per frame
    void Update()
    {
        if(isGoingRight)
        {
            transform.Translate(new Vector2((Time.deltaTime * speed), 0));
        }
        else
        {
            transform.Translate(new Vector2(-(Time.deltaTime * speed), 0));
        }  

        if(transform.position.x >= maxX)
        {
            isGoingRight = false;
        }
        else if(transform.position.x <= minX)
        {
            isGoingRight = true;
        }
    }
}
