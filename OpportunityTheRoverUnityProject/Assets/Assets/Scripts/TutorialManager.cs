using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popupIndex;

    public GameObject mic;
    public GameObject maricel;
    public GameObject player;
    public Quaternion rot;

    bool micSpwn = true;
    bool mareSpwn = true;
    void Start()
    {
            rot = player.transform.rotation;
    }

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if(i == popupIndex)
            {
                popUps[i].SetActive(true);//activeaza pop-up-ul curent
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popupIndex == 0)
        {
            //daca playerul si-a schimbat pozitia trece la urmatorul pop-up
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                popupIndex++;
        }else if(popupIndex == 1)
        {
            //daca playerul trage un proiectil trece la urmatorul pop-up
            if (Input.GetMouseButtonDown(0))
            {
                popupIndex++;
            }
        }else if(popupIndex == 2)
        {
            if(Input.GetMouseButtonUp(1))
                popupIndex++;
        }else if(popupIndex == 3 && mareSpwn && micSpwn)
        {
            //creeaza doi asteroizi pentru a invata jucatorul sa traga in ei
            mic.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
            Instantiate(mic, new Vector2(-3f, 4f), mic.transform.rotation);
            maricel.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
            Instantiate(maricel, new Vector2(3f, -4f), mic.transform.rotation);
            mareSpwn = false;
            micSpwn = false;
            Invoke("nextScene", 15f);
        }
    }

    void nextScene()
    {
        SceneManager.LoadScene(1);
    }
}
