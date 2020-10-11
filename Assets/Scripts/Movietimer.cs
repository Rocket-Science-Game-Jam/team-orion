using UnityEngine;
using UnityEngine.Events;

public class Movietimer : MonoBehaviour {

    public float timer = 16f;
    public UnityEvent onMovieEnd = new UnityEvent();

    private float currenttime = 0f;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update() {
        if (currenttime < timer) {
            currenttime += Time.deltaTime;
            Debug.Log("time: " + currenttime);
        } else {
            onMovieEnd.Invoke();
        }
    }
}
