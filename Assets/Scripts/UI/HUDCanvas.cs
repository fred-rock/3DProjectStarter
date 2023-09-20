using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    [SerializeField] private BasePlayerWeaponModule _weapon_1;
    [SerializeField] private Image _weaponIcon_1;
    [SerializeField] private TextMeshProUGUI _ammoText_1;

    [SerializeField] private BasePlayerWeaponModule _weapon_2;
    [SerializeField] private Image _weaponIcon_2;
    [SerializeField] private TextMeshProUGUI _ammoText_2;

    //[SerializeField] private BasePlayerWeaponModule _weapon_3;
    //[SerializeField] private Image _weaponIcon_3;
    //[SerializeField] private TextMeshProUGUI _ammoText_3;

    //[SerializeField] private BasePlayerWeaponModule _weapon_4;
    //[SerializeField] private Image _weaponIcon_4;
    //[SerializeField] private TextMeshProUGUI _ammoText_4;

    //[SerializeField] private BasePlayerWeaponModule _weapon_5;
    //[SerializeField] private Image _weaponIcon_5;
    //[SerializeField] private TextMeshProUGUI _ammoText_5;

    //[SerializeField] private BasePlayerWeaponModule _weapon_6;
    //[SerializeField] private Image _weaponIcon_6;
    //[SerializeField] private TextMeshProUGUI _ammoText_6;

    //[SerializeField] private BasePlayerWeaponModule _weapon_7;
    //[SerializeField] private Image _weaponIcon_7;
    //[SerializeField] private TextMeshProUGUI _ammoText_7;

    //[SerializeField] private BasePlayerWeaponModule _weapon_8;
    //[SerializeField] private Image _weaponIcon_8;
    //[SerializeField] private TextMeshProUGUI _ammoText_8;

    //[SerializeField] private BasePlayerWeaponModule _weapon_9;
    //[SerializeField] private Image _weaponIcon_9;
    //[SerializeField] private TextMeshProUGUI _ammoText_9;

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

        _ammoText_1.text = _player.AmmoModule.GetCurrentAmount(_weapon_1.WeaponData.AmmoType).ToString();
        _ammoText_2.text = _player.AmmoModule.GetCurrentAmount(_weapon_2.WeaponData.AmmoType).ToString();
        //_ammoText_3.text = _player.AmmoModule.GetCurrentAmount(_weapon_3.WeaponData.AmmoType).ToString();
        //_ammoText_4.text = _player.AmmoModule.GetCurrentAmount(_weapon_4.WeaponData.AmmoType).ToString();
        //_ammoText_5.text = _player.AmmoModule.GetCurrentAmount(_weapon_5.WeaponData.AmmoType).ToString();
        //_ammoText_6.text = _player.AmmoModule.GetCurrentAmount(_weapon_6.WeaponData.AmmoType).ToString();
        //_ammoText_7.text = _player.AmmoModule.GetCurrentAmount(_weapon_7.WeaponData.AmmoType).ToString();
        //_ammoText_8.text = _player.AmmoModule.GetCurrentAmount(_weapon_8.WeaponData.AmmoType).ToString();
        //_ammoText_9.text = _player.AmmoModule.GetCurrentAmount(_weapon_9.WeaponData.AmmoType).ToString();
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