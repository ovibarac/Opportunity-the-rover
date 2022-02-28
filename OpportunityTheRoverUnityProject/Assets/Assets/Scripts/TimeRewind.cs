using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewind : MonoBehaviour
{
    public bool isRewinding = false;
    public float secundeRewind = 1f;

    public GameObject cooldown;

    private CooldownTimp cooldownScript;

    List<PointInTime> pointsInTime;

    bool rwd;

    private void Start()
    {
        pointsInTime = new List<PointInTime>();
        cooldownScript = cooldown.GetComponent<CooldownTimp>();
    }

    private void FixedUpdate() {
        if (isRewinding){
                rewind();
        }else{
            record();
        }
    }

    void record() {
        if (pointsInTime.Count > Mathf.Round(secundeRewind / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);//sterge ultima pozitie din lista
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));//adauga noua pozitie in varful listei
    }

    void rewind() {
        for(int i = 0; i < 3; i++)
        {
            if (pointsInTime.Count > 0)
            {
                PointInTime pointInTime = pointsInTime[0];//atribuie proiectilului ultmul "punct in timp"
                transform.position = pointInTime.position;
                transform.rotation = pointInTime.rotation;
                pointsInTime.RemoveAt(0);//sterge obiectul folosit din lista
            }
            else
            {
                stopRewind();
            }
        }
    }

    private void Update()
    {

            if (Input.GetMouseButtonDown(1))//la apasarea click dreapta proiectilele se intorc in timp
            {
                startRewind();
            }
            if (Input.GetMouseButtonUp(1))//la ridicarea click dreapta proiectilele isi continua drumul
            {
                stopRewind();
            }
    }

    public void startRewind(){
            isRewinding = true;
    }

    public void stopRewind(){
        isRewinding = false;
    }
}
