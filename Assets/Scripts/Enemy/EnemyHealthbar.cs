using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
