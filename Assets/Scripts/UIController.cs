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
    //declare pricate variables
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private Slider HPSlider;
    [SerializeField] private Slider EnergySlider;
    public void UpdateHealthSlider(int current, int max)
    {
        HPSlider.value = current; // set the slider display to the current health value
        HPSlider.maxValue = max; // set the slider max value to the max health value
    }

    public void UpdateEnergySlider(int current, int max)
    {
        EnergySlider.value = current; // set the slider display to the current energy value
        EnergySlider.maxValue = max; // set the slider max value to the max energy value
    }

    public void UpdateScoreText(int score)
    {
        ScoreText.text = "Score: " + score.ToString(); // set the score text to the current score value
    }

}
