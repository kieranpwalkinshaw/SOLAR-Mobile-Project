using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    private void Awake()
    {
        instance = this;
        ScoreText.text = "Score: 0";
        EnergySlider.value = 0;
    }
    public static UIController instance;
    //declare the UI elements
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private Slider HPSlider;
    [SerializeField] private Slider EnergySlider;
    public void UpdateHealthSlider(int current, int max)
    {
        HPSlider.value = current; // Set the current value of the health slider
        HPSlider.maxValue = max; // Set the maximum value of the health slider
    }

    public void UpdateEnergySlider(int current, int max) // Update the energy slider
    {
        EnergySlider.value = current; // Set the current value of the energy slider
        EnergySlider.maxValue = max; // Set the maximum value of the energy slider
    }

    public void UpdateScoreText(int score)
    {
        ScoreText.text = "Score: " + score.ToString(); // Update the score text with the new score
    }

}
