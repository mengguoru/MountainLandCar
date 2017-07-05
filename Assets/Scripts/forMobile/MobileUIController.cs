using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobileUIController : MonoBehaviour {
    public void reloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void toSelectScene()
    {
        SceneManager.LoadScene("choose_level");
    }
}
