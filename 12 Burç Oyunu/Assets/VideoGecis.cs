using UnityEngine;
using UnityEngine.Video; // Video kodlarýný kullanabilmek için
using UnityEngine.SceneManagement; // Sahne geçiþleri için

public class VideoGecis : MonoBehaviour
{
    [Header("Gidilecek Sahne")]
    public int gidilecekSahneNumarasi; // Hangi sahneye gidileceðini Unity'den gireceðiz

    private VideoPlayer videoPlayer;

    void Start()
    {
        // Objenin üzerindeki Video Player'ý bul
        videoPlayer = GetComponent<VideoPlayer>();

        // "loopPointReached" komutu, video sonuna geldiðinde ne olacaðýný belirler
        videoPlayer.loopPointReached += VideoBitti;
    }

    void VideoBitti(VideoPlayer vp)
    {
        // Video bittiðinde belirlediðimiz sahneye geç!
        SceneManager.LoadScene(gidilecekSahneNumarasi);
    }
}