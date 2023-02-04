using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    GameRTSController gameRTSController;
    public int Health = 5;
    private void Awake()
    {
        gameRTSController = FindObjectOfType<GameRTSController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hit"))
        {
            Debug.Log("COLLISION");
            if (gameRTSController.SelectedRTS > 0)
            {
                Health -= gameRTSController.SelectedRTS;
            }
            else { 
                Destroy(this.gameObject);
            }
        }
    }
}
