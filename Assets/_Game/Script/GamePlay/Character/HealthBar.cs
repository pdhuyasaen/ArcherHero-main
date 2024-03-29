using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float _reduceSpeed = 2;
    
    private Camera _camera;

    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.value = health/maxHealth;
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
    }
}
