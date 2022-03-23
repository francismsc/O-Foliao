using UnityEngine;
using UnityEngine.UI;

public class BarsUI : MonoBehaviour
{
    [SerializeField]
    private Slider alcoolSlider;
    [SerializeField]
    private Gradient alcoolGradient;
    [SerializeField]
    private Image alcoolFill;

    [SerializeField]
    private Slider funSlider;
    [SerializeField]
    private Gradient funGradient;
    [SerializeField]
    private Image funFill;

    [SerializeField]
    private Slider socialSlider;
    [SerializeField]
    private Gradient socialGradient;
    [SerializeField]
    private Image socialFill;

    [SerializeField]
    private Slider energySlider;
    [SerializeField]
    private Gradient energyGradient;
    [SerializeField]
    private Image energyFill;
    [SerializeField]
    private Text text;



    public void SetMaxAllBars(int maxAlcool, int maxFun, int maxSocial,
                              int maxEnergy, int money)
    {
        alcoolSlider.maxValue = maxAlcool;

        funSlider.maxValue = maxFun;

        socialSlider.maxValue = maxSocial;

        energySlider.maxValue = maxEnergy;

        SetValueAllBars();
    }

    public void SetValueAllBars(int alcool = 0, int fun = 50, int social = 50, 
                                int energy = 100, int money = 100)
    {
        alcoolSlider.value = alcool;
        alcoolFill.color = alcoolGradient.Evaluate(alcoolSlider.value);

        funSlider.value = fun;
        funFill.color = funGradient.Evaluate(funSlider.value);

        socialSlider.value = social;
        socialFill.color = socialGradient.Evaluate(socialSlider.value);

        energySlider.value = energy;
        energyFill.color = energyGradient.Evaluate(energySlider.value);

        text.text = money.ToString() + "€";
    }



}
