using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class Example : MonoBehaviour
{
    public PostProcessVolume postProcess;
    public float intensity = 0.5f;
    public float delay = 5f;
    private float initialIntensity;

    private void Start()
    {
        // the script starts the coroutine in the Start() method, and it sets the Chromatic Aberration setting's intensity value to a variable "intensity".
        var chromaticAberration = postProcess.profile.GetSetting<ChromaticAberration>();
        initialIntensity = chromaticAberration.intensity.value;

//VIGNETTE
         var vignette = postProcess.profile.GetSetting<Vignette>();
        initialIntensity = vignette.intensity.value;
        StartCoroutine(ChangeIntensity());
    }

    private IEnumerator ChangeIntensity()
    {
        //For chromatic Aberration  it waits for the duration specified in the "delay" variable and then sets the intensity value back to its initial value.
        
        var chromaticAberration = postProcess.profile.GetSetting<ChromaticAberration>();
        chromaticAberration.intensity.value = intensity;

//For Vignette effect it waits for the duration specified in the "delay" variable and then sets the intensity value back to its initial value.

 var vignette = postProcess.profile.GetSetting<Vignette>();
        vignette.intensity.value = intensity;
        //Waits for time in variable delay and sets to initial position
        yield return new WaitForSeconds(delay);
        chromaticAberration.intensity.value = initialIntensity;
         vignette.intensity.value = initialIntensity;
    }
}


