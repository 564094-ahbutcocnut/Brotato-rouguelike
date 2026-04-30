using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayMessage : MonoBehaviour
{
    public GameObject messageText;
    // Drag your Text hodler element here in the Inspector

    [SerializeField] private TMPro.TMP_Text childText;

    // Function to set the message text
    public void ShowMessage(string message)
    {

        childText.text = message;

        //Show message
        messageText.SetActive(true);
    }

    // Function to hide the message text
    public void HideMessage()
    {
        messageText.SetActive(false);
    }
}
