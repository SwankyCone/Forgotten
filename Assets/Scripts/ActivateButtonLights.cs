using UnityEngine;

public class ActivateButtonLights : MonoBehaviour
{

    public GameObject dimLight;
    public GameObject brightLight;
    public void OnMouseEnter()
    {
        //Debug.Log("bright light");
        spawnBrightLight();

    }

    public void OnMouseExit() 
    {
        //Debug.Log("dim light");
        spawnDimLight();

    }

  public void spawnDimLight()
    {

        dimLight.SetActive(true);
        brightLight.SetActive(false);

    }

    public void spawnBrightLight()
    {

        dimLight.SetActive(false);
        brightLight.SetActive(true);

    }

}
