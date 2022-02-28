using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float score = 0f;
    public float scorTimp = 0f;
    public Text scoreText;
    public TMP_Text text3d;
    float osecunda = 0f;

    private void Update()
    {
        osecunda += Time.deltaTime;//se adauga mereu intervalul de timp dintre 2 frame-uri
        if(osecunda >= 1f)//cand trece o secunda scorul creste
        {
            scorTimp++;
            osecunda = 0f;//se resteaza pentru a se ajunge din nou la o secunda
        }
        text3d.text = scorTimp.ToString();//modifica textul efectiv din joc, care arata scorul
    }
}
