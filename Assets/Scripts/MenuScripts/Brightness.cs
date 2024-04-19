using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class Brightness : MonoBehaviour {

public Text valueText;
//public UnityEngine.Rendering.Universal.Light2D global2DLight;
//public Slider intensitySlider;

 void Start()
    {
        // Add listener to the slider's value change event
        //intensitySlider.onValueChanged.AddListener(ChangeIntensity);
    }

public void OnSliderChanged(float value) {
    valueText.text = value.ToString();
    //global2DLight.intensity = value;
}

void ChangeIntensity(float value)
    {
        // Modify the intensity of the Global 2D Light
        //global2DLight.intensity = value;
    }
}
