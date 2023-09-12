using System.Collections;
using TMPro;
using UnityEngine;

public class HUDCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private RectTransform _deathScreen;
    [SerializeField] private RectTransform _hurtScreen;
    [SerializeField] private RectTransform _reticle;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _hurtScreen.gameObject.SetActive(false);
        HideDeathScreen();
    }

    private void Update()
    {
        _healthText.text = _player.HealthModule.CurrentHealth.ToString(); // TODO: Something other than this

        if (_player.HealthModule.CurrentHealth <= 0)
        {
            ShowDeathScreen();
        }

        if (_player.HealthModule.CurrentHealth > 0)
        {
            HideDeathScreen();
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

    public void ShowHurtScreen()
    {
        StartCoroutine(ShowHurtScreenCoroutine());
    }

    private IEnumerator ShowHurtScreenCoroutine()
    {
        _hurtScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        _hurtScreen.gameObject.SetActive(false);
    }
}