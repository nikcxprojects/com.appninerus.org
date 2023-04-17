using UnityEngine.UI;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] AudioSource source;

    private void Start()
    {
        var img = GetComponent<Image>();
        img.color = source.mute ? Color.red : Color.green;

        GetComponent<Button>().onClick.AddListener(() =>
        {
            source.mute = !source.mute;
            img.color = source.mute ? Color.red : Color.green;
        });
    }
}
