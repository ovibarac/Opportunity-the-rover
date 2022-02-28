using UnityEngine;

public class rotate : MonoBehaviour
{
    public float turnSpeed = 200f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A)){//daca tasta 'A' e apasata se roteste in sens trigonometric
            transform.Rotate(0, 0,turnSpeed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.D)){//daca tasta 'D' e apasata se roteste in sensul acelor de ceasornic
            transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }

        //rotatia se face in jurul unui punct de pivot plasat in centrul planetei
    }
}
