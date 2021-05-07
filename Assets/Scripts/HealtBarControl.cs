using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBarControl : MonoBehaviour
{

	[SerializeField] private int maxHealth = 100;
	[SerializeField] int currentHealth;

	[SerializeField] HealthBar healthBar;

    // Start is called before the first frame update
  

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}
