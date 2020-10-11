using UnityEngine;

public class Medikit : MonoBehaviour {

    [SerializeField]
    private int health = 25;

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            obj.GetComponent<Player>().AddHealth(health);
        }
    }

}
