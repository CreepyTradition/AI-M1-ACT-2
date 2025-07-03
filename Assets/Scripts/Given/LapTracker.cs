using UnityEngine;
using UnityEngine.UI;

public class LapTracker : MonoBehaviour
{
    public int totalLaps = 3;
    public Text lapText;
    public Text timeText;
    public Text finalTimeText;

    private int currentLap = 0;
    private float lapStartTime;
    private bool raceFinished = false;

    void Start()
    {
        lapStartTime = Time.time;
        UpdateUI();
        finalTimeText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (raceFinished) return;

        float currentLapTime = Time.time - lapStartTime;
        timeText.text = "Lap Time: " + currentLapTime.ToString("F2") + "s";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (raceFinished) return;

        if (other.CompareTag("Car"))
        {
            currentLap++;

            if (currentLap >= totalLaps)
            {
                raceFinished = true;
                float finalTime = Time.time - lapStartTime;
                finalTimeText.text = "Race Finished!\nFinal Time: " + finalTime.ToString("F2") + "s";
                finalTimeText.gameObject.SetActive(true);
            }
            else
            {
                lapStartTime = Time.time;
                UpdateUI();
            }
        }
    }

    private void UpdateUI()
    {
        lapText.text = "Lap: " + currentLap + " / " + totalLaps;
    }
}
