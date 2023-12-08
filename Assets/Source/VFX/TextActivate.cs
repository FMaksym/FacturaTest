using UnityEngine;

public class TextActivate : MonoBehaviour
{
    protected void ActivateText(TMPro.TMP_Text[] _text, int _index, Vector3 textTransform)
    {
        _text[_index].gameObject.SetActive(true);
        _text[_index].transform.position = textTransform;
    }

    protected void SetDamageText(TMPro.TMP_Text[] _text, int _index, int damageValue)
    {
        _text[_index].text = damageValue.ToString();
        if (_index < 4)
        {
            _index++;
        }
        else
        {
            _index = 0;
        }
    }

    protected void SetCoinText(TMPro.TMP_Text[] _text, int _index, int coinValue)
    {
        _text[_index].text = $" +{coinValue} ";
        if (_index < 4)
        {
            _index++;
        }
        else
        {
            _index = 0;
        }
    }
}
