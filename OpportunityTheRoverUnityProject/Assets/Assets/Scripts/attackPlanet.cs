using UnityEngine;

public class attackPlanet : MonoBehaviour
{
    public float razaPlaneta = 0.45f;
    public float speed = 100f;
    Vector2 target;
    public float distance = 0.05f;
    public LayerMask whatIsSolid;
    public float health = 10f;

    public void Start()
    {
        target = new Vector2(Random.Range(-razaPlaneta, razaPlaneta), Random.Range(-razaPlaneta, razaPlaneta));//punct random pe planeta
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);//asteroidul se misca cu o anumita viteza inspre un punct random de pe planeta
    }

}
