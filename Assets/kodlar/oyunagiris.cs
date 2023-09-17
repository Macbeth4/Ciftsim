using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class oyunagiris : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_Text isimtexti;
    public GameObject girispaneli;
    public GameObject isimsorpanel;
    public GameObject seviyepaneli;
    public GameObject ayarlarpaneli;
    public GameObject ödülpaneli;
    public GameObject ödülverildi;
    public GameObject diyalogpaneli;
    public GameObject oyunpaneli;
    public GameObject karakter;
    public GameObject parakodu;

    private void Start()
    {
        karakter.SetActive(false);
        diyalogpaneli.SetActive(false);
        girispaneli.SetActive(true);
        isimsorpanel.SetActive(false);
        seviyepaneli.SetActive(false);
        ayarlarpaneli.SetActive(false);
        ödülpaneli.SetActive(false);
        oyunpaneli.SetActive(false);
    }
    public void oyunagir()
    {
        // PlayerPrefs'ten oyuncu adını alın
        string playerName = PlayerPrefs.GetString("PlayerName", "");

        if (string.IsNullOrEmpty(playerName))
        {
            // Oyuncu ilk defa giriyor, ismini sormamız gerekiyor
            ShowNameInputUI();
        }
        else
        {
            // Oyuncu daha önce girmiş, hoş geldin mesajını göster
            ShowWelcomeMessage(playerName);
        }
    }

    public void SavePlayerName()
    {
        string playerName = playerNameInput.text;

        PlayerPrefs.SetString("PlayerName", playerName);
        ShowWelcomeMessagediyalog(playerName);
    }

    public void ayarlaracil()
    {
        ayarlarpaneli.SetActive(true);
        seviyepaneli.SetActive(false);
        isimsorpanel.SetActive(false);
        girispaneli.SetActive(false);
        ödülpaneli.SetActive(false);
        oyunpaneli.SetActive(false);
    }

    public void kapanayarlar()
    {
        girispaneli.SetActive(true);
        ayarlarpaneli.SetActive(false);
        seviyepaneli.SetActive(false);
        isimsorpanel.SetActive(false);
        ödülpaneli.SetActive(false);
        oyunpaneli.SetActive(false);
    }

    public void ödül()
    {
        ödülpaneli.SetActive(true);
        ödülverildi.SetActive(false);
        ayarlarpaneli.SetActive(false);
        seviyepaneli.SetActive(false);
        isimsorpanel.SetActive(false);
        girispaneli.SetActive(false);
        oyunpaneli.SetActive(false);
    }
    public TMP_Text ödültexti;
    public async void OpenURL()
    {
        Application.OpenURL("https://www.instagram.com/besucbesdort/");
        await Task.Delay(500);
        ödülvermee();

    }
    private void ödülvermee()
    {
        if (PlayerPrefs.HasKey("odul"))
        {
            ödülverildi.SetActive(true);
            ödültexti.text = "ZATEN ALINMIS";
        }
        else
        {
            parakodu.GetComponent<para>().paramik += 100;
            ödülverildi.SetActive(true);
            ödültexti.text = "ODUL VERILDI";
            PlayerPrefs.SetInt("odul", 1);
        }
    }
    public void kapanödül()
    {
        girispaneli.SetActive(true);
        ayarlarpaneli.SetActive(false);
        seviyepaneli.SetActive(false);
        isimsorpanel.SetActive(false);
        ödülpaneli.SetActive(false);
        ödülverildi.SetActive(false);
        karakter.SetActive(false);
        oyunpaneli.SetActive(false);
    }

    private void ShowNameInputUI()
    {
        isimsorpanel.SetActive(true);
        oyunpaneli.SetActive(false);
        girispaneli.SetActive(false);
        seviyepaneli.SetActive(false);
        ayarlarpaneli.SetActive(false);
        ödülpaneli.SetActive(false);

    }

    private void ShowWelcomeMessage(string playerName)
    {
        girispaneli.SetActive(false);
        isimsorpanel.SetActive(false);
        isimtexti.text = playerName;
        seviyepaneli.SetActive(true);
        ayarlarpaneli.SetActive(false);
        ödülpaneli.SetActive(false);
        oyunpaneli.SetActive(true);
        karakter.SetActive(true);
    }

    [SerializeField] private TMP_Text diyalogtext;
    [SerializeField] private string[] cumleler;
    [SerializeField] private float yazmahızı;
    [SerializeField] private GameObject devambutonu;
    private int index;
    public GameObject soncumlebutton;
    private void ShowWelcomeMessagediyalog(string playerName)
    {
        girispaneli.SetActive(false);
        isimsorpanel.SetActive(false);
        isimtexti.text = playerName;
        seviyepaneli.SetActive(true);
        diyalogpaneli.SetActive(true);
        ayarlarpaneli.SetActive(false);
        ödülpaneli.SetActive(false);
        StartCoroutine(yaz());
    }
    IEnumerator yaz()
    {
        foreach (char harf in cumleler[index].ToCharArray())
        {
            diyalogtext.text += harf;
            yield return new WaitForSeconds(yazmahızı);
        }
    }
    private void Update()
    {
        if (diyalogtext.text == cumleler[index])
        {
            devambutonu.SetActive(true);
        }
    }
    public void sonrakicumle()
    {
        devambutonu.SetActive(false);
        if (index < cumleler.Length - 1)
        {
            index++;
            diyalogtext.text = "";
            StartCoroutine(yaz());
        }
        else
        {
            diyalogtext.text = "";
            devambutonu.SetActive(false);
            soncumlebutton.SetActive(true);
        }
    }
    public void diyalogpanelikapat(){
        diyalogpaneli.SetActive(false);
        oyunpaneli.SetActive(true);
        karakter.SetActive(true);
        
    }

}
