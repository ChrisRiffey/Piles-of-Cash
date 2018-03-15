using UnityEngine;
using System.Collections;
using UnityEditor;
using CashSpawning; 

[CustomEditor(typeof(CashPile))]
public class CashPileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CashPile myScript = (CashPile)target;
        if (GUILayout.Button("Update max value"))
        {
            myScript.updateMaxValue();
        }
    }


}