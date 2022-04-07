using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public void GoStart() {
        SceneManager.LoadScene(0);
    }

    public void GoNext() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void GoLevel1() { // Global variable üretmeyi bilmediğim için şimdilik kopya fonksiyonlar yazdım.
        SceneManager.LoadScene(1);
    }
    public void GoLevel2() {
        SceneManager.LoadScene(2);
    }
    public void GoLevel3() {
        SceneManager.LoadScene(3);
    }
    public void GoLevel4() {
        SceneManager.LoadScene(4);
    }
    public void GoLevel5() {
        SceneManager.LoadScene(5);
    }
    public void GoLevel6() {
        SceneManager.LoadScene(6);
    }

    public void Exit() {
        Application.Quit();
    }
}
