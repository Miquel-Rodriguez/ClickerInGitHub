using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaController : MonoBehaviour
{
    private int numGachaSkins;
    private int numGachaPoweUps;

    public int numTicketsSkins;
    public int numTicketsPowerUps;

    [SerializeField] PowerUps powerUps;

    [SerializeField] private GameObject allSkins;
    private Skin[] skinsLsit;

    [SerializeField] Button buttonGachaSkin;
    [SerializeField] Button buttonGachaPowerUp;

    [SerializeField] GameObject NoTicketsText;

    [SerializeField] private TextMeshProUGUI textTicketsSkin;
    [SerializeField] private TextMeshProUGUI textTicketsPowerUps;

    [Header("Game Objects of animations")]
    [SerializeField] private GameObject containerAnimationGacha;

    [SerializeField] private GameObject shakeGameObject;
    private Animator animatorShake;

    [SerializeField] private GameObject fallBallGameObject;
    private Animator fallBallAnimator;

    [SerializeField] private GameObject containerRewardAnimation;
    [SerializeField] private Button buttonGoBackReward;

    [SerializeField] private Animator topBall;
    [SerializeField] private Animator botBall;
    [SerializeField] private Image rewardSprite;

    [SerializeField] private GameObject buttonToStartAnimation;

    [SerializeField] private GameObject buttonSkip;

    private bool stop;

    [Header("Sprites Power Ups")]
    [SerializeField] private Sprite[] listPowerUpSprites;
    private int rarity;

    [SerializeField] private AudioManager audioManager;



    private void PreapreAndWait()
    {
        audioManager.SetVolume("Shake", 1);
        stop = false;
        buttonSkip.SetActive(true);
        containerAnimationGacha.SetActive(true);
        buttonToStartAnimation.SetActive(true);
        shakeGameObject.SetActive(true);
        fallBallGameObject.SetActive(false);
        containerRewardAnimation.SetActive(false);
        animatorShake.speed = 0;
     
    }

    public void RoutineWrap()
    {
        audioManager.Play("ClickClack");
        buttonToStartAnimation.SetActive(false);
        StartCoroutine(StartGachaAnimation());
    }

    private IEnumerator StartGachaAnimation()
    {

        animatorShake.speed = 1;
        yield return new WaitForSeconds(0.5f);
        audioManager.Play("Shake");
        yield return new WaitForSeconds(0.5f);
        audioManager.Play("Shake");
        yield return new WaitForSeconds(2.2f);
        if (!stop)
        {
            shakeGameObject.SetActive(false);
            fallBallGameObject.SetActive(true);
            fallBallAnimator.SetInteger("rarity", rarity);

            yield return new WaitForSeconds(1.3f);
            buttonSkip.SetActive(false);
            containerRewardAnimation.SetActive(true);
            buttonGoBackReward.enabled = false;


            fallBallAnimator.SetInteger("rarity", rarity);
            topBall.SetInteger("rarity", rarity);
            botBall.SetInteger("rarity", rarity);


            yield return new WaitForSeconds(0.5f);
            buttonGoBackReward.enabled = true;
        }
      
      
    }

    public void SkipContainer()
    {
        StartCoroutine(SkipGachaAnimation());
    }

    public IEnumerator SkipGachaAnimation()
    {
        audioManager.SetVolume("Shake",0);
        stop = true;
        StopCoroutine(StartGachaAnimation());
        StopCoroutine(StartGachaAnimation());
        buttonSkip.SetActive(false);

        shakeGameObject.SetActive(false);
        fallBallGameObject.SetActive(false);
        containerRewardAnimation.SetActive(true);
        buttonGoBackReward.enabled = false;

        fallBallAnimator.SetInteger("rarity", rarity);
        topBall.SetInteger("rarity", rarity);
        botBall.SetInteger("rarity", rarity);

        yield return new WaitForSeconds(0.5f);
        buttonGoBackReward.enabled = true;
    }

    public void exitReward()
    {
        fallBallGameObject.SetActive(false);
        containerRewardAnimation.SetActive(false);
        containerAnimationGacha.SetActive(false);
    }
    private void Start()
    {
        animatorShake = shakeGameObject.GetComponent<Animator>();
        fallBallAnimator = fallBallGameObject.GetComponent<Animator>();
            

        SetNumTickets();
        skinsLsit = allSkins.GetComponentsInChildren<Skin>();
        foreach(Skin a in skinsLsit)
        {
            print("skin");
        }
    }

    public int generateNumberRandom()
    {
        PreapreAndWait();
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
        audioManager.Play("ButtonClick");
        if (numTicketsSkins <= 0)
        {
            ChangeStateNoTicket();
        }
        else
        {
            numTicketsSkins--;
            numGachaSkins++;
            int numSkin=90;
            if (numGachaSkins == 10)
            {
                numGachaSkins = 0;
                skinsLsit[Random.Range(4, 4)].available = true;
            }
            else
            {
                 rarity = generateNumberRandom();
               
                switch (rarity)
                {
                    case 0:
                        numSkin = Random.Range(4, 4);
                        skinsLsit[numSkin].available = true;

                        break;
                    case 1:
                        numSkin = Random.Range(4, 4);
                        skinsLsit[numSkin].available = true;
                        break;
                    case 2:
                        numSkin = Random.Range(4, 4);
                        skinsLsit[numSkin].available = true;
                        break;
                }
            }
            SetSpriteSkinInRewardImage(numSkin);
        }
        SetNumTickets();
    }

    private void SetSpriteSkinInRewardImage(int numskin)
    {
        rewardSprite.sprite = skinsLsit[numskin].spriteSkin;
    }

    private IEnumerator ChangeButtonColor(Button button)
    {
        button.image.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        button.image.color = Color.white;
    }

    public void ClickGachaPowerUP()
    {
        audioManager.Play("ButtonClick");
        if (numTicketsPowerUps <= 0)
        {

            ChangeStateNoTicket();
        }
        else
        {
            numTicketsPowerUps--;
             rarity = generateNumberRandom();

            int num;
            switch (rarity)
            {
                case 0:

                    num = Random.Range(0, 2);
                    if (num == 1)
                    {
                        powerUps.numCommonBytesPerClick++;
                        rewardSprite.sprite = listPowerUpSprites[0];
                    }
                    else
                    {
                        powerUps.numCommonInfinityEnergy++;
                        rewardSprite.sprite = listPowerUpSprites[3];
                    }

                    break;
                case 1:

                    num = Random.Range(0, 2);
                    if (num == 1)
                    {
                        powerUps.numRareBytesPerClick++;
                        rewardSprite.sprite = listPowerUpSprites[1];
                    }
                    else {
                        powerUps.numRareInfinityEnergy++;
                        rewardSprite.sprite = listPowerUpSprites[4];
                    }
                
                    break;
                case 2:
                    num = Random.Range(0, 2);
                    if (num == 1)
                    {
                        powerUps.numEpicBytesPerClick++;
                        rewardSprite.sprite = listPowerUpSprites[2];
                    }
                    else {
                        powerUps.numEpicInfinityEnergy++;
                        rewardSprite.sprite = listPowerUpSprites[5];
                    }
                   

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
