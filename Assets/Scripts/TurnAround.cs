using TMPro;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    [SerializeField] TMP_Text turnAroundText;


    public void OnTriggerEnter(Collider other)
    {
        turnAroundText.text = "[ Can't leave until I find Sophie ]";
        turnAroundText.gameObject.SetActive(true);


    }

    public void OnTriggerExit(Collider other)
    {

        turnAroundText.gameObject.SetActive(false);

    }

    



}
