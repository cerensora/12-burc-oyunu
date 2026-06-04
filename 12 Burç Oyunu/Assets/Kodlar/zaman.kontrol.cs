using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Image timeBar;
    public float maxTime = 60f;
    private float currentTime;

    void Start()
    {
        currentTime = maxTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeBar.fillAmount = currentTime / maxTime;
        }
        else
        {
            Debug.Log("Süre Doldu! Kaybettin.");
        }
    }

    public void ResetTimer()
    {
        currentTime = maxTime;
    }
}