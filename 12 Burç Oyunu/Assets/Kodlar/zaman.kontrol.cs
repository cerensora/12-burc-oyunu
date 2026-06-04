using UnityEngine;
using UnityEngine.UI;
using TMPro; // Yazý (Text) bileþeni için gerekli
using System; // Convert.ToInt32 için gerekli

public class ZamanKontrol : MonoBehaviour
{
    [Header("Arayüz Baðlantýlarý")]
    public Image zamanBari;
    public TextMeshProUGUI zamanMetni;

    [Header("Zaman Ayarlarý")]
    public float baslangicSuresi = 15f; // Her taþ bulunduðunda sayacýn baþlayacaðý maksimum süre
    private float guncelSure;
    public float sureEksiltmeMiktari = 2f; // Taþý bulunca bir sonraki arayýþta azalacak saniye

    void Start()
    {
        guncelSure = baslangicSuresi;
    }

    void Update()
    {
        if (guncelSure > 0)
        {
            // Zamaný geriye doðru akýtýyoruz
            guncelSure -= Time.deltaTime;

            // Zaman barýnýn doluluk oranýný (0 ile 1 arasý) güncelliyoruz
            if (zamanBari != null)
            {
                zamanBari.fillAmount = guncelSure / baslangicSuresi;
            }

            // Küsuratlý zamaný tam sayýya çevirerek ekrana yazdýrýyoruz
            if (zamanMetni != null)
            {
                zamanMetni.text = Convert.ToInt32(guncelSure).ToString();
            }
        }
        else
        {
            // Süre 0'ýn altýna düþtüðünde yapýlacaklar
            guncelSure = 0;
            if (zamanBari != null) zamanBari.fillAmount = 0;
            if (zamanMetni != null) zamanMetni.text = "0";

            Debug.Log("Zaman Doldu! Karakter saklanamadý.");
            // Buraya oyun bitirme veya baþa sarma kodlarý eklenebilir
        }
    }

    // Karakter taþý bulduðunda (TasPickUp scripti tarafýndan) bu fonksiyon çaðrýlacak
    public void YeniTasaGec()
    {
        baslangicSuresi -= sureEksiltmeMiktari; // Max süreyi düþür (Örn: 15'ten 13'e)

        // Süre eksiye veya imkansýz bir deðere düþmesin diye minimum sýnýr (örn: 3 saniye)
        if (baslangicSuresi < 3f)
        {
            baslangicSuresi = 3f;
        }

        guncelSure = baslangicSuresi; // Sayacý yeni ve daha kýsa süreyle baþtan baþlat
        Debug.Log("Yeni taþ bulundu! Yeni süre: " + baslangicSuresi);
    }
}