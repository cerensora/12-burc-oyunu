using UnityEngine;

public class TasPickUp : MonoBehaviour
{
    [Header("Baðlantýlar")]
    public ZamanKontrol zamanKontrolScripti;

    [Header("Ses Ayarlarý")]
    public AudioClip tasToplamaSesi; // Inspector'dan atayacaðýmýz ses dosyasý
    private AudioSource sesKaynagi;  // Karakterin üzerindeki hoparlör

    private void Start()
    {
        // Oyun baþladýðýnda karakterin üzerindeki AudioSource'u otomatik bulur
        sesKaynagi = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Karakterin çarptýðý nesnenin etiketi "Tas" ise
        if (collision.gameObject.CompareTag("Tas"))
        {
            // Eðer ses dosyasý ve hoparlör eklendiyse sesi çal
            if (tasToplamaSesi != null && sesKaynagi != null)
            {
                // PlayOneShot kullanýyoruz ki karakter hýzlýca iki taþ alýrsa sesler kesilmeden üst üste çalabilesin
                sesKaynagi.PlayOneShot(tasToplamaSesi);
            }

            // Taþý sahneden yok et
            Destroy(collision.gameObject);

            // Süreyi kýsalt ve sayacý sýfýrla
            if (zamanKontrolScripti != null)
            {
                zamanKontrolScripti.YeniTasaGec();
            }
        }
    }
}