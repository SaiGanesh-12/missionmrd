using UnityEngine;

public class cellmove : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    private float speed;
    private Vector3 direction;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        direction = new Vector3(-1, Random.Range(-1f, 1f), 0).normalized;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        //if (!IsVisibleLeft())
        //{
        //    Destroy(gameObject); 
        //}
        Destroy(gameObject, 5f);
        if (transform.position.y > 0.25f)
        {
            direction.y = -Mathf.Abs(direction.y); 
        }
        else if (transform.position.y < -0.15f)
        {
            direction.y = Mathf.Abs(direction.y); 
        }
    }

    bool IsVisibleLeft()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x > 0;
    }
}