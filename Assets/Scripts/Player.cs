using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private int health = 100;
    [SerializeField]
    private HealthBar healthbar = null;

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

    public void TakeDamage(int damage) {
        health -= damage;
        healthbar.SetHealth(health);
    }

    public void AddHealth(int value) {
        health += value;
        if(health > healthbar.GetMaxHealth()) {
            health = healthbar.GetMaxHealth();
        }
    }

}
