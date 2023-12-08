using TMPro;
using UnityEngine;

public class EnemyDamageTextActivate : TextActivate
{
    [SerializeField] private int _index;
    [SerializeField] private TMP_Text[] _text;

    public void ActivateText(Vector3 textTransform, int damageValue)
    {
        base.SetDamageText(_text, _index, damageValue);
        base.ActivateText(_text, _index, textTransform);
    }
}
