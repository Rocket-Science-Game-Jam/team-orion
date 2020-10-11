using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private int health = 100;
    [SerializeField]
    private HealthBar healthbar = null;
    [SerializeField]
    private GameObject explosion = null;
    [SerializeField]
    private Boundary boundary = new Boundary();

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
        GameObject instance = Instantiate(explosion);
        instance.transform.position = new Vector3(
            transform.position.x + Random.Range(boundary.xMin, boundary.xMax),
            transform.position.y + Random.Range(boundary.yMin, boundary.yMax),
            transform.position.z);
        instance.transform.parent = transform;
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
