using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text healthText;
    private float _health = 100;
    void Start()
    {
        _slider.value = _health;
        healthText.text = _health.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_health > 0)
            {
                _health -= 20f;
                _slider.value = _health;
                healthText.text = _health.ToString();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_health <= 99)
            {
                _health += 20f;
                _slider.value = _health;
                healthText.text = _health.ToString();
            }
        }
    }
}