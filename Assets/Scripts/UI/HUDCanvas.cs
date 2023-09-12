using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HUDCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private RectTransform _deathScreen;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        HideDeathScreen();
    }

    private void Update()
    {
        _healthText.text = _player.HealthModule.CurrentHealth.ToString(); // TODO: Something other than this

        if (_player.HealthModule.CurrentHealth <= 0)
        {
            ShowDeathScreen();
        }
    }

    private void ShowDeathScreen()
    {
        _deathScreen.gameObject.SetActive(true);
    }

    private void HideDeathScreen()
    {
        _deathScreen.gameObject.SetActive(false);
    }


}