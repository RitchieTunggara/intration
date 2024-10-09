using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    public AudioSource bikeWheelSound;
    public AudioSource tireOnRoad;
    // Start is called before the first frame update
    void Start()
    {
        bikeWheelSound.Play(0);
        tireOnRoad.Play(0);
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isMove(bool move)
    {
        anim.SetBool("isMove", move);
        anim2.SetBool("isMove", move);
        if (move)
        {
            bikeWheelSound.UnPause();
            tireOnRoad.UnPause();
        }
        else
        {
            bikeWheelSound.Pause();
            tireOnRoad.Pause();
        }
    }
}
