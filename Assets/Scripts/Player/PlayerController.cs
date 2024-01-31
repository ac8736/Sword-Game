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
    private float initialX;
    private bool goingLeft = true;

    void Start()
    {
        _rg = GetComponent<Rigidbody2D>();
        _rg.velocity = new Vector2(0, fallSpeed);
        StartCoroutine(DecreaseShields());
        StartCoroutine(IncreaseShields());

        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingLeft)
        {
            _rg.velocity = new Vector2(-3.2f, _rg.velocity.y);
            if (System.Math.Abs(transform.position.x -  initialX) >= 4.0f && transform.position.x < initialX)
            {
                goingLeft = false;
            }
        }
        else
        {
            _rg.velocity = new Vector2(3.2f, _rg.velocity.y);
            if (System.Math.Abs(transform.position.x - initialX) >= 4.0f && transform.position.x > initialX)
            {
                goingLeft = true;
            }
        }

        if (Input.GetKey(KeyCode.Space) && shieldPercentage > 0)
        {
            isActiveShield = true;
        } 
        else
        {
            isActiveShield = false;
        }
        shield.SetActive(isActiveShield);

        if (_rg.velocity.y <= -25.0f)
        {
            _rg.velocity = new Vector2(_rg.velocity.x, -25.0f);
        }

        depthTMP.text = "Depth: " + (int)(transform.position.y + 10.92) + "m";
        healthTMP.text = "Damage: " + health + "%";

        if (health >= 100)
        {
            GlobalVars.score = (int)(transform.position.y + 10.92);
            SceneManager.LoadScene("End");
        }
    }

    IEnumerator DecreaseShields()
    { 
        while (true)
        {
            if (Input.GetKey(KeyCode.Space) && shieldPercentage > 0)
                shieldPercentage -= 1;
            yield return new WaitForSeconds(0.2f);
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
