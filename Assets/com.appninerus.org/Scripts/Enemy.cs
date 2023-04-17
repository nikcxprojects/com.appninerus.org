using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float nextTime;
    private const float fireRate = 0.5f;

    private const float force = 10.0f;

    private Rigidbody2D BallPrefab { get; set; }

    private void Awake()
    {
        BallPrefab = Resources.Load<Rigidbody2D>("ball");
    }

    private void Update()
    {
        if(Time.time > nextTime)
        {
            nextTime = Time.time + fireRate;

            var ball = Instantiate(BallPrefab, transform.parent);
            ball.transform.position = transform.position;

            var target = new Vector2(Random.Range(-0.6f, 0.6f), -3.0f);
            var direction = (target - (Vector2)transform.position).normalized;

            ball.AddForce(direction * force, ForceMode2D.Impulse);
            Destroy(ball.gameObject, 2.0f);
        }
    }
}
