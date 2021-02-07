using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSelector : MonoBehaviour
{
    private GameObject background;
    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject buyButton;
    public GameObject selectButton;
    public GameObject backArrow;
    public Camera mainCam;
    public Camera secondCam;
    private Animator camAnim;
    public GameObject gunDisplayPosition0;
    public GameObject gunDisplayPosition1;
    public GameObject gunDisplayPosition2;
    public GameObject gunDisplayPosition3;
    public GameObject gunDisplayPosition4;
    public GameObject gunDisplayPosition5;
    public GameObject gunDisplayPosition6;
    public GameObject gunDisplayPosition7;
    public GameObject gunDisplayPosition8;
    public GameObject gunDisplayPosition9;
    public GameObject currencyIcon;
    public GameObject currencyNumber;
    public TextMeshProUGUI currencyText;

    public TextMeshProUGUI priceText;
    public float gunPrice = 50f;

    private int clicks = 0;
    private bool mainScreen = true;

    public float currentMoney;

    private int gun1 = 0;
    private int gun2 = 0;
    private int gun3 = 0;
    private int gun4 = 0;
    private int gun5 = 0;
    private int gun6 = 0;
    private int gun7 = 0;
    private int gun8 = 0;
    private int gun9 = 0;
    private int gun10 = 0;

    private void Update()
    {
        if (clicks >= 0)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition0.transform.position, 2f);
            leftArrow.SetActive(false);
            gunPrice = 50f;

            if(PlayerPrefs.GetInt("gun1") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun1") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        if (clicks >= 1)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition1.transform.position, 2f);
            leftArrow.SetActive(true);
            gunPrice = 85f;

            if (PlayerPrefs.GetInt("gun2") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun2") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        if (clicks >= 2)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition2.transform.position, 2f);
            gunPrice = 225f;

            if (PlayerPrefs.GetInt("gun3") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun3") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        if (clicks >= 3)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition3.transform.position, 2f);
            gunPrice = 350f;

            if (PlayerPrefs.GetInt("gun4") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun4") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        if (clicks >= 4)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition4.transform.position, 2f);
            gunPrice = 500f;

            if (PlayerPrefs.GetInt("gun5") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun5") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        if (clicks >= 5)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition5.transform.position, 2f);
            gunPrice = 650f;

            if (PlayerPrefs.GetInt("gun6") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun6") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        if (clicks >= 6)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition6.transform.position, 2f);
            gunPrice = 900f;

            if (PlayerPrefs.GetInt("gun7") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun7") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        if (clicks >= 7)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition7.transform.position, 2f);
            gunPrice = 1100f;

            if (PlayerPrefs.GetInt("gun8") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun8") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        if (clicks >= 8)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition8.transform.position, 2f);
            rightArrow.SetActive(true);
            gunPrice = 1450f;

            if (PlayerPrefs.GetInt("gun9") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun9") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        if (clicks >= 9)
        {
            secondCam.transform.position = Vector3.Lerp(transform.position, gunDisplayPosition9.transform.position, 2f);
            rightArrow.SetActive(false);
            gunPrice = 2000f;

            if (PlayerPrefs.GetInt("gun10") == 1 && mainScreen == false)
            {
                buyButton.SetActive(false);
                selectButton.SetActive(true);
            }

            if (PlayerPrefs.GetInt("gun10") == 0 && mainScreen == false)
            {
                buyButton.SetActive(true);
                selectButton.SetActive(false);
            }
        }

        priceText.text = gunPrice.ToString();
        currentMoney = PlayerPrefs.GetFloat("currency");

        gun1 = PlayerPrefs.GetInt("gun1");
        gun2 = PlayerPrefs.GetInt("gun2");
        gun3 = PlayerPrefs.GetInt("gun3");
        gun4 = PlayerPrefs.GetInt("gun4");
        gun5 = PlayerPrefs.GetInt("gun5");
        gun6 = PlayerPrefs.GetInt("gun6");
        gun7 = PlayerPrefs.GetInt("gun7");
        gun8 = PlayerPrefs.GetInt("gun8");
        gun9 = PlayerPrefs.GetInt("gun9");
        gun10 = PlayerPrefs.GetInt("gun10");

        if(mainScreen == true)
        {
            selectButton.SetActive(false);
            buyButton.SetActive(false);
        }

        Debug.Log(PlayerPrefs.GetInt("gun5"));
    }

    private void FixedUpdate()
    {
        currencyText.text = PlayerPrefs.GetFloat("currency").ToString();
    }

    private void Start()
    {
        background = GameObject.Find("Background");
        camAnim = mainCam.GetComponent<Animator>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("1stLevel");
    }

    public void WaveMode()
    {
        SceneManager.LoadScene("WaveLevelSelector");
    }

    public void JoinWaveLevel()
    {
        SceneManager.LoadScene("WaveLevel");
    }

    public void OpenShop()
    {
        background.SetActive(false);
        camAnim.enabled = false;
        mainCam.gameObject.SetActive(false);
        secondCam.gameObject.SetActive(true);
        rightArrow.SetActive(true);
        currencyNumber.SetActive(true);
        currencyIcon.SetActive(true);
        buyButton.SetActive(true);
        backArrow.SetActive(true);

        currencyText.text = PlayerPrefs.GetFloat("currency").ToString();
        mainScreen = false;
    }

    public void CloseShop()
    {
        background.SetActive(true);
        camAnim.enabled = true;
        mainCam.gameObject.SetActive(true);
        secondCam.gameObject.SetActive(false);
        rightArrow.SetActive(false);
        currencyNumber.SetActive(false);
        currencyIcon.SetActive(false);
        buyButton.SetActive(false);
        backArrow.SetActive(false);

        mainScreen = true;
    }

    public void BuyGun()
    {
        if(currentMoney >= gunPrice)
        {
            PlayerPrefs.SetFloat("currency", currentMoney - gunPrice);

            if (clicks == 0)
            {
                PlayerPrefs.SetInt("gun1", 1);
            }
            else if (clicks == 1)
            {
                PlayerPrefs.SetInt("gun2", 1);
            }
            else if (clicks == 2)
            {
                PlayerPrefs.SetInt("gun3", 1);
            }
            else if (clicks == 3)
            {
                PlayerPrefs.SetInt("gun4", 1);
            }
            else if (clicks == 4)
            {
                PlayerPrefs.SetInt("gun5", 1);
            }
            else if (clicks == 5)
            {
                PlayerPrefs.SetInt("gun6", 1);
            }
            else if (clicks == 6)
            {
                PlayerPrefs.SetInt("gun7", 1);
            }
            else if (clicks == 7)
            {
                PlayerPrefs.SetInt("gun8", 1);
            }
            else if (clicks == 8)
            {
                PlayerPrefs.SetInt("gun9", 1);
            }
            else if (clicks == 9)
            {
                PlayerPrefs.SetInt("gun10", 1);
            }
        }
    }

    public void SelectGun()
    {

    }

    public void DeselectGun()
    {

    }

    public void MoveCameraRight()
    {
        clicks += 1;
    }

    public void MoveCameraLeft()
    {
        clicks -= 1;
    }
}
