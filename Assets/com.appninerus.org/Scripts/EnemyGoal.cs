using System;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    public static Action OnGoalAction { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        OnGoalAction?.Invoke();
    }
}
