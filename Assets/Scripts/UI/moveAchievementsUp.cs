using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAchievementsUp : MonoBehaviour
{
    [SerializeField]
    showReturnButton srb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            transform.Translate(0, 1, 0);
            GetComponent<CanvasGroup>().alpha -= Time.deltaTime / 5.5f;

            if (transform.localPosition.y >= 569)
            {
                if (!srb.achievements.Contains(this.gameObject))
                    srb.achievements.Add(this.gameObject);
            }
        }

    }
}
