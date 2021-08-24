using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] Sprite HollowHeart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHeartSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = HollowHeart;
    }
}
