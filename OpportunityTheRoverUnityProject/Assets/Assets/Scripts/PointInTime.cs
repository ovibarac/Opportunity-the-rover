using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime
{
    public Vector3 position;
    public Quaternion rotation;

    public PointInTime(Vector3 _position, Quaternion _rotation)//constructor care atribuie pozitia si rotatia
    {
        position = _position;
        rotation = _rotation;

    }
}
