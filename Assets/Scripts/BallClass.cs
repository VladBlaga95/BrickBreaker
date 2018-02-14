using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Ball",menuName ="Balls")]
public class BallClass:ScriptableObject {

    //Stats (fields)
    public int acceleration;
    public int energy;
    public int currentEnergy;
    //Graphics part
    public Sprite sprite;
    public Material fxMaterial;
    public Color color;
    //Stats (Properties)

    public BallClass(int acceleration,int energy)
    {
        this.acceleration = acceleration;
        this.energy = energy;
    }


}
