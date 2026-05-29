using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // Sahne geçiþleri için gerekli kütüphane

public class VideoGecis : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sonrakiSahneAdi; // Inspector'dan yazacaðýmýz sahne adý

    void Start()
    {
        // Eðer videoPlayer atanmamýþsa, bu objedekini otomatik bul
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Video bittiðinde çalýþacak olayý (event) tanýmlýyoruz
        videoPlayer.loopPointReached += SahneyiDegistir;
    }

    void SahneyiDegistir(VideoPlayer vp)
    {
        // Video bittiðinde sonraki sahneyi yükler
        SceneManager.LoadScene(sonrakiSahneAdi);
    }
}