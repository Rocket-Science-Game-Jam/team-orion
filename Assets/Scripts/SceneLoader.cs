using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private static SceneLoader instance;

    public static SceneLoader GetInstance() {
        return instance;
    }

    // Start is called before the first frame update
    void Start() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadSceneWithIndex(int index) {
        SceneManager.LoadScene(index);
    }

}
