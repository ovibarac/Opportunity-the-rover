using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
