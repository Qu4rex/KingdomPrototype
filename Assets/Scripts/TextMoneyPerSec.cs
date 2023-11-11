using UnityEngine.UI;
using UnityEngine;

public class TextMoneyPerSec : MonoBehaviour
{
    [SerializeField] private Text _textMoneyPerSec;

    private int _mps;
    
    private void OnEnable() => MineTower.onBuiltMine += UpdateMPSText;
    private void OnDisable() => MineTower.onBuiltMine -= UpdateMPSText;

    private void Start()
    {
        _mps = Wallet.Instance.GetMoneyPerSec();
        _textMoneyPerSec.text = _mps.ToString() + "/s";
    }

    public void UpdateMPSText(int value)
    {
        _mps += value;
        _textMoneyPerSec.text = _mps.ToString() + "/s";
    }
}
