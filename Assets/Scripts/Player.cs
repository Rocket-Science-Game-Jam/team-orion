using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private int health = 100;
    [SerializeField]
    private HealthBar healthbar = null;
    private int score = 0;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start() {
        if(healthbar != null) {
            healthbar.SetMaxHealth(health);
        } else {
            Debug.LogWarning("Player: no healbar found");
        }
    }

}
