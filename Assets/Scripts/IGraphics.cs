using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGraphics  {

    GameObject Particles { get; set; }
    Sprite Skin { get; set; }
    void GetSprite();
    void GetParticle();
}
