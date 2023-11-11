using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] protected Button _upgradeButton;
    [SerializeField] protected int _price;
    [SerializeField] protected Text _priceText;
    [SerializeField] protected Text _levelText;

    protected int _maxLevel = 5;
    protected int _currentLevel = 1;
    
    private void OnEnable() => Wallet.onChangedMoney += CheckCondition;
    private void OnDisable() => Wallet.onChangedMoney -= CheckCondition;
    
    private void Start()
    {
        _upgradeButton.onClick.AddListener(ApplyUpgrade);
        _levelText.text = _currentLevel.ToString() + " / " + _maxLevel.ToString();
        _priceText.text = _price.ToString();
    }

    private void CheckCondition(int _value)
    {
        if(_value >= _price && _currentLevel < _maxLevel)
            _upgradeButton.interactable = true;
        else
            _upgradeButton.interactable = false;
    }   

    protected virtual void ApplyUpgrade()
    {
        _currentLevel++;
        Wallet.Instance.RemoveMoney(_price);
        _price *= _currentLevel;
        _priceText.text = _price.ToString();
        _levelText.text = _currentLevel.ToString() + " / " + _maxLevel.ToString();
    }
}
