using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int speed, numberOfHearts;
    [SerializeField] GameObject heartObject;
    float minX, maxX;
    [SerializeField] bool isGoingRight;
    GameObject[] ArrayOfHearts;
    float SpriteSizeInX, SpriteSizeInY;
    [SerializeField] bool col = true;
   
    // Start is called before the first frame update
    void Start()
    {
        col = true;
        Vector2 RightCorner = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 LeftCorner = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        SpriteSizeInX = GetComponent<SpriteRenderer>().bounds.size.x;
        SpriteSizeInY = GetComponent<SpriteRenderer>().bounds.size.y;

        maxX = RightCorner.x - SpriteSizeInX / 2;
        minX = LeftCorner.x + SpriteSizeInX / 2;

        CreateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            damageType();
        }
        if (isGoingRight)
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

    void CreateHearts()
    {
        float firstPos = -0.5f * numberOfHearts/4.5f ;
        ArrayOfHearts = new GameObject[numberOfHearts];
        for (int i = 0; i < numberOfHearts; i++)
        {
            firstPos += 0.2f;
            GameObject newHeart = Instantiate(heartObject, transform.position + new Vector3((firstPos), SpriteSizeInY / 1.5f, 0), transform.rotation, transform) as GameObject;
            ArrayOfHearts[i] = newHeart;
        }
    }

    void damageType()
    {
        if (!col)
        {
            col = true;
        }
        else
        {
            col = false;
        }
    }
    public void ReceiveDamage()
    {
        if(col)
        {
            if (numberOfHearts > 1)
            {

                Heart CurrentHeartReference = ArrayOfHearts[(numberOfHearts - 1)].GetComponent<Heart>();

                if (CurrentHeartReference != null)
                {
                    CurrentHeartReference.ChangeHeartSprite();
                    numberOfHearts -= 1;

                }
            }
            else
            {
                Destroy(this.gameObject);
            }

        }
        else
        {
            for(int i =0; i<2;i++)
            {
                if (numberOfHearts > 1)
                {

                    Heart CurrentHeartReference = ArrayOfHearts[(numberOfHearts - 1)].GetComponent<Heart>();

                    if (CurrentHeartReference != null)
                    {
                        CurrentHeartReference.ChangeHeartSprite();
                        numberOfHearts -= 1;

                    }
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
       
    }


}
