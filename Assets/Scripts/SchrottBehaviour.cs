using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SchrottBehaviour : MonoBehaviour {

    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float explodeDuration = 1f;
    [SerializeField]
    private float rotationSpeed = 10f;

    private float currentTime = 0f;

    private void Update() {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Player") {
            obj.GetComponent<Player>().TakeDamage(damage);
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode() {
        while (currentTime < explodeDuration) {
            currentTime += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }

}
