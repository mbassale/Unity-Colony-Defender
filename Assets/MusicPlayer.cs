using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    const float SPLASH_DELAY = 3f;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            Invoke(nameof(LoadFirstScene), SPLASH_DELAY);
        }
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
