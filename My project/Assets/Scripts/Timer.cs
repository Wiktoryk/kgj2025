using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public float timeMax;
    void Start()
    {
        timeLeft = timeMax;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log(timeLeft);
        }
        else
        {
            timeLeft = 0;
        }
    }
}
