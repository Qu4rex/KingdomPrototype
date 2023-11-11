using UnityEngine.UI;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private GameObject _bonfirePanel;

    [SerializeField] private Button _closePanelButton;

    private void Start()
    {
        _closePanelButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        _bonfirePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _bonfirePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _bonfirePanel.SetActive(false);
        }
    }
}


