using System;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private GameObject _buildingPanel;

    private BuildingSlot _currentBuildingSlot;

    public void SetSlot(BuildingSlot slot)
    {
        _currentBuildingSlot = slot;
    }

    public void Build(GameObject _object)
    {
        Instantiate(_object, _currentBuildingSlot.transform);
        CloseBuilingPanel();
        _currentBuildingSlot.SetBuilding();
        _currentBuildingSlot.IsEmpty = false;
    }

    public void OpenBuilingPanel() => _buildingPanel.SetActive(true);
    public void CloseBuilingPanel() => _buildingPanel.SetActive(false);
}
