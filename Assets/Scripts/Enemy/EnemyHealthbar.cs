using UnityEngine;

public class EnemyHealthbar : MonoBehaviour
{
    
    public UnityEngine.UI.Image healthbar;

    void Start() {
        healthbar.enabled = false;
    }

    public void UpdateHealth(float healthPercent) {
        healthbar.enabled = true;
        healthbar.fillAmount = healthPercent;
    }

}
