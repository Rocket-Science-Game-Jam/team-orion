using UnityEngine;

public class DestroySelf : MonoBehaviour {
    
    public void AnimationEnd() {
        Destroy(gameObject);
    }

}
