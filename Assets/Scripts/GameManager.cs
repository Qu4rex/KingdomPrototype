using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Win/Lose Panels")]
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _losePanel;

    [Header("Sounds")]
    [SerializeField] private AudioSource _movementSound;
    [SerializeField] private AudioSource _upgradeSound;
    [SerializeField] private AudioSource _buildingSound;
    [SerializeField] private AudioSource _startSound;
    [SerializeField] private AudioSource _loseSound;

    #region GameMethods
    public void Start()
    {
        Debug.Log("Start");
        PlaySound("StartSound");
    }
    public void Lose()
    {
        Debug.Log("Lose");
        PlaySound("LoseSound");
    }
    #endregion

    #region SoundManager
    public void PlaySound(string name)
    {
        switch(name)
        {
            case "MovementSound":
                break;
            case "UpgradeSound":
                break;
            case "BuildingSound":
                break;
            case "StartSound":
                break;
            case "LoseSound":
                break;
        }
    }
    #endregion
}
