using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{

    public Image ringHealthBar;
    public Image[] healthPoints;

    public float health, maxHealth = 100;
    float lerpSpeed;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        ringHealthBar.fillAmount = Mathf.Lerp(ringHealthBar.fillAmount, (health / maxHealth), lerpSpeed);

        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        }
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        ringHealthBar.color = healthColor;
    }

    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }

    public void Damage(float damagePoints)
    {
        if (health > 0)
            health -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
            health += healingPoints;
    }
}