using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu]
public class StatStaticDataRecord : ScriptableObject
{
    [field: SerializeField]
    public StatType Id { get; private set; }
    [field: SerializeField]
    public string DisplayName { get; private set; }
    [field: SerializeField]
    public Sprite IconSprite { get; private set; }
}