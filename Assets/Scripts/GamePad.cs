using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad : MonoBehaviour
{
    public float clamp;
    public PaddleClass[] paddlesInfo;
    public int index;
    float posInit;
    public ParticleSystem particle;

    // Use this for initialization
    void Start()
    {
        posInit = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        GetMaterial();
        GetSprites();
        Move();
    }
    void Move()
    {
        float xPos = transform.position.x;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 newPos = new Vector3(Mathf.Clamp((-paddlesInfo[index].speed + xPos), -clamp, clamp), transform.position.y, transform.position.z);
            transform.position = newPos;
            //Debug.Log (newPos.x);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 newPos = new Vector3(Mathf.Clamp((paddlesInfo[index].speed + xPos), -clamp, clamp), transform.position.y, transform.position.z);
            transform.position = newPos;
            //Debug.Log (newPos.x);
        }
    }
    void GetSprites()
    {
        GetComponent<SpriteRenderer>().sprite = paddlesInfo[index].sprite;
    }
    void GetMaterial()
    {
        particle.gameObject.GetComponent<Renderer>().material = paddlesInfo[index].fxMaterial;
        var main = particle.main;
        main.startColor = paddlesInfo[index].color;
    }
}