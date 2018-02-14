using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ball : MonoBehaviour {
	bool isStarted;
	Vector3 distance;
    public BallClass[] ballInfo;
    private GamePad paddle;
    public int index;
    public ParticleSystem particle;
    // Use this for initialization
    void Start () {

            paddle = Object.FindObjectOfType<GamePad>();
            isStarted = false;
            distance = transform.position -paddle.transform.position;
            GetSprites();
            ballInfo[index].currentEnergy = 0;
            Debug.Log (distance);
	}
	
	// Update is called once per frame
	void Update () {

                GetSprites();
                GetMaterial();
                SpecialMove();
      
	}
     void FixedUpdate()
    {       //If game hasnt started the ball its parented to the paddle
        if (!isStarted)
        { 
            transform.position = distance + paddle.transform.position;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(Random.RandomRange(0,3f), ballInfo[index].acceleration);
                
            }
        }
       
    }
    void GetSprites()
    {
        GetComponent<SpriteRenderer>().sprite = ballInfo[index].sprite;
    }
    IEnumerator SpecialMoveFootball()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ballInfo[index].currentEnergy == ballInfo[index].energy)
            {
                Time.timeScale = 0.5f;
                paddle.paddlesInfo[index].speed = paddle.paddlesInfo[index].speed * 2;
               yield return new  WaitForSeconds(3f);
                {
                    Time.timeScale = 1f;
                    paddle.paddlesInfo[index].speed = paddle.paddlesInfo[index].speed / 2;
                    ballInfo[index].currentEnergy = 0;
                }

            }
        }
    }
    IEnumerator SpecialMoveFire()   
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ballInfo[index].currentEnergy == ballInfo[index].energy)
            {
                Vector3 transformPaddle = paddle.transform.localScale;
                paddle.transform.localScale = new Vector3(1.5f, 1);
                paddle.paddlesInfo[index].speed = paddle.paddlesInfo[index].speed / 2;
               yield return new WaitForSeconds(5f);
                {
                    paddle.transform.localScale = transformPaddle;
                    paddle.paddlesInfo[index].speed = paddle.paddlesInfo[index].speed * 2;
                }
            }
        }
    }
    void SpecialMove()
    {
        switch (index)
        {
            case 0: StartCoroutine(SpecialMoveFootball());break;
            case 1: StartCoroutine(SpecialMoveFire());break;
            default:
                break;
        }
       

    }
    void GetMaterial()
    {
        particle.gameObject.GetComponent<Renderer>().material = ballInfo[index].fxMaterial;
        var main = particle.main;
        main.startColor = ballInfo[index].color;
    }
}
	

