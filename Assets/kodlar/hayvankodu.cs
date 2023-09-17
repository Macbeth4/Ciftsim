using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hayvankodu : MonoBehaviour
{
    public GameObject parakodu;
    private float sayimAraligi = 1f;
    public GameObject hayvanpanel;
    public AudioSource ses;
    public AudioClip parasesi;
    public AudioClip yetersiz;
    [Header("TAVUK")]
    public GameObject[] tavuklar;
    public Button tavukbutonu;
    public GameObject yumurta;
    public Button tavuktoplabuttonu;
    public TMP_Text tvktoplatexti;
    public TMP_Text tavuktexti;
    public int tavuksuresi;
    public TMP_Text kalansure;
    public AudioClip tavuksesi;
    [Header("İNEK")]
    public GameObject inekler;
    public Button inekbutonu;
    public GameObject sut;
    public Button inektoplabutton;
    public TMP_Text inektoplatxt;
    public TMP_Text inektexti;
    public int ineksuresi;
    public TMP_Text ikalansure;
    public AudioClip ineksesi;

    private void Start()
    {
        tvktoplatexti.text = "BOS";
        inektoplatxt.text = "BOS";
        tavuktoplabuttonu.interactable = false;
        inektoplabutton.interactable = false;
        yumurta.SetActive(false);
        sut.SetActive(false);

        if (PlayerPrefs.HasKey("tavuk"))
        {
            tavuklar[0].SetActive(true);
            tavuklar[1].SetActive(true);
            tavuktexti.text = "BESLE 100 $";
        }
        else
        {
            //yani ilk defa olucak
            tavuklar[0].SetActive(false);
            tavuklar[1].SetActive(false);
            tavuktexti.text = "200 $";

        }

        if (PlayerPrefs.HasKey("inek"))
        {
            inekler.SetActive(true);
            inektexti.text = "BESLE 200 $";
        }
        else
        {
            //yani ilk defa olucak
            inekler.SetActive(false);
            inektexti.text = "400 $";

        }

    }

    public void hayvanacıl()
    {
        hayvanpanel.SetActive(true);
    }
    public void hayvankapan()
    {
        hayvanpanel.SetActive(false);
    }

    #region TAVUK
    public async void tavukal()
    {
        if (PlayerPrefs.HasKey("tavuk"))
        {
            if (parakodu.GetComponent<para>().paramik >= 100)
            {
                //besleme faaliyetleri
                parakodu.GetComponent<para>().paramik -= 100;
                StartCoroutine(tavukyumurtauretim());
                StartCoroutine(tavukgerisay());
            }
            else
            {
                tavuktexti.text = "YETERSIZ";
                ses.PlayOneShot(yetersiz);
                await Task.Delay(500);
                tavuktexti.text = "BESLE 100 $";

            }
        }
        else
        {
            if (parakodu.GetComponent<para>().paramik >= 200)
            {
                //yani ilk defa olucak
                parakodu.GetComponent<para>().paramik -= 200;
                tavuklar[0].SetActive(true);
                tavuklar[1].SetActive(true);
                PlayerPrefs.SetInt("tavuk", 1);
                tavuktexti.text = "BESLE 100 $";
            }
            else
            {
                tavuktexti.text = "YETERSIZ";
                ses.PlayOneShot(yetersiz);
                await Task.Delay(500);
                tavuktexti.text = "200 $";
            }
        }
    }

    public void tavuktopla()
    {
        parakodu.GetComponent<para>().paramik += 175;
        yumurta.SetActive(false);
        ses.PlayOneShot(parasesi);
        tvktoplatexti.text = "BOS";
        tavukbutonu.interactable = true;
        tavuktexti.text = "BESLE 100 $";
        tavuktoplabuttonu.interactable = false;

    }

    IEnumerator tavukyumurtauretim()
    {
        tavuktexti.text = "URETILIYOR";
        yumurta.SetActive(false);
        tavuktoplabuttonu.interactable = false;
        tavukbutonu.interactable = false;
        yield return new WaitForSeconds(tavuksuresi);
        ses.PlayOneShot(tavuksesi);
        tvktoplatexti.text = "TOPLA";
        tavuktexti.text = "BESLE 100 $";
        yumurta.SetActive(true);
        tavuktoplabuttonu.interactable = true;

    }

    IEnumerator tavukgerisay()
    {
        kalansure.gameObject.SetActive(true);
        int sayi = tavuksuresi;

        while (sayi >= 0)
        {
            kalansure.text = sayi + " SANIYE";
            yield return new WaitForSeconds(sayimAraligi);
            sayi--;
        }
        kalansure.gameObject.SetActive(false);
        tavuktexti.text = "URETILDI";
    }
    #endregion

    #region İNEK
    public async void inekal()
    {
        if (PlayerPrefs.HasKey("inek"))
        {
            if (parakodu.GetComponent<para>().paramik >= 200)
            {
                //besleme faaliyetleri
                parakodu.GetComponent<para>().paramik -= 200;
                StartCoroutine(ineksuturetim());
                StartCoroutine(inekgerisay());
            }
            else
            {
                inektexti.text = "YETERSIZ";
                ses.PlayOneShot(yetersiz);
                await Task.Delay(500);
                inektexti.text = "BESLE 200 $";

            }
        }
        else
        {
            if (parakodu.GetComponent<para>().paramik >= 400)
            {
                //yani ilk defa olucak
                parakodu.GetComponent<para>().paramik -= 400;
                inekler.SetActive(true);
                PlayerPrefs.SetInt("inek", 1);
                inektexti.text = "BESLE 200 $";
            }
            else
            {
                inektexti.text = "YETERSIZ";
                ses.PlayOneShot(yetersiz);
                await Task.Delay(500);
                inektexti.text = "400 $";
            }
        }
    }
    public void inektopla()
    {
        parakodu.GetComponent<para>().paramik += 400;
        sut.SetActive(false);
        inektoplatxt.text = "BOS";
        ses.PlayOneShot(parasesi);
        inekbutonu.interactable = true;
        inektexti.text = "BESLE 200 $";
        inektoplabutton.interactable = false;

    }
    IEnumerator ineksuturetim()
    {
        inektexti.text = "URETILIYOR";
        sut.SetActive(false);
        inektoplabutton.interactable = false;
        inekbutonu.interactable = false;
        yield return new WaitForSeconds(ineksuresi);
        ses.PlayOneShot(ineksesi);
        inektoplatxt.text = "TOPLA";
        inektexti.text = "BESLE 200 $";
        sut.SetActive(true);
        inektoplabutton.interactable = true;
    }
    IEnumerator inekgerisay()
    {
        ikalansure.gameObject.SetActive(true);
        int sayi1 = ineksuresi;

        while (sayi1 >= 0)
        {
            ikalansure.text = sayi1 + " SANIYE";
            yield return new WaitForSeconds(sayimAraligi);
            sayi1--;
        }
        ikalansure.gameObject.SetActive(false);
        inektexti.text = "URETILDI";
    }
    #endregion

}
