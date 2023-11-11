using UnityEngine;
using UnityEngine.UI;

public class BuildingItem : MonoBehaviour
{
    [SerializeField] private Button _buildButton;

    [SerializeField] private GameObject _buildingPrefab;

    [SerializeField] private int _price;
    [SerializeField] private Text _priceText;

    private BuildingManager _buildingManager;

    private void OnEnable() => Wallet.onChangedMoney += CheckCondition;
    private void OnDisable() => Wallet.onChangedMoney -= CheckCondition;

    private void Start()
    {
        _priceText.text = _price.ToString();
        _buildingManager = FindObjectOfType<BuildingManager>();
        _buildButton.onClick.AddListener(Buy);
    }

    private void Buy()
    {
        _buildingManager.Build(_buildingPrefab);
        Wallet.Instance.RemoveMoney(_price);
    }
    
    private void CheckCondition(int _value)
    {
        if(_value >= _price)
            _buildButton.interactable = true;
        else
            _buildButton.interactable = false;
    }
}
