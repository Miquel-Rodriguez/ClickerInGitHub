using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaController : MonoBehaviour
{
    private int numGachaSkins;
    private int numGachaPoweUps;

    [SerializeField] int numTicketsSkins;
    [SerializeField] int numTicketsPowerUps;

    [SerializeField] PowerUps powerUps;

    [SerializeField] private GameObject allSkins;
    private Skin[] skinsLsit;

    [SerializeField] Button buttonGachaSkin;
    [SerializeField] Button buttonGachaPowerUp;

    [SerializeField] GameObject NoTicketsText;

    [SerializeField] private TextMeshProUGUI textTicketsSkin;
    [SerializeField] private TextMeshProUGUI textTicketsPowerUps;
    private void Start()
    {
        SetNumTickets();
        skinsLsit = allSkins.GetComponentsInChildren<Skin>();
        foreach(Skin a in skinsLsit)
        {
            print("skin");
        }
    }

    public int generateNumberRandom()
    {
    
        int num = Random.Range(0, 100);

        if (num >= 0 && num < 71)
        {
            Debug.Log("Objeto común");
            return 0;
        }else if(num > 70 && num < 95)
        {
            Debug.Log("Objeto raro");
            return 1;
        }
        else
        {
            Debug.Log("Objeto legendario");
            return 2;
        }
    }

    public void ChangeStateNoTicket()
    {
        NoTicketsText.SetActive(!NoTicketsText.activeSelf);
    }
    public void ClickGackaSkin()
    {
      
        if (numTicketsSkins <= 0)
        {
            ChangeStateNoTicket();


        }
        else
        {
            numTicketsSkins--;
            numGachaSkins++;
            if (numGachaSkins == 10)
            {
                numGachaSkins = 0;
                skinsLsit[Random.Range(4, 4)].available = true;
            }
            else
            {
                int rarity = generateNumberRandom();

                switch (rarity)
                {
                    case 0:

                        skinsLsit[Random.Range(4, 4)].available = true;

                        break;
                    case 1:

                        skinsLsit[Random.Range(4, 4)].available = true;
                        break;
                    case 2:

                        skinsLsit[Random.Range(4, 4)].available = true;
                        break;
                }
            }
        }
        SetNumTickets();
    }

    private IEnumerator ChangeButtonColor(Button button)
    {
        button.image.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        button.image.color = Color.white;
    }

    public void ClickGachaPowerUP()
    {

        if (numTicketsPowerUps <= 0)
        {

            ChangeStateNoTicket();
        }
        else
        {
            numTicketsPowerUps--;
            int rarity = generateNumberRandom();
            int num;
            switch (rarity)
            {
                case 0:

                    num = Random.Range(1, 2);
                    if (num == 1)
                    {
                        powerUps.numCommonBytesPerClick++;
                    }
                    else powerUps.numCommonInfinityEnergy++;

                    break;
                case 1:

                    num = Random.Range(1, 2);
                    if (num == 1)
                    {
                        powerUps.numRareBytesPerClick++;
                    }
                    else powerUps.numRareInfinityEnergy++;
                    break;
                case 2:
                    num = Random.Range(1, 2);
                    if (num == 1)
                    {
                        powerUps.numEpicBytesPerClick++;
                    }
                    else powerUps.numEpicInfinityEnergy++;

                    break;
            }
        }
        SetNumTickets();
    }

    private void SetNumTickets()
    {
        textTicketsPowerUps.text = numTicketsPowerUps.ToString();
        textTicketsSkin.text = numTicketsSkins.ToString();

    }





}
