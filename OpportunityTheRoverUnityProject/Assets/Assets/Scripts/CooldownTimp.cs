using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTimp : MonoBehaviour
{
    public float cooldownTime = 10f;
    private float nextRewindTime = 10f;
    public bool canRewind = false;

    private void Update()
    {
        if(Time.time > nextRewindTime)
        {
            canRewind = true;
            if (Input.GetKey(KeyCode.Space))
            {
                canRewind = false;
                nextRewindTime = Time.time + cooldownTime;
            }
        }
    }
}
