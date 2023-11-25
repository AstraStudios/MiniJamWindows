using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishInfoPopup : MonoBehaviourSingletonPersistent<FishInfoPopup>
{
    [SerializeField] public TMP_Text info_text;
}
