
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform piedestal;
    [SerializeField] Transform cat;

    [SerializeField] Vector3 offset;

    [SerializeField] GameObject ui_prefab;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        if(Keyboard.current.tKey.isPressed)
        {
            cat.position = piedestal.position + offset;
            cat.rotation = piedestal.rotation;
            piedestal.GetComponent<ParticleSystem>().Play();
            piedestal.GetComponent<AudioSource>().Play();
        }

        //if (Input.GetKeyDown(KeyCode.G))
        if(Keyboard.current.gKey.isPressed)
        {
            cat.localScale *= 1.2f;
        }

        //if (Input.GetKeyDown(KeyCode.M))
        if (Keyboard.current.mKey.isPressed)
        {
            var ui = Instantiate(ui_prefab);
            Timer.WaitThenDo(3f, () => Destroy(ui));
        }
    }
}
