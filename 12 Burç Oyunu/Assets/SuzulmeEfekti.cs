using UnityEngine;

public class SuzulmeEfekti : MonoBehaviour
{
    [Header("Süzülme Ayarlarý")]
    public float hiz = 2f;      // Karakterin ne kadar hýzlý inip çýkacaðý
    public float mesafe = 15f;  // Karakterin ne kadar yukarý ve aþaðý gideceði (Piksel cinsinden)

    private Vector3 baslangicPozisyonu;

    void Start()
    {
        // Oyun baþladýðýnda yaþlý adamýn ekrandaki ilk konumunu hafýzaya alýyoruz
        baslangicPozisyonu = transform.localPosition;
    }

    void Update()
    {
        // Mathf.Sin (Sinüs dalgasý) kullanarak yumuþak bir yukarý-aþaðý hareketi hesaplýyoruz
        float yeniY = Mathf.Sin(Time.time * hiz) * mesafe;

        // Hesaplanan yeni Y (dikey) pozisyonunu karaktere uyguluyoruz
        transform.localPosition = new Vector3(baslangicPozisyonu.x, baslangicPozisyonu.y + yeniY, baslangicPozisyonu.z);
    }
}