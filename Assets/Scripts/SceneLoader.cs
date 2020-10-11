using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void LoadSceneWithIndex(int index) {
        SceneManager.LoadScene(index);
    }

}
