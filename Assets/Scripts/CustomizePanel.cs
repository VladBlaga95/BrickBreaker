using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizePanel : MonoBehaviour {
    bool isNotActive;
    public KeyCode setInterfaceButton;
    public GameObject Interface;
    private ball ball;
    private GamePad gamePad;
    private Sprite ballSkin;
    private Sprite paddleSkin;
    public Image SkinPaddleUI;
    public Image SkinBallUI;
    public Slider accelerationSlider;
    public Slider energySlider;
    public Slider forceSlider;
    public Slider speedSlider;
    public Slider CurrentEnergy;
    public Text paddleName;
    public Text ballName;
    private int tempIndex;
	// Use this for initialization
	void Start () {
        isNotActive = false;
        ball = FindObjectOfType<ball>();
        gamePad = FindObjectOfType<GamePad>();
        tempIndex = gamePad.index;
    }
	
	// Update is called once per frame
	void Update () {
        //If button its pressed and the interface is not active
        CurrentEnergy.value = ball.ballInfo[ball.index].currentEnergy;
        if (Input.GetKeyDown(setInterfaceButton) & isNotActive==false)
        {
            
            isNotActive = true;
            Interface.SetActive(isNotActive);
            CurrentEnergy.gameObject.SetActive(!isNotActive);
            Debug.Log("Interface Activated");
            Time.timeScale = 0f;
           

        }
        else if (Input.GetKeyDown(setInterfaceButton) & isNotActive==true)
        {
           
            isNotActive = false;
            Interface.SetActive(isNotActive);
            CurrentEnergy.gameObject.SetActive(!isNotActive);
            Debug.Log("Interface Desactivated");
            Time.timeScale = 1f;
          
        }
        if (isNotActive)
        {
            ChangeSprites();
            UpdateStats();
        }
       
    }
  void ChangeSprites()
    {if(Input.GetKeyDown(KeyCode.K))
        {
            ball.index=tempIndex;
            gamePad.index=tempIndex;
            isNotActive = false;
            Interface.SetActive(isNotActive);
            CurrentEnergy.gameObject.SetActive(!isNotActive);
            Debug.Log("Interface Desactivated");
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("DownArrow pressed" + tempIndex);
            if (tempIndex> 0)
            {
                tempIndex--;
                
            }
           else if (tempIndex == 0)
                tempIndex = ball.ballInfo.Length - 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
             if (tempIndex < ball.ballInfo.Length-1)
            {
                tempIndex++;
            }
           else if (tempIndex == ball.ballInfo.Length - 1)
                tempIndex = 0;
        }
        
        UpdateSprites();
    }
    void UpdateSprites()
    {
        ballSkin = ball.ballInfo[tempIndex].sprite;
        paddleSkin = gamePad.paddlesInfo[tempIndex].sprite;
        SkinBallUI.sprite = ballSkin;
        SkinPaddleUI.sprite = paddleSkin ;
    }
    void UpdateStats()
    {
        paddleName.text = gamePad.paddlesInfo[tempIndex].name;
        ballName.text = ball.ballInfo[tempIndex].name;
        
        CurrentEnergy.maxValue = ball.ballInfo[tempIndex].energy;
        accelerationSlider.value = ball.ballInfo[tempIndex].acceleration;
        energySlider.value = ball.ballInfo[tempIndex].energy;
        speedSlider.value = gamePad.paddlesInfo[tempIndex].speed;
        forceSlider.value = gamePad.paddlesInfo[tempIndex].force;
    }
}
