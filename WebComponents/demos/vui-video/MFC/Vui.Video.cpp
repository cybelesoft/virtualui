#include "Vui.Video.h"

VuiVideo* vuiVideoInstance;

void VideoOnPropertyChange(IJSObject* AObj, IJSProperty* AProp) {
	if (vuiVideoInstance == NULL) {
		return;
	}
	std::wstring propName = JSROGetPropertyName(AProp);
	if ((propName == L"state") && (vuiVideoInstance->OnStateChanged != NULL)) {
		vuiVideoInstance->OnStateChanged(vuiVideoInstance);
	}
	if ((propName == L"position") && (vuiVideoInstance->OnPositionChanged != NULL)) {
		vuiVideoInstance->OnPositionChanged(vuiVideoInstance);
	}
	if ((propName == L"length") && (vuiVideoInstance->OnLengthChanged != NULL)) {
		vuiVideoInstance->OnLengthChanged(vuiVideoInstance);
	}
}


VuiVideo::VuiVideo()
{
	vuiVideoInstance = this;

	WCHAR appPath[MAX_PATH];
	GetModuleFileNameW(NULL, appPath, MAX_PATH);
	m_Xtagdir = appPath;
	const size_t p = m_Xtagdir.rfind('\\');
	if (p != std::string::npos) {
		m_Xtagdir = m_Xtagdir.substr(0, p);
	}
	m_Xtagdir += L"\\x-tag\\";

	m_Vui = new VirtualUI();
}

VuiVideo::~VuiVideo()
{
	vuiVideoInstance = NULL;
}

std::wstring VuiVideo::XTagDir() {
	return m_Xtagdir;
}

void VuiVideo::XTagDir(std::wstring value) {
	m_Xtagdir = value;
}

float VuiVideo::Position() {
	IJSProperty* prop = m_Video->Properties()->Item(L"position");
	return JSROGetPropAsFloat(prop);
}

void VuiVideo::Position(float value) {
	IJSProperty* prop = m_Video->Properties()->Item(L"position");
	JSROSetPropAsFloat(prop, value);
}

std::wstring VuiVideo::Src() {
	return m_Src;
}

void VuiVideo::Src(std::wstring value) {
	std::wstring src = value;
	
	//TODO: Check if is file in a better way
	bool isFile = (src.find('\\') != std::string::npos);
	if (isFile) {
		src = m_Vui->HTMLDoc()->GetSafeURL(src, 60);
	}

	IJSProperty* prop = m_Video->Properties()->Item(L"src");
	JSROSetPropAsString(prop, src);
}

float VuiVideo::Length() {
	IJSProperty* prop = m_Video->Properties()->Item(L"length");
	return JSROGetPropAsFloat(prop);
}

std::wstring VuiVideo::State() {
	IJSProperty* prop = m_Video->Properties()->Item(L"state");
	return JSROGetPropAsString(prop);
}

void VuiVideo::Play() {
	m_Video->Events()->Item(L"Play")->Fire();
}

void VuiVideo::Pause() {
	m_Video->Events()->Item(L"Pause")->Fire();
}

void VuiVideo::Stop() {
	m_Video->Events()->Item(L"Stop")->Fire();
}

void VuiVideo::Move(float position) {
	IJSEvent* evt = m_Video->Events()->Item(L"move");
	JSROSetEventArgAsFloat(evt, L"Position", position);
	evt->Fire();
}

void VuiVideo::CreateComponent(std::wstring name, INT64 containerHandle) {
	m_Vui->HTMLDoc()->CreateSessionURL(std::wstring(L"/x-tag/"), m_Xtagdir);
	m_Vui->HTMLDoc()->LoadScript(std::wstring(L"/x-tag/x-tag-core.min.js"), L"");
	m_Vui->HTMLDoc()->ImportHTML(std::wstring(L"/x-tag/vui-video/vui-video.html"), L"");
	m_Vui->HTMLDoc()->CreateComponent(name, std::wstring(L"vui-video"), containerHandle);

	m_Video = new JSObject(name);
	m_Video->OnPropertyChange = VideoOnPropertyChange;

	IJSProperty* prop;
	prop = m_Video->Properties()->Add(L"state");
	JSROSetPropAsString(prop, L"");

	prop = m_Video->Properties()->Add(L"position");
	JSROSetPropAsFloat(prop, 0);

	prop = m_Video->Properties()->Add(L"length");
	JSROSetPropAsFloat(prop, 0);

	prop = m_Video->Properties()->Add(L"src");
	JSROSetPropAsString(prop, L"");

	IJSEvent* event = m_Video->Events()->Add(L"move");
	JSROAddEventArgument(event, L"position", JSDT_FLOAT);

	m_Video->Events()->Add(L"play");
	m_Video->Events()->Add(L"pause");
	m_Video->Events()->Add(L"stop");
	m_Video->ApplyModel();
}