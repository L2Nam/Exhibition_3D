using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public List<Material> skyboxMaterials;

    private int currentSkyboxIndex = 0;

    void Start()
    {
        if (skyboxMaterials.Count > 0)
        {
            RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];
            InvokeRepeating("ChangeSkybox", 8f, 8f);
        }
        else
        {
            Debug.LogError("No skybox materials assigned!");
        }
    }

    public void ChangeSkybox()
    {
        currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxMaterials.Count;
        RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];
        DynamicGI.UpdateEnvironment();
    }
}
