#pragma once

#include "Thinfinity.VirtualUI.h"

class VuiVideo
{
private:
	std::wstring m_Xtagdir;
	JSObject* m_Video;
	std::wstring m_Src;
	VirtualUI* m_Vui;

public:
	VuiVideo();
	~VuiVideo();

	std::wstring XTagDir();
	void XTagDir(std::wstring value);

	float Position();
	void Position(float value);

	std::wstring Src();
	void Src(std::wstring value);

	float Length();

	std::wstring State();

	void(*OnStateChanged)(VuiVideo* sender);
	void(*OnLengthChanged)(VuiVideo* sender);
	void(*OnPositionChanged)(VuiVideo* sender);

	void Play();
	void Pause();
	void Stop();
	void Move(float position);

	void CreateComponent(std::wstring name, INT64 containerHandle);
};

