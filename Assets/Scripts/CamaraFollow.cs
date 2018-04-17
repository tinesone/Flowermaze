using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public GameObject player;

    public float distance = 35f;

    float triggerDistanceX;
    float triggerDistanceY;

    void Start()
    {
        triggerDistanceX = Screen.width * (distance / 100f);
        triggerDistanceY = Screen.height * (distance / 100f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector2 newScreenPosition = new Vector2((float)Screen.width / (float)2, (float)Screen.height / (float)2);

        if (screenPos.x < triggerDistanceX)
            newScreenPosition += new Vector2(screenPos.x - triggerDistanceX, 0);
        else if (screenPos.x > Screen.width - triggerDistanceX)
            newScreenPosition += new Vector2(screenPos.x - Screen.width + triggerDistanceX, 0);

        if (screenPos.y < triggerDistanceY)
            newScreenPosition += new Vector2(0, screenPos.y - triggerDistanceY);
        else if (screenPos.y > Screen.height - triggerDistanceY)
            newScreenPosition += new Vector2(0, screenPos.y - Screen.height + triggerDistanceY);

        newScreenPosition = Camera.main.ScreenToWorldPoint(newScreenPosition);
        moveCameraTo(newScreenPosition);
    }

    void moveCameraTo(Vector2 pos)
    {
        transform.position = new Vector3(pos.x, pos.y, -10);
    }
}
