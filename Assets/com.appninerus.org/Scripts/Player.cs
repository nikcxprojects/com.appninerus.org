using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action OnPlayerAction { get; set; }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(mPos.x < -0.607f || mPos.x > 0.607f)
            {
                return;
            }

            transform.position = new Vector2(mPos.x, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayerAction?.Invoke();
        collision.rigidbody.AddForce(Vector2.up * 10.0f, ForceMode2D.Impulse);
    }
}
