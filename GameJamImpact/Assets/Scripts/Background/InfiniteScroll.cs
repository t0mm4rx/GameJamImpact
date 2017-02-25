using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroll : MonoBehaviour {

    [SerializeField]
    Transform frontBackground;

    [SerializeField]
    Transform behindBackground;

    void switchBackgrounds()
    {
        Vector3 distance = (Vector2) (frontBackground.position - behindBackground.position);
        behindBackground.position = frontBackground.position;
        frontBackground.position = frontBackground.position + distance;
    }

    public void checkIfFarerThanFrontBackground(Vector2 pos)
    {
        if(pos.x > frontBackground.position.x)
        {
            switchBackgrounds();
        }
    }
}
