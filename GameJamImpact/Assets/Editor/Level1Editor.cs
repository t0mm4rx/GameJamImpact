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

        Handles.DrawSolidRectangleWithOutline(new Rect(level.firstObstaclePosition, obstacleSize), Color.green, Color.black);

        Handles.color = Color.white;
        Vector3 arrowOrigin = (Vector3) level.firstObstaclePosition + new Vector3(bounds.max.x, bounds.center.y, level.obstacle.transform.position.z);
        Vector3 arrowMiddle = arrowOrigin + new Vector3(level.minXObstacleRepop, 0.0f, 0.0f);
        Handles.DrawLine(arrowOrigin, arrowMiddle);

        Handles.color = Color.green;
        Vector3 arrowEnd = arrowMiddle + new Vector3(level.rangeXObstacleRepop, 0.0f, 0.0f);
        Handles.DrawLine(arrowMiddle, arrowEnd);
    }
}
