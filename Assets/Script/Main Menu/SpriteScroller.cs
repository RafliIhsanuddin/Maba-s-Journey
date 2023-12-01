using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{

    [SerializeField] Vector2 MoveSpeed;

    Vector2 offset;
    Material material;



    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = MoveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
