using UnityEngine;

[CreateAssetMenu]
public class LocationStaticDataRecord : ScriptableObject
{
    [field: SerializeField]
    public LocationType Id { get; private set; }
    [field: SerializeField]
    public string DisplayName { get; private set; }
    [field: SerializeField]
    public Sprite BackgroundSprite { get; private set; }
    [field: SerializeField]
    public StatType StatType { get; private set; }
    [field: SerializeField]
    [field: TextArea]
    public string MonologueText { get; private set; }
}