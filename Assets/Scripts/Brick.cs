using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Brick : MonoBehaviour {

	static int numberBricks=0;
    public Sprite[] sprites;
    private ball ball;
	int numberOfHits;
    // Use this for initialization

    void Start () {
		numberOfHits = 0;
        numberBricks++;
        ball = Object.FindObjectOfType<ball>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(numberBricks);
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
        Debug.Log(ball.ballInfo[ball.index].currentEnergy + " " + ball.ballInfo[ball.index].energy);

        int MaxNumberOfHits = sprites.Length + 1;
        numberOfHits++;
        //Debug.Log(name + "Number of hits" + numberOfHits + "Max number of hits"+MaxNumberOfHits);
        if (numberOfHits >= MaxNumberOfHits)
        {
            if (ball.ballInfo[ball.index].currentEnergy < ball.ballInfo[ball.index].energy)
            {
                ball.ballInfo[ball.index].currentEnergy++;
            }
            numberBricks--;
            Destroy(gameObject);
            
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[numberOfHits - 1];
        }
        if (numberBricks == 0)
        {
            print("You win!!!");
            SceneManager.LoadScene(0);
        }
	}
}
