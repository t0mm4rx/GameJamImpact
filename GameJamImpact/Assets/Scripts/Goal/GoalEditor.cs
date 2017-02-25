using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (Goal))]
public class GoalEditor : Editor {

    public void OnSceneGUI()
    {
        Goal g = (Goal)target;
        Handles.color = Color.green;
        Handles.CircleCap(0, g.transform.TransformPoint(g.victoryLocalPosition), g.transform.rotation, 0.2f);
    }

}
