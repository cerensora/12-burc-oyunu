using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Bu fonksiyon her zaman Build Settings listesindeki bir sonraki sahneyi açar
    public void SonrakiSahneyeGec()
    {
        // Þu an bulunduðumuz sahnenin sýrasýný bul
        int suAnkiSira = SceneManager.GetActiveScene().buildIndex;

        // Bir sonraki sýradaki sahneyi yükle
        SceneManager.LoadScene(suAnkiSira + 1);
    }
    // Bu fonksiyon oyuncuyu ilk parþömen sahnesine (1 numaralý sahne) geri gönderir
    public void YenidenOyna()
    {
        // Eðer Build Settings listesinde ilk parþömen sahneniz 1 numarayla kayýtlýysa burasý 1 kalmalý.
        // Eðer farklý bir sýradaysa (örneðin 2), buradaki sayýyý ona göre deðiþtirin.
        SceneManager.LoadScene(1);
    }

    // Bu fonksiyon oyunu tamamen kapatýr
    public void OyundanCik()
    {
        // Unity editöründe oyun oynarken pencere kapanmaz, bu yüzden konsola çalýþtýðýný yazdýrýyoruz.
        // Oyunu bilgisayara kaydettiðinizde (Build aldýðýnýzda) pencereyi sorunsuz kapatacaktýr.
        Debug.Log("Oyundan çýkýþ yapýldý!");
        Application.Quit();
    }
}