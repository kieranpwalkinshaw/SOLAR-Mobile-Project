using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    private void Awake()
    {
        instance = this;
        ScoreText.text = "Score: 0";
    }
    public static UIController instance;

    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private Slider HPSlider;
    public void UpdateHealthSlider(int current, int max)
    {
        HPSlider.value = current;
        HPSlider.maxValue = max;
    }

    public void UpdateScoreText(int score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }

}
