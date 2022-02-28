using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obstacle : MonoBehaviour
{
    public GameObject particle;
    public GameObject scorOb;

    private Score scor;

    public int health = 50;
    //public AudioSource sursa;
    //private cameraShake shake;

    private SpriteRenderer sprite;

    public AudioSource s;

    public float flashLength = 0.0001f;
    float flashCounter;
    bool isFlashing = false;
    public bool gameOver = false;

    private void Start()
    {
        scor = scorOb.GetComponent<Score>();
        sprite = GetComponent<SpriteRenderer>();
        s = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)//functia este activata daca asteroidul intalneste alt obiect de tip "Collider"
    {
        mergiInspreMouse piu = collision.GetComponent<mergiInspreMouse>();
        if(piu != null && GetComponent<Renderer>().isVisible)//verifica daca asteroidul este vizibil pe ecran, neputand fi distrus in afara acestuia
        {
            takeDamage(10);//la impact cu un proiectil se apeleaza funcita takeDamage(), rezultand in scaderea vietii asteroidului
        }
        if(collision.tag == "Environment")//daca impactul asteroidului este cu planeta si nu cu un proiectil, jocul se termina
        {
            Destroy(gameObject);
            Debug.Log("game over");
            gameOver = true;
            GameOver();//functia GameOver() reia Game Loop-ul, reincepand jocul
        }
        if(collision.tag == "Player")//daca impactul este cu playerul asteroidul va fi distrus
        {
            Invoke("die", Time.deltaTime);
        }

    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (isFlashing)
        {
            if(flashCounter > 0f)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
            }
            else{
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
                isFlashing = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void takeDamage(int damage)
    {
        s.Play();
        health -= damage;
        if (!isFlashing)
        {
            isFlashing = true;
            flashCounter = flashLength;
        }
        if (health <= 0)
        {
            Invoke("die", Time.deltaTime);
        }
    }

    void die()
    {
        //sursa.Play();
        //shake.camShake();
        Instantiate(particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
