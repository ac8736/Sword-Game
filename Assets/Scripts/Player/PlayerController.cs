using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fallSpeed = -1.0f;
    public GameObject shield;
    public bool isActiveShield = false;
    public int shieldPercentage = 100;
    public int health = 0;
    public TextMeshProUGUI depthTMP;
    public TextMeshProUGUI healthTMP;

    private Rigidbody2D _rg;

    void Start()
    {
        _rg = GetComponent<Rigidbody2D>();
        _rg.velocity = new Vector2(0, fallSpeed);
        StartCoroutine(DecreaseShields());
        StartCoroutine(IncreaseShields());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && shieldPercentage > 0)
        {
            if (shieldPercentage > 0)
            {
                isActiveShield = true;
            }
        } 
        else
        {
            if (shieldPercentage < 100)
            {
                isActiveShield = false;
            }
        }
        shield.SetActive(isActiveShield);

        if (_rg.velocity.y <= -20.0f)
        {
            _rg.velocity = new Vector2(_rg.velocity.x, -20.0f);
        }

        depthTMP.text = "Depth: " + (int)(transform.position.y + 10.92) + "m";
        healthTMP.text = "Hull Damage: " + health + "%";

        if (health >= 100)
        {
            SceneManager.LoadScene("End");
        }
    }

    IEnumerator DecreaseShields()
    { 
        while (true)
        {
            if (Input.GetKey(KeyCode.Space) && shieldPercentage > 0)
                shieldPercentage -= 1;
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator IncreaseShields()
    {
        while (true)
        {
            if (!Input.GetKey(KeyCode.Space) && shieldPercentage < 100)
                shieldPercentage += 1;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
