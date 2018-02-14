using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GameManager))]
public class BallSkinEditor:Editor  {


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameManager gameManager = (GameManager)target;
        if(GUILayout.Button("Press me!!!"))
        {
            Debug.Log("Hello World ");
          

        }
       
    }

}
