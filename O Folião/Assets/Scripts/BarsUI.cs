using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsUI : MonoBehaviour
{
    [SerializeField]
    public Slider alcoolSlider;
    [SerializeField]
    public Gradient alcoolGradient;
    [SerializeField]
    public Image alcoolFill;

    [SerializeField]
    public Slider funSlider;
    [SerializeField]
    public Gradient funGradient;
    [SerializeField]
    public Image funFill;

    [SerializeField]
    public Slider socialSlider;
    [SerializeField]
    public Gradient socialGradient;
    [SerializeField]
    public Image socialFill;

    [SerializeField]
    public Slider energySlider;
    [SerializeField]
    public Gradient energyGradient;
    [SerializeField]
    public Image energyFill;

    public Text text;



    public void SetMaxAllBars(int maxAlcool, int maxFun, int maxSocial, int maxEnergy, int money)
    {
        alcoolSlider.maxValue = maxAlcool;

        funSlider.maxValue = maxFun;

        socialSlider.maxValue = maxSocial;

        energySlider.maxValue = maxEnergy;

        SetValueAllBars();
    }

    public void SetValueAllBars(int alcool = 0, int fun = 50, int social = 50, int energy = 100, int money = 30)
    {
        alcoolSlider.value = alcool;
        alcoolFill.color = alcoolGradient.Evaluate(alcoolSlider.value);

        funSlider.value = fun;
        funFill.color = funGradient.Evaluate(funSlider.value);

        socialSlider.value = social;
        socialFill.color = socialGradient.Evaluate(socialSlider.value);

        energySlider.value = energy;
        energyFill.color = energyGradient.Evaluate(energySlider.value);

        text.text = money.ToString();
    }

    public void TimeUi(int hours, int minutes)
    {

    }

}
