using UnityEngine;

public class mergiInspreMouse : MonoBehaviour
{
    public Vector2 pos;
    public float speed;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage = 1;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);//misca proiectilul pe dreapta cu panta memorata
        if (!GetComponent<Renderer>().isVisible)//daca iese din ecran proiectilul e distrus
        {
            Destroy(gameObject);
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)//daca a lovit un asteroid proiectilul e distrus
        {
            Destroy(gameObject);
        }
    }
}
