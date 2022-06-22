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

public class vp_PlatformSwitch2 : vp_Interactable
{

    public float SwitchTimeout = 0;                                     // time in seconds before next switch can occur
    public vp_MovingPlatform Platform = null;                           // platform to control
    public vp_MovingPlatform Platform2 = null;
    public vp_MovingPlatform Platform3 = null;
    public vp_MovingPlatform Platform4 = null;
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
        if (Platform2 == null)
            return false;
        if (Platform3 == null)
            return false;
        if (Platform4 == null)
            return false;

        if (m_Player == null)
            m_Player = player;

        if (Time.time < m_Timeout)
            return false;

        PlaySound();

        // only try to actually operate the platform if we're the master.
        // if we're just a client the master should detect the trigger enter
        // too, and should activate the platform remotely
        if (vp_Gameplay.IsMaster)
            Platform.SendMessage("GoTo", Platform.TargetedWaypoint == 0 ? 1 : 0, SendMessageOptions.DontRequireReceiver);
        else if (InteractType == vp_InteractType.Normal)
            this.SendMessage("ClientTryInteract");

        if (vp_Gameplay.IsMaster)
            Platform2.SendMessage("GoTo", Platform2.TargetedWaypoint == 0 ? 1 : 0, SendMessageOptions.DontRequireReceiver);
        else if (InteractType == vp_InteractType.Normal)
            this.SendMessage("ClientTryInteract");

        if (vp_Gameplay.IsMaster)
            Platform3.SendMessage("GoTo", Platform3.TargetedWaypoint == 0 ? 1 : 0, SendMessageOptions.DontRequireReceiver);
        else if (InteractType == vp_InteractType.Normal)
            this.SendMessage("ClientTryInteract");

        if (vp_Gameplay.IsMaster)
            Platform4.SendMessage("GoTo", Platform4.TargetedWaypoint == 0 ? 1 : 0, SendMessageOptions.DontRequireReceiver);
        else if (InteractType == vp_InteractType.Normal)
            this.SendMessage("ClientTryInteract");

        m_Timeout = Time.time + SwitchTimeout;

        m_IsSwitched = !m_IsSwitched;

        return true;

    }


    /// <summary>
    /// 
    /// </summary>
    public virtual void PlaySound()
    {

        if (AudioSource == null)
        {
            Debug.LogWarning("Audio Source is not set");
            return;
        }

        if (SwitchSounds.Count == 0)
            return;

        AudioClip soundToPlay = SwitchSounds[Random.Range(0, SwitchSounds.Count)];

        if (soundToPlay == null)
            return;

        AudioSource.pitch = Random.Range(SwitchPitchRange.x, SwitchPitchRange.y);
        AudioSource.PlayOneShot(soundToPlay);

    }


    /// <summary>
    /// this is triggered when an object enters the collider and
    /// InteractType is set to trigger
    /// </summary>
    protected override void OnTriggerEnter(Collider col)
    {

        // only do something if the trigger is of type Trigger
        if (InteractType != vp_InteractType.Trigger)
            return;

        // see if the colliding object was a valid recipient
        foreach (string s in RecipientTags)
        {
            if (col.gameObject.tag == s)
                goto isRecipient;
        }
        return;
    isRecipient:

        m_Player = col.transform.root.GetComponent<vp_PlayerEventHandler>();

        if (m_Player == null)
            return;

        if ((m_Player.Interactable.Get() != null) && (m_Player.Interactable.Get().GetComponent<Collider>() == col))
            return;

        // calls the TryInteract method which is hopefully on the inherited class
        TryInteract(m_Player);

    }

}
