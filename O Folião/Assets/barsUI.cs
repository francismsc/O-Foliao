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
    public Slider hungerSlider;
    [SerializeField]
    public Gradient hungerGradient;
    [SerializeField]
    public Image hungerFill;

    [SerializeField]
    public Slider socialSlider;
    [SerializeField]
    public Gradient socialGradient;
    [SerializeField]
    public Image socialFill;



    public void SetMaxAllBars(int alcool, int fun, int hunger, int social)
    {
        alcoolSlider.maxValue = alcool;
        alcoolSlider.value = alcool;
        alcoolFill.color = alcoolGradient.Evaluate(1f);

        funSlider.maxValue = fun;
        funSlider.value = fun;
        funFill.color = funGradient.Evaluate(1f);

        hungerSlider.maxValue = hunger;
        hungerSlider.value = hunger;
        hungerFill.color = hungerGradient.Evaluate(1f);

        socialSlider.maxValue = social;
        socialSlider.value = social;
        socialFill.color = socialGradient.Evaluate(1f);

    }

    public void SetValueAllBars(int alcool, int fun, int hunger, int social)
    {
        alcoolSlider.value = alcool;
        alcoolFill.color = alcoolGradient.Evaluate(alcoolSlider.value);

        funSlider.value = fun;
        funFill.color = funGradient.Evaluate(funSlider.value);

        hungerSlider.value = hunger;
        hungerFill.color = hungerGradient.Evaluate(hungerSlider.value);

        socialSlider.value = social;
        socialFill.color = socialGradient.Evaluate(socialSlider.value);
    }
}
