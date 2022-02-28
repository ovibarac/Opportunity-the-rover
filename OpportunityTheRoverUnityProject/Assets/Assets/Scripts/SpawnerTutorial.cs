using UnityEngine;

public class SpawnerTutorial : MonoBehaviour
{
    public GameObject mic;
    public GameObject maricel;

    public float timpIntreMici;
    private float timpTrecutMici;

    public float timpIntreMaricei;
    private float timpTrecutMaricei;

    public bool susSauJos;
    public bool stangaSauDreapta;

    float jumDistIntreSpawnere = 6f;

    public float offset;
    bool jumamin = true;
    bool unmin = true;
    bool doimin = true;


    void Start()
    {
        //offset = Random.Range(0f, 5f);
        timpTrecutMici = timpIntreMici;
        timpTrecutMaricei = timpIntreMaricei;
    }

    void Update()
    {

        if (timpTrecutMici <= 0)
        {
            mic.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
            if (susSauJos)
            {
                Instantiate(mic, new Vector2(Random.Range(transform.position.x - jumDistIntreSpawnere, transform.position.x + jumDistIntreSpawnere), transform.position.y), mic.transform.rotation);
            }
            if (stangaSauDreapta)

            {
                Instantiate(mic, new Vector2(transform.position.x, Random.Range(transform.position.y - jumDistIntreSpawnere, transform.position.y + jumDistIntreSpawnere)), mic.transform.rotation);
            }
            timpTrecutMici = timpIntreMici;
        }
        else
        {
            timpTrecutMici -= Time.deltaTime;
        }

        if (timpTrecutMaricei <= 0)
        {
            maricel.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
            if (susSauJos)
            {
                Instantiate(maricel, new Vector2(Random.Range(transform.position.x - jumDistIntreSpawnere, transform.position.x + jumDistIntreSpawnere), transform.position.y), maricel.transform.rotation);
            }
            if (stangaSauDreapta)

            {
                Instantiate(maricel, new Vector2(transform.position.x, Random.Range(transform.position.y - jumDistIntreSpawnere, transform.position.y + jumDistIntreSpawnere)), maricel.transform.rotation);
            }
            timpTrecutMaricei = timpIntreMaricei;
        }
        else
        {
            timpTrecutMaricei -= Time.deltaTime;
        }

        progression();
    }

    void progression()
    {
        if (Time.realtimeSinceStartup >= 30 && jumamin)
        {
            timpIntreMici -= 0.8f;
            timpIntreMaricei -= 0.8f;
            jumamin = false;
        }
        else if (Time.realtimeSinceStartup >= 60 && unmin)
        {
            timpIntreMici -= 0.9f;
            timpIntreMaricei -= 0.9f;
            unmin = false;
        }
        else if (Time.realtimeSinceStartup >= 120 && doimin)
        {
            timpIntreMici -= 1f;
            timpIntreMaricei -= 1f;
            doimin = false;
        }
    }
}
