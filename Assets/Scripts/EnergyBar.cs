using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{

	[SerializeField] private Slider slider;
	[SerializeField] private Gradient gradient;
	[SerializeField] private Image fill;

	[SerializeField] private float maxEnergy = 100;
	[SerializeField] float currentEnergy;

	[SerializeField] float energyForSecond;
    public float energyCostForClick;
    [SerializeField] private TextMeshProUGUI bitText;
    [SerializeField] private GameObject eventSystem;
	void Start()
	{
		currentEnergy = maxEnergy;
		SetMaxHealth(maxEnergy);
	
	}


	public void ChangeMaxEnergy(float newMaxEnergy)
    {
		slider.maxValue = newMaxEnergy;
		maxEnergy = newMaxEnergy;
		SetMaxHealth(maxEnergy);
		SetHealth(currentEnergy);
	}

 
	private void FixedUpdate()
	{
		if (currentEnergy < maxEnergy)
		{
			currentEnergy += energyForSecond * Time.deltaTime;
			SetHealth(currentEnergy);
		}
	}
	

    public void SetMaxHealth(float energy)
	{
		slider.maxValue = energy;
		slider.value = energy;
		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(float health)
	{
		slider.value = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

	public void DownBar()
	{
        if (currentEnergy - energyCostForClick < 0)
        {

		}
        else
        {
			currentEnergy -= energyCostForClick;
			SetHealth(currentEnergy);
            eventSystem.GetComponent<NumberController>().currentBits += eventSystem.GetComponent<NumberController>().bitPerClick;
            //bitText.text = eventSystem.GetComponent<NumberController>().currentBits + " BYTES";
            bitText.text = BitUtil.StringFormat(eventSystem.GetComponent<NumberController>().currentBits, BitUtil.TextFormat.Long);
        }
		
	}

	public void UpBar(float up)
	{
        if (currentEnergy < maxEnergy)
        {
			currentEnergy += up;
			SetHealth(currentEnergy);
		}

	}

}
