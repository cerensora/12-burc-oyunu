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
}