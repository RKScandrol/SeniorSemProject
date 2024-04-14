using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    
    public UnityEngine.UI.Image healthbar;

    public void UpdateHealth(float healthPercent) {
        healthbar.fillAmount = healthPercent;
    }

}
