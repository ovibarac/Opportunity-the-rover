using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnProiectilPiu : MonoBehaviour
{
    public GameObject piuPrefab;
    public float offset;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public AudioSource sursa1;
    public rotate rotire;

    private void Start()
    {
        sursa1 = GetComponent<AudioSource>();//sunetul folosit la "tragere"
    }

    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //calculeaza unghiul inspre care trebuie sa mearga proiectilul pentru a merge inspre mouse

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);//schimba unghiul
        

        if(timeBtwShots <= 0)//daca a trecut timpul de cooldown
        {
            if (Input.GetMouseButton(0))//daca este apasat mouse-ul creeaza un proiectil
            {
                Instantiate(piuPrefab, transform.position, transform.rotation);
                sursa1.Play();//sunet de tragere
                timeBtwShots = startTimeBtwShots;//reinitializeaza timpul curent co cooldown-ul
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;//scade timpul dintre frame-uri
        }
    }
}






