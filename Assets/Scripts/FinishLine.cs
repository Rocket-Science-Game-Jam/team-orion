using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour {

    [SerializeField]
    private UnityEvent onTriggerEnter = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player") {
            //obj.GetComponent<Player>().TakeDamage(100);
            onTriggerEnter.Invoke();
        }
    }

}
