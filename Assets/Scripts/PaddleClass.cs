using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Paddle", menuName = "Paddles")]
public class PaddleClass : ScriptableObject
{
    //Stats (fields)
    public float speed;
    public float force;
    //Graphics part
    public Sprite sprite;
    public Material fxMaterial;
    public Color color;
    //Stats (Properties)

    public PaddleClass(int speed, int force)
    {
        this.speed = speed;
        this.force = force;
       
    }


}
