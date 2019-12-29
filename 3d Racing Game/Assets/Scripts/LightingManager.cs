using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public List<Light> lights;// list that stores the Headlights
    public virtual void ToggleHeadLights() 
    {
        foreach (Light light in lights) // for each of the light objects 
        {
            light.intensity = light.intensity == 0 ? 2 : 0; // change the light intensity
        }
    }

}
