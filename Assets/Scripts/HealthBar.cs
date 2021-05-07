using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	[SerializeField] private Slider slider;
	[SerializeField] private Gradient gradient;
	[SerializeField] private Image fill;

	[SerializeField] private float maxEnergy = 100;
	[SerializeField] float currentEnergy;

	private HealthBar energyBar;
	[SerializeField] float energyForSecond;
	void Start()
	{

		energyBar = gameObject.GetComponent<HealthBar>();

		currentEnergy = maxEnergy;
		energyBar.SetMaxHealth(maxEnergy);

	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			DownBar(20);
		}
		if (Input.GetKey("2"))
		{
			UpBar(1);
		}
	}

	public void ChangeMaxEnergy(float newMaxEnergy)
    {
		slider.maxValue = newMaxEnergy;
		maxEnergy = newMaxEnergy;
		energyBar.SetMaxHealth(maxEnergy);
		energyBar.SetHealth(currentEnergy);
	}
 
	private void FixedUpdate()
	{
		if (currentEnergy < maxEnergy)
		{
			currentEnergy += energyForSecond * Time.deltaTime;
			energyBar.SetHealth(currentEnergy);
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

	void DownBar(float down)
	{
        if (currentEnergy-down <= 0)
        {
			currentEnergy = 0;
			energyBar.SetHealth(currentEnergy);
		}
        else
        {
			currentEnergy -= down;
			energyBar.SetHealth(currentEnergy);
		}
	}

	void UpBar(float up)
	{
        if (currentEnergy < maxEnergy)
        {
			currentEnergy += up;
			energyBar.SetHealth(currentEnergy);
		}

	}

}
