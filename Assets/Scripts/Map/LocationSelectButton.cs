using TMPro;
using UnityEngine;

public class LocationSelectButton : MonoBehaviour
{
    [SerializeField]
    private LocationType _location;

    [SerializeField]
    private TMP_Text _locationText;

    void Start()
    {
        var locationData = Global.Locations.GetData(_location);
        _locationText.text = locationData.DisplayName;
    }

    public void MoveToLocation()
    {
        Global.Player.VisitLocation(_location);
    }
}
