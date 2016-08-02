
// JSROVideoMFCDlg.cpp : implementation file
//

#include "stdafx.h"
#include "JSROVideoMFC.h"
#include "JSROVideoMFCDlg.h"
#include "afxdialogex.h"
#include "Thinfinity.VirtualUI.h"
#include "Vui.Video.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

VirtualUI* vui;
VuiVideo* video;
bool playing;
CJSROVideoMFCDlg *g_MainDlg = NULL;

void videoOnStateChanged(VuiVideo* sender) {
	g_MainDlg->StatusText.SetWindowText(sender->State().c_str());
}

void videoOnLengthChanged(VuiVideo* sender) {
	g_MainDlg->Slider.SetRangeMax(sender->Length() * 100);
}

void videoOnPositionChanged(VuiVideo* sender) {
	g_MainDlg->Slider.SetPos(sender->Position() * 100);
}


// CJSROVideoMFCDlg dialog

CJSROVideoMFCDlg::CJSROVideoMFCDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CJSROVideoMFCDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CJSROVideoMFCDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_COMBO1, ComboUrl);
	DDX_Control(pDX, IDC_BUTTON1, BtnGo);
	DDX_Control(pDX, IDC_BUTTON2, BtnPlay);
	DDX_Control(pDX, IDC_BUTTON3, BtnStop);
	DDX_Control(pDX, IDC_SLIDER1, Slider);
	DDX_Control(pDX, IDC_LABEL1, StatusText);
	DDX_Control(pDX, IDC_PANEL1, PanelXVideo);
}

BEGIN_MESSAGE_MAP(CJSROVideoMFCDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CJSROVideoMFCDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CJSROVideoMFCDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON3, &CJSROVideoMFCDlg::OnBnClickedButton3)
	ON_WM_HSCROLL()
END_MESSAGE_MAP()


// CJSROVideoMFCDlg message handlers

BOOL CJSROVideoMFCDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	g_MainDlg = (CJSROVideoMFCDlg*)AfxGetMainWnd();

	Slider.SetRangeMin(0);
	Slider.SetRangeMax(1000);

	TCHAR appPath[MAX_PATH];
	GetModuleFileName(NULL, appPath, MAX_PATH);
	PathRemoveFileSpec(appPath);

	std::wstring Xtagdir(appPath);
	Xtagdir += L"\\..\\x-tag\\";

	vui = new VirtualUI();
	vui->Start();

	video = new VuiVideo();
	video->XTagDir(Xtagdir);
	video->OnLengthChanged = videoOnLengthChanged;
	video->OnPositionChanged = videoOnPositionChanged;
	video->OnStateChanged = videoOnStateChanged;
	video->CreateComponent(L"PanelXVideo", (INT64)(PanelXVideo.GetSafeHwnd()));

	std::wstring mediafile(appPath);
	mediafile += L"\\vui-video\\media\\big_buck_bunny_480p_2mb.mp4";

	ComboUrl.AddString(mediafile.c_str());
	ComboUrl.AddString(L"http://www.sample-videos.com/video/mp4/480/big_buck_bunny_480p_2mb.mp4");
	ComboUrl.AddString(L"http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_7200K.MP4");
	ComboUrl.AddString(L"http://download.openbricks.org/sample/H264/big_buck_bunny_1080p_H264_AAC_25fps_7200K_short.MP4");
	ComboUrl.AddString(L"http://download.openbricks.org/sample/H264/h264_Linkin_Park-Leave_Out_All_The_Rest.mp4");
	ComboUrl.AddString(L"http://download.wavetlan.com/SVV/Media/HTTP/H264/Talkinghead_Media/H264_test1_Talkinghead_mp4_480x360.mp4");
	ComboUrl.AddString(L"http://download.wavetlan.com/SVV/Media/HTTP/H264/Talkinghead_Media/H264_test3_Talkingheadclipped_mp4_480x360.mp4");
	ComboUrl.SetCurSel(0);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CJSROVideoMFCDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CJSROVideoMFCDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CJSROVideoMFCDlg::OnBnClickedButton1()
{
	CString sel;
	ComboUrl.GetLBText(ComboUrl.GetCurSel(), sel);
	std::wstring src(sel);

	video->Src(src);
	BtnPlay.SetWindowTextW(L"Play");
	playing = false;
}


void CJSROVideoMFCDlg::OnBnClickedButton2()
{
	if (!playing) {
		video->Play();
		BtnPlay.SetWindowText(L"Pause");
	}
	else {
		video->Pause();
		BtnPlay.SetWindowText(L"Play");
	}
	playing = !playing;
}


void CJSROVideoMFCDlg::OnBnClickedButton3()
{
	BtnPlay.SetWindowTextW(L"Play");
	playing = false;
	video->Stop();
}


void CJSROVideoMFCDlg::OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar) {
	if (pScrollBar->GetDlgCtrlID() == IDC_SLIDER1) {
		video->Move(Slider.GetPos() / 100);
	}
}