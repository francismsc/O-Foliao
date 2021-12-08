using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barsUI : MonoBehaviour
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



    public void SetMaxAllBars(int alcool, int fun, int social, int energy, int money)
    {
        alcoolSlider.maxValue = alcool;
        alcoolSlider.value = alcool;
        alcoolFill.color = alcoolGradient.Evaluate(1f);

        funSlider.maxValue = fun;
        funSlider.value = fun;
        funFill.color = funGradient.Evaluate(1f);

        socialSlider.maxValue = social;
        socialSlider.value = social;
        socialFill.color = socialGradient.Evaluate(1f);

        energySlider.maxValue = energy;
        energySlider.value = energy;
        energyFill.color = energyGradient.Evaluate(1f);

        text.text = money.ToString();




    }

    public void SetValueAllBars(int alcool, int fun, int social, int energy, int money)
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
}
