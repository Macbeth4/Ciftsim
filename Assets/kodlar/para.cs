using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;
public class para : MonoBehaviour
{
    public int paramik = 100;
    public TMP_Text paratext;
    public Button[] buttonlar;
    public TMP_Text gerisayim;
    private float sayimAraligi = 1f;
    public GameObject paraefekti;
    public AudioSource ses;
    public AudioClip parasesi;
    public AudioClip ekmesesi;
    public AudioClip bicmesesi;
    public AudioClip yetersiz;

    [Header("HAVUC")]
    public GameObject havucunilkhali;
    public GameObject havucunikincihali;
    public GameObject havucunsonhali;
    public Button havuctoplabutton;
    public TMP_Text havuctexi;
    public int havucsayısı;
    public string havucyazisi;

    [Header("MISIR")]
    public GameObject mısırınilkhali;
    public GameObject mısırınikincihali;
    public GameObject mısırınsonhali;
    public Button mısırtoplabutton;
    public TMP_Text mısırtexi;
    public int mısırsayısı;
    public string mısıryazisi;

    [Header("SOGAN")]
    public GameObject soganınilkhali;
    public GameObject soganınikincihali;
    public GameObject soganınsonhali;
    public Button sogantoplabutton;
    public TMP_Text sogantexi;
    public int sogansayısı;
    public string soganyazisi;

    [Header("MARUL")]
    public GameObject marulunilkhali;
    public GameObject marulunikincihali;
    public GameObject marulunsonhali;
    public Button marultoplabutton;
    public TMP_Text marultexi;
    public int marulsayısı;
    public string marulyazisi;

    private void Update()
    {
        paratext.text = paramik.ToString();
        PlayerPrefs.SetInt("ParaMiktarı", paramik);
        PlayerPrefs.Save();
    }

    // Para miktarını PlayerPrefs ile kaydetme
  /*  void OnDestroy()
    {
        PlayerPrefs.SetInt("ParaMiktarı", paramik);
        PlayerPrefs.Save();
    }*/
    // PlayerPrefs'ten para miktarını yükleme
    void Awake()
    {
        if (PlayerPrefs.HasKey("ParaMiktarı"))
        {
            paramik = PlayerPrefs.GetInt("ParaMiktarı");
        }
        else
        {
            paramik = 100;
        }

        if (paramik < 50) { paramik = 50; }
    }


    #region HAVUC
    public async void havucalAsync()
    {
        if (paramik >= 50)
        {
            paramik -= 50;
            StartCoroutine(havucekilmesi());
            StartCoroutine(havucgerisay());
        }
        else
        {
            havuctexi.text = "YETERSIZ";
            ses.PlayOneShot(yetersiz);
            await Task.Delay(500);
            havuctexi.text = havucyazisi;
        }
    }
    public async void havuctoplaAsync()
    {
        foreach (Button düğme in buttonlar) { düğme.interactable = true; }
        paramik += 75;
        paraefekti.SetActive(true);
        ses.PlayOneShot(parasesi);

        havucunilkhali.SetActive(false);
        havucunikincihali.SetActive(false);
        havucunsonhali.SetActive(false);
        havuctexi.text = havucyazisi;
        havuctoplabutton.gameObject.SetActive(false);
        await Task.Delay(500);
        paraefekti.SetActive(false);
    }

    IEnumerator havucgerisay()
    {
        gerisayim.gameObject.SetActive(true);
        int sayi = havucsayısı;

        while (sayi >= 0)
        {
            gerisayim.text = sayi + " SANIYE";
            yield return new WaitForSeconds(sayimAraligi);
            sayi--;
        }
        gerisayim.gameObject.SetActive(false);
    }

    IEnumerator havucekilmesi()
    {
        // butonları devre dışı bıraktı
        foreach (Button düğme in buttonlar) { düğme.interactable = false; }

        havuctexi.text = "URETILIYOR";
        ses.PlayOneShot(ekmesesi);
        havucunilkhali.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        havucunilkhali.SetActive(false);
        havucunikincihali.SetActive(true);
        yield return new WaitForSecondsRealtime(6f);
        havucunikincihali.SetActive(false);
        havucunsonhali.SetActive(true);
        ses.PlayOneShot(bicmesesi);
        havuctoplabutton.gameObject.SetActive(true);

        havuctexi.text = "URETILDI";

    }
    #endregion

    #region MISIR
    public async void mısıralAsync()
    {
        if (paramik >= 100)
        {
            paramik -= 100;
            StartCoroutine(mısırekilmesi());
            StartCoroutine(mısırgerisay());
        }
        else
        {
            mısırtexi.text = "YETERSIZ";
            ses.PlayOneShot(yetersiz);
            await Task.Delay(500);
            mısırtexi.text = mısıryazisi;
        }
    }

    public async void mısırtoplaAsync()
    {
        foreach (Button düğme in buttonlar) { düğme.interactable = true; }
        paramik += 150;
        paraefekti.SetActive(true);
        ses.PlayOneShot(parasesi);

        mısırınilkhali.SetActive(false);
        mısırınikincihali.SetActive(false);
        mısırınsonhali.SetActive(false);
        mısırtexi.text = mısıryazisi;
        mısırtoplabutton.gameObject.SetActive(false);
        await Task.Delay(500);
        paraefekti.SetActive(false);
    }

    IEnumerator mısırgerisay()
    {
        gerisayim.gameObject.SetActive(true);
        int sayi1 = mısırsayısı;

        while (sayi1 >= 0)
        {
            gerisayim.text = sayi1 + " SANIYE";
            yield return new WaitForSeconds(sayimAraligi);
            sayi1--;
        }
        gerisayim.gameObject.SetActive(false);
    }

    IEnumerator mısırekilmesi()
    {
        // butonları devre dışı bıraktı
        foreach (Button düğme in buttonlar) { düğme.interactable = false; }

        mısırtexi.text = "URETILIYOR";
        ses.PlayOneShot(ekmesesi);
        mısırınilkhali.SetActive(true);
        yield return new WaitForSecondsRealtime(10f);
        mısırınilkhali.SetActive(false);
        mısırınikincihali.SetActive(true);
        yield return new WaitForSecondsRealtime(10f);
        mısırınikincihali.SetActive(false);
        mısırınsonhali.SetActive(true);
        ses.PlayOneShot(bicmesesi);
        mısırtoplabutton.gameObject.SetActive(true);

        mısırtexi.text = "URETILDI";

    }
    #endregion

    #region SOGAN
    public async void soganal()
    {
        if (paramik >= 150)
        {
            paramik -= 150;
            StartCoroutine(soganekilmesi());
            StartCoroutine(sogangerisay());
        }
        else
        {
            sogantexi.text = "YETERSIZ";
            ses.PlayOneShot(yetersiz);
            await Task.Delay(500);
            sogantexi.text = soganyazisi;
        }
    }

    public async void sogantoplaAsync()
    {
        foreach (Button düğme in buttonlar) { düğme.interactable = true; }
        paramik += 225;
        paraefekti.SetActive(true);
        ses.PlayOneShot(parasesi);

        soganınilkhali.SetActive(false);
        soganınikincihali.SetActive(false);
        soganınsonhali.SetActive(false);
        sogantexi.text = soganyazisi;
        sogantoplabutton.gameObject.SetActive(false);
        await Task.Delay(500);
        paraefekti.SetActive(false);
    }

    IEnumerator sogangerisay()
    {
        gerisayim.gameObject.SetActive(true);
        int sayi2 = sogansayısı;

        while (sayi2 >= 0)
        {
            gerisayim.text = sayi2 + " SANIYE";
            yield return new WaitForSeconds(sayimAraligi);
            sayi2--;
        }
        gerisayim.gameObject.SetActive(false);
    }

    IEnumerator soganekilmesi()
    {
        // butonları devre dışı bıraktı
        foreach (Button düğme in buttonlar) { düğme.interactable = false; }

        sogantexi.text = "URETILIYOR";
        ses.PlayOneShot(ekmesesi);
        soganınilkhali.SetActive(true);
        yield return new WaitForSecondsRealtime(15f);
        soganınilkhali.SetActive(false);
        soganınikincihali.SetActive(true);
        yield return new WaitForSecondsRealtime(15f);
        soganınikincihali.SetActive(false);
        soganınsonhali.SetActive(true);
        ses.PlayOneShot(bicmesesi);
        sogantoplabutton.gameObject.SetActive(true);

        sogantexi.text = "URETILDI";

    }
    #endregion

    #region MARUL
    public async void marulal()
    {
        if (paramik >= 200)
        {
            paramik -= 200;
            StartCoroutine(marulekilmesi());
            StartCoroutine(marulgerisay());
        }
        else
        {
            marultexi.text = "YETERSIZ";
            ses.PlayOneShot(yetersiz);
            await Task.Delay(500);
            marultexi.text = marulyazisi;
        }
    }

    public async void marultoplaAsync()
    {
        foreach (Button düğme in buttonlar) { düğme.interactable = true; }
        paramik += 275;
        paraefekti.SetActive(true);
        ses.PlayOneShot(parasesi);

        marulunilkhali.SetActive(false);
        marulunikincihali.SetActive(false);
        marulunsonhali.SetActive(false);
        marultexi.text = marulyazisi;
        marultoplabutton.gameObject.SetActive(false);
        await Task.Delay(500);
        paraefekti.SetActive(false);
    }

    IEnumerator marulgerisay()
    {
        gerisayim.gameObject.SetActive(true);
        int sayi3 = marulsayısı;

        while (sayi3 >= 0)
        {
            gerisayim.text = sayi3 + " SANIYE";
            yield return new WaitForSeconds(sayimAraligi);
            sayi3--;
        }
        gerisayim.gameObject.SetActive(false);
    }

    IEnumerator marulekilmesi()
    {
        // butonları devre dışı bıraktı
        foreach (Button düğme in buttonlar) { düğme.interactable = false; }

        marultexi.text = "URETILIYOR";
        ses.PlayOneShot(ekmesesi);
        marulunilkhali.SetActive(true);
        yield return new WaitForSecondsRealtime(22f);
        marulunilkhali.SetActive(false);
        marulunikincihali.SetActive(true);
        yield return new WaitForSecondsRealtime(23f);
        marulunikincihali.SetActive(false);
        marulunsonhali.SetActive(true);
        ses.PlayOneShot(bicmesesi);
        marultoplabutton.gameObject.SetActive(true);

        marultexi.text = "URETILDI";

    }
    #endregion

     public async void sıfırla(){
        PlayerPrefs.DeleteAll();
        paramik = 0;
        await Task.Delay(400);
        SceneManager.LoadScene(0);
    }

}
