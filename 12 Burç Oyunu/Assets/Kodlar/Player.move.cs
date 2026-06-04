using UnityEngine;

public class PlayerMove : MonoBehaviour // Not: E�er Unity hata verirse script dosyas�n�n ad�n� da PlayerMove.cs olarak de�i�tirmen gerekebilir.
{
    [Header("Hareket Ayarlar�")]
    public float hareketHizi = 5f; // Karakterin h�z�n� Inspector panelinden de�i�tirebilirsin

    private Rigidbody2D rb;
    private Vector2 hareketYonu;

    void Start()
    {
        // Karakterin �zerindeki Rigidbody2D bile�enini otomatik olarak bulup al�yoruz
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Oyuncunun klavye girdilerini al�yoruz (W, A, S, D veya Y�n Tu�lar�)
        float hareketX = Input.GetAxisRaw("Horizontal"); // A ve D tu�lar� (Sol/Sa�)
        float hareketY = Input.GetAxisRaw("Vertical");   // W ve S tu�lar� (Yukar�/A�a��)

        // Girdileri bir y�n vekt�r�ne d�n��t�r�yoruz
        // .normalized kodu, karakterin �apraz giderken (�rne�in W ve D'ye ayn� anda basarken) normalden daha h�zl� gitmesini engeller.
        hareketYonu = new Vector2(hareketX, hareketY).normalized;
    }

    void FixedUpdate()
    {
        // Karakterin fiziksel hareketini ger�ekle�tiriyoruz
        // Hareket y�n�n� h�z�m�zla �arp�p Rigidbody'nin h�z�na (velocity) e�itliyoruz
        rb.linearVelocity = new Vector2(hareketYonu.x * hareketHizi, hareketYonu.y * hareketHizi);
    }
}