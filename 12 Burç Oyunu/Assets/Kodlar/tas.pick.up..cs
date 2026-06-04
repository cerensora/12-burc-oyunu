using UnityEngine;
using UnityEngine.SceneManagement; // Sahne geçiþleri için bu kütüphaneyi ekliyoruz

public class TasPickUp : MonoBehaviour
{
    [Header("Baðlantýlar")]
    public ZamanKontrol zamanKontrolScripti;

    [Header("Ses Ayarlarý")]
    public AudioClip tasToplamaSesi;
    private AudioSource sesKaynagi;

    [Header("Bölüm Geçiþ Ayarlarý")]
    public int toplanmasiGerekenTas = 6; // Boss savaþý veya diðer sahne için gereken toplam taþ sayýsý
    private int toplananTas = 0; // Þu ana kadar toplanan taþlarý tutacak sayaç

    private void Start()
    {
        sesKaynagi = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tas"))
        {
            if (tasToplamaSesi != null && sesKaynagi != null)
            {
                sesKaynagi.PlayOneShot(tasToplamaSesi);
            }

            Destroy(collision.gameObject);

            // Her taþ toplandýðýnda sayacý 1 artýr
            toplananTas++;

            if (zamanKontrolScripti != null)
            {
                zamanKontrolScripti.YeniTasaGec();
            }

            // Eðer toplanan taþ sayýsý hedef sayýya ulaþtýysa sonraki sahneye geç
            if (toplananTas >= toplanmasiGerekenTas)
            {
                SonrakiSahneyeGec();
            }
        }
    }

    private void SonrakiSahneyeGec()
    {
        // Mevcut sahnenin build indeksini al ve bir sonrakini yükle
        int mevcutSahneIndeksi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(mevcutSahneIndeksi + 1);
    }
}