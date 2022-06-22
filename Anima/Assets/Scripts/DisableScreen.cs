/////////////////////////////////////////////////////////////////////////////////
//
//	vp_PlatformSwitch.cs
//	© Opsive. All Rights Reserved.
//	https://twitter.com/Opsive
//	http://www.opsive.com
//
//	description:	This class allows the player to interact with vp_MovingPlatform.
//
/////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisableScreen : vp_Interactable
{

    public float SwitchTimeout = 0;                                     // time in seconds before next switch can occur
    public vp_MovingPlatform Platform = null;                           // platform to control
   // public vp_MovingPlatform Platform2 = null;
    public AudioSource AudioSource = null;
    public Vector2 SwitchPitchRange = new Vector2(1.0f, 1.5f);
    public List<AudioClip> SwitchSounds = new List<AudioClip>();        // list of sounds to randomly play when switched

    protected bool m_IsSwitched = false; // is this object in switched mode
    protected float m_Timeout = 0;


    protected override void Start()
    {

        base.Start();

        if (AudioSource == null)
            AudioSource = GetComponent<AudioSource>() == null ? gameObject.AddComponent<AudioSource>() : GetComponent<AudioSource>();

    }


    /// <summary>
    /// try to press this platform switch. this will have effect
    /// in singleplayer, but only in multiplayer if we're the
    /// master / server. sounds will always play and timers will
    /// be maintained in case of a master client handover
    /// </summary>
    public override bool TryInteract(vp_PlayerEventHandler player)
    {

        if (Platform == null)
            return false;
        

        if (m_Player == null)
            m_Player = player;

        if (Time.time < m_Timeout)
            return false;

        // only try to actually operate the platform if we're the master.
        // if we're just a client the master should detect the trigger enter
        // too, and should activate the platform remotely
        if (vp_Gameplay.IsMaster)
            Platform.SendMessage("GoTo", Platform.TargetedWaypoint == 0 ? 1 : 0, SendMessageOptions.DontRequireReceiver);
        else if (InteractType == vp_InteractType.Normal)
            this.SendMessage("ClientTryInteract");

       
        m_Timeout = Time.time + SwitchTimeout;

        m_IsSwitched = !m_IsSwitched;

        return true;

    }

}
