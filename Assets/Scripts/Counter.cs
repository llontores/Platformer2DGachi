using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;
    
    private void OnEnable()
    {
        _player.OnMoneyChanged += ShowMoney;
    }

    private void OnDisable()
    {
        _player.OnMoneyChanged -= ShowMoney;
    }

    private void ShowMoney(int value)
    {
        _text.text = value.ToString();
    }
}
