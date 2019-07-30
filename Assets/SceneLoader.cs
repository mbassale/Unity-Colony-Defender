using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    const float SPLASH_DELAY = 3f;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke(nameof(LoadFirstScene), SPLASH_DELAY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
