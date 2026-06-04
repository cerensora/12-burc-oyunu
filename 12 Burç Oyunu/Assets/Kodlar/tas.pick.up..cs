using UnityEngine;

public class StonePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Taþ bulundu! Süre 60 saniyeye yenilendi.");

            TimerController timer = FindAnyObjectByType < TimerController>();
            if (timer != null)
            {
                timer.ResetTimer();
            }

            Destroy(gameObject);
        }
    }
}