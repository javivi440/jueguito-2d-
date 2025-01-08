using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int vidamaxima = 5;
    public int vidas;
    public int dmgDelay = 5;
    private UIheallth lives;
    // Start is called before the first frame update
    void Start()
    {
        vidas = vidamaxima;
        lives = FindObjectOfType<UIheallth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage()
    {
        if (vidas > 0)
        {
            vidas = vidas - 1;
            Debug.Log("ha recibido daño");
            PlayerController hCtr = gameObject.GetComponent<PlayerController>();
            hCtr.cAnimator.SetBool("Hurt", true);
            lives.Updatehealth(vidas);
            playeraudio hAudio = gameObject.GetComponent<playeraudio>();
            hAudio.Damage();

        }
    }

    IEnumerator HurtDelay()
    {
        yield return new WaitForSeconds(dmgDelay);

        PlayerController hCtr = gameObject.GetComponent<PlayerController>();
        hCtr.cAnimator.SetBool("Hurt", false);
    }

    public void Regenerate()
    {

        lives.Updatehealth(vidas);
        if (vidas > 0)
        {
            vidas = vidas + 1;
            Debug.Log("ha regenerado vida");
        }
    }
}