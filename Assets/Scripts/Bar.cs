using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected Player Player;

    private float _step = 0.1f;

    public TMP_Text HealthText;

    private Coroutine _coroutine;

    private void Update()
    {
        HealthText.text = Player.CurrentHealth.ToString() + "/" + Player.HealthMax.ToString();
    }

    public void OnValueChanged(int value, int maxValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        float targetValue = (float)value / maxValue;
        _coroutine = StartCoroutine(ChangeBar(targetValue));
    }

    private IEnumerator ChangeBar(float targetValue)
    {
        while (Slider.value != targetValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, targetValue, _step * Time.deltaTime);
            yield return null;
        }
    }
}
