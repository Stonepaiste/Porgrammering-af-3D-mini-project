using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI HealthLefttext;
    public TextMeshProUGUI ShotsLefttext;

    private int score = 0;
    private int HealthLeft = 100;
    public int shotsLeft = 100;

    void Start()
    {
        UpdateHUD();
    }

    public void AddScore(int amount)
    {
        score += amount; // Add score
        if (score >= 1000) // Add 10 shots for every 1000 points
        {
            //score -= 1000;
            AddShots(10);
        }
        UpdateHUD();
    }

    private void AddShots(int amount)
    {
        shotsLeft += amount;
        UpdateHUD();
    }

    public void UpdateLives(int helmet, int weapon)
    {
        HealthLeft = helmet;
        shotsLeft = weapon;
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        scoretext.text = score.ToString("D8"); // Format to 8 digits
        HealthLefttext.text = HealthLeft.ToString();
        ShotsLefttext.text = shotsLeft.ToString();
    }

    public void DecreaseShotsLeft()
    {
        if (shotsLeft > 0)
        {
            shotsLeft--;
            UpdateHUD();
        }
    }

    public void DecreaseHealth()
    {
        if (HealthLeft > 0)
        {
            HealthLeft -= 10;
            UpdateHUD();
        }
    }
}