using UnityEngine;
using TMPro;

public class ActivarTextoAlDestruir : MonoBehaviour
{
    public TextMeshProUGUI textoAActivar;

    private void OnDestroy()
    {
        if (textoAActivar != null)
        {
            textoAActivar.gameObject.SetActive(true);
        }
    }
}
