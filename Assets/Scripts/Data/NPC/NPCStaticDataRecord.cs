using UnityEngine;

[CreateAssetMenu]
public class NPCStaticDataRecord : ScriptableObject
{
    [field: SerializeField]
    public NPCType Id { get; private set; }
    [field: SerializeField]
    public string DisplayName { get; private set; }
    [field: SerializeField]
    public Sprite StandingSprite_Idle { get; private set; }
    [field: SerializeField]
    public Sprite StandingSprite_Positive { get; private set; }
    [field: SerializeField]
    public Sprite StandingSprite_Negative { get; private set; }
}