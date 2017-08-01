using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Sharing.SyncModel;
using UnityEngine;

public class MySyncObject : SyncObject
{
    [SyncData]
    public SyncFloat FloatValue;
}
