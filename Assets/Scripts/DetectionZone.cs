using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public ShadowCreature enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.StartChasing();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.StopChasing();
        }
    }
}