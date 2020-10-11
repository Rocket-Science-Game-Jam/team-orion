using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {

    [SerializeField]
    private int health = 100;
    [SerializeField]
    private HealthBar healthbar = null;
    [SerializeField]
    private GameObject explosion = null;
    [SerializeField]
    private Boundary boundary = new Boundary();
    [SerializeField]
    private UnityEvent onPlayerDied = new UnityEvent();

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
        InstantiateExplosion();
        health -= damage;
        healthbar.SetHealth(health);
        if(health <= 0) {
            StartCoroutine(playerDied());
        }
    }

    public void AddHealth(int value) {
        health += value;
        if (health > healthbar.GetMaxHealth()) {
            health = healthbar.GetMaxHealth();
        }
        healthbar.SetHealth(health);
    }

    private IEnumerator playerDied() {
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(transform.GetChild(0).GetComponent<SpriteRenderer>());
        for (int i = 0; i < 10; i++) {
            InstantiateExplosion();
        }
        yield return new WaitForSeconds(1f);
        onPlayerDied.Invoke();
    }

    private void InstantiateExplosion() {
        GameObject instance = Instantiate(explosion);
        instance.transform.position = new Vector3(
            transform.position.x + Random.Range(boundary.xMin, boundary.xMax),
            transform.position.y + Random.Range(boundary.yMin, boundary.yMax),
            transform.position.z);
        instance.transform.parent = transform;
    }

}
