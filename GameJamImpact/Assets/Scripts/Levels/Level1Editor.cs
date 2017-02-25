using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level1))]
public class Level1Editor : Editor {

    public void OnSceneGUI()
    {
        Level1 level = (Level1) target;
        Bounds bounds = level.obstacle.GetComponent<SpriteRenderer>().sprite.bounds;
        Vector2 obstacleSize = bounds.size;
        Debug.Log(obstacleSize);

        Handles.DrawSolidRectangleWithOutline(new Rect(level.firstObstaclePosition, obstacleSize), Color.green, Color.black);
        // Handles.DrawArrow(0, )
    }
}
