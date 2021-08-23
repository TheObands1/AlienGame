using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject bullet;
    [SerializeField] float nextFire;
    float minX, maxX, minY, maxY, SpriteSizeInX, SpriteSizeInY, canFire;

    // Start is called before the first frame update
    void Start()
    {
        //in here we are finding the camera inside the scene, which is probably not the best thing because
        //of all the things that can be in a scene. However, this is a little project, 
        //thus it is okay to use it
        Vector2 UpperRightCorner = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        SpriteSizeInX = GetComponent<SpriteRenderer>().bounds.size.x;
        SpriteSizeInY = GetComponent<SpriteRenderer>().bounds.size.y;

        maxX = UpperRightCorner.x - SpriteSizeInX/2;
        maxY = UpperRightCorner.y - SpriteSizeInY/2;

        Vector2 LowerLeftCorner = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        minX = LowerLeftCorner.x + SpriteSizeInX/2;
        minY = LowerLeftCorner.y + 5;
        Debug.Log(minY.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= canFire)
        {
            canFire = Time.time + nextFire;
            Fire();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector2((moveHorizontal * Time.deltaTime * speed), (moveVertical * Time.deltaTime * speed)));

        float newPositionInX = Mathf.Clamp(transform.position.x, minX, maxX);
        float newPositionInY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector2(newPositionInX, newPositionInY);
    }

    void Fire()
    {
       Instantiate(bullet, transform.position - new Vector3(0, SpriteSizeInY/2, 0), transform.rotation);
    }
}
