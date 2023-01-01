//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Plays the specified sound.
/// With PE changes.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Button Sound")]
public class UIButtonSound : MonoBehaviour
{
	public enum Trigger
	{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease,
	}

	[Header("NGUI Mode Use")]
	public AudioClip audioClip;
	[Header("PE Mode Use")]
	public int AudioID=422; // default click sound
	[Header("Change Model")]
	public bool UsePeMode = true;
	public Trigger trigger = Trigger.OnClick;
	public float volume = 1f;
	public float pitch = 1f;

	void OnHover (bool isOver)
	{
		if (enabled && ((isOver && trigger == Trigger.OnMouseOver) || (!isOver && trigger == Trigger.OnMouseOut)))
		{
			PlaySound();
		}
	}

	void OnPress (bool isPressed)
	{
		if (enabled && ((isPressed && trigger == Trigger.OnPress) || (!isPressed && trigger == Trigger.OnRelease)))
		{
			PlaySound();
		}
	}

	void OnClick ()
	{
		if (enabled && trigger == Trigger.OnClick)
		{
			PlaySound();
		}
	}

	void PlaySound()
	{
		if (UsePeMode && null != AudioManager.instance)
		{
			AudioManager.instance.Create(Vector3.zero, AudioID);
		}
		else
			NGUITools.PlaySound(audioClip, volume, pitch);
	}
}