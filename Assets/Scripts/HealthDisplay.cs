using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour {

    private TextMeshProUGUI healthText;
    private Player player;

    // Use this for initialization
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText("hp = " + player.GetHealth().ToString());
    }
}
