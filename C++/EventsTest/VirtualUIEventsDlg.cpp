
// VirtualUIEventsDlg.cpp : implementation file
//

#include "stdafx.h"
#include "VirtualUIEvents.h"
#include "VirtualUIEventsDlg.h"
#include "afxdialogex.h"

#include "Thinfinity.VirtualUI.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

CVirtualUIEventsDlg* DlgInstance;
VirtualUI* Vui;
std::wstring AppDir;
std::wstring TestDir;
std::wstring LogfileName;

void RemoveDirContents(CString szPath) {
	CFileFind ff;
	CString path = szPath;

	if (path.Right(1) != "\\") path += "\\";
	path += "*.*";

	BOOL res = ff.FindFile(path);
	while (res) {
		res = ff.FindNextFile();
		if (ff.IsDots())
			continue;
		if (ff.IsDirectory()) {
			path = ff.GetFilePath();
			RemoveDirContents(path);
			RemoveDirectory(path);
		}
		else {
			DeleteFile(ff.GetFilePath());
		}
	}
	ff.Close();
}

// VirtualUI event handlers

void Vui_OnBrowserResize(int &Width, int &Height, bool &ResizeMaximized) {
	CString data;
	data.Format(_T("OnBrowserResize: %dx%d"), Width, Height);
	DlgInstance->Log(std::wstring(data));
}

void Vui_OnGetUploadDir(std::wstring &Directory, bool &Handled) {
	Directory = TestDir + L"Uploads";
	Handled = true;
	DlgInstance->Log(L"OnGetUploadDir: Set " + Directory);
}

void Vui_OnClose() {
	DlgInstance->Log(L"OnClose");
	DlgInstance->SendMessage(WM_CLOSE);
}

void Vui_OnDownloadEnd(std::wstring &Filename) {
	DlgInstance->Log(L"OnDownloadEnd: " + Filename);
}

void Vui_OnUploadEnd(std::wstring &Filename) {
	DlgInstance->Log(L"OnUploadEnd: " + Filename);
}

void Vui_OnDragFile(DragAction Action, int X, int Y, std::wstring Filenames) {
	// Using OnDragFile2
}

void Vui_OnSaveDialog(std::wstring Filename) {
	DlgInstance->Log(L"OnSaveDialog: " + Filename);
}

void Vui_OnDragFile2(DragAction Action, long ScreenX, long ScreenY, std::wstring Filenames, bool &Accept) {
	CString actionStr = L"Unknown";
	switch (Action)
	{
		case DRAG_START:
			actionStr = L"Start";
			break;
		case DRAG_OVER:
			actionStr = L"Over";
			break;
		case DRAG_DROP:
			actionStr = L"Drop";
			break;
		case DRAG_CANCEL:
			actionStr = L"Cancel";
			break;
		case DRAG_ERROR:
			actionStr = L"Error";
			break;
	}
	
	CString data;
	data.Format(_T("OnDragFile2: %s on %d.%d"), actionStr, ScreenX, ScreenY);
	data.Append(L" Files:");
	data.Append(Filenames.c_str());
	DlgInstance->Log(std::wstring(data));

	Accept = true;
}

void Vui_OnDropFile(long ScreenX, long ScreenY, std::wstring Filenames, std::wstring FileSizes, std::wstring &IgnoreFiles) {
	CString data;
	data.Format(_T("OnDropFile: %d.%d"), ScreenX, ScreenY);
	data.Append(L" Files:");
	data.Append(Filenames.c_str());
	data.Append(L" Sizes:");
	data.Append(FileSizes.c_str());
	DlgInstance->Log(std::wstring(data));

	//TODO: Test IgnoreFiles (Set in the form: "ignore1.txt|ignore2.log|ignoreN.exe")
	Vui->Uploadfile();
}

void Vui_OnReceiveMessage(std::wstring &Data) {
	DlgInstance->Log(L"OnReceiveMessage: " + Data);
}

void Vui_OnRecorderChanged() {
	DlgInstance->Log(L"OnRecorderChanged");
}


// CVirtualUIEventsDlg dialog

CVirtualUIEventsDlg::CVirtualUIEventsDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_VIRTUALUIEVENTS_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CVirtualUIEventsDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CHECK_REMOVE_TESTDIR, CheckRemoveTestDir);
	DDX_Control(pDX, IDC_CHECK_SAVELOG, CheckSaveLog);
	DDX_Control(pDX, IDC_EDIT_LOG, EditLog);
	DDX_Control(pDX, IDC_STATIC_TESTDIR, TxtTestDir);
}

BEGIN_MESSAGE_MAP(CVirtualUIEventsDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_CLOSE()
	ON_BN_CLICKED(IDC_BUTTON_DOWNLOAD, &CVirtualUIEventsDlg::OnBnClickedButtonDownload)
	ON_BN_CLICKED(IDC_BUTTON_UPLOAD, &CVirtualUIEventsDlg::OnBnClickedButtonUpload)
	ON_BN_CLICKED(IDC_BUTTON_PRINTPDF, &CVirtualUIEventsDlg::OnBnClickedButtonPrintPDF)
END_MESSAGE_MAP()

void CVirtualUIEventsDlg::PrepareTestDir() {
	CString subDir;
	DWORD pid = GetCurrentProcessId();
	subDir.Format(L"test_%u\\", pid);
	TestDir = AppDir + std::wstring(subDir);

	std::wstring caption = L"Test directory: ";
	caption += TestDir;
	TxtTestDir.SetWindowText(caption.c_str());

	// Create test directory:
	SHCreateDirectoryEx(0, TestDir.c_str(), NULL);

	// Create subdir for uploads:
	std::wstring uploadsDir = TestDir + L"Uploads";
	SHCreateDirectoryEx(0, uploadsDir.c_str(), NULL);

	// Create text file to be downloaded:
	std::wstring testFile = TestDir + L"test.txt";
	CFile file(testFile.c_str(), CFile::modeCreate | CFile::modeReadWrite);
	CStringA data;
	data.Format("File to download by PID %u", pid);
	file.Write(data, data.GetLength());
	file.Close();

	// Create text file to be downloaded:
	std::wstring testFilePDF = TestDir + L"test.pdf";
	CFile file2(testFilePDF.c_str(), CFile::modeCreate | CFile::modeReadWrite);
}

void CVirtualUIEventsDlg::RemoveTestDir() {
	RemoveDirContents(TestDir.c_str());
	RemoveDirectory(TestDir.c_str());
}

void CVirtualUIEventsDlg::Log(std::wstring data) {
	CString content;
	EditLog.GetWindowText(content);
	content.Append(data.c_str());
	content.Append(L"\r\n");
	EditLog.SetWindowText(content);

	if (CheckSaveLog.GetCheck() == BST_CHECKED) {
		UINT flags = CFile::modeReadWrite;
		if (PathFileExists(LogfileName.c_str()))
			flags |= CFile::modeNoTruncate;
		else {
			flags |= CFile::modeCreate;
		}
		CFile file(LogfileName.c_str(), flags);
		file.SeekToEnd();
		CStringA dataA = CW2A(data.c_str());
		file.Write(dataA, dataA.GetLength());
		file.Write("\r\n", 2);
		file.Close();
	}
}


// CVirtualUIEventsDlg message handlers

BOOL CVirtualUIEventsDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	CheckRemoveTestDir.SetCheck(BST_CHECKED);
	CheckSaveLog.SetCheck(BST_CHECKED);
	DlgInstance = this;

	TCHAR szDirectory[MAX_PATH] = L"";
	GetCurrentDirectory(sizeof(szDirectory) - 1, szDirectory);
	AppDir = szDirectory;
	AppDir.append(L"\\");

	Vui = new VirtualUI();
	Vui->Start();
	Vui->OnBrowserResize = Vui_OnBrowserResize;
	Vui->OnGetUploadDir = Vui_OnGetUploadDir;
	Vui->OnClose = Vui_OnClose;
	Vui->OnReceiveMessage = Vui_OnReceiveMessage;
	Vui->OnDownloadEnd = Vui_OnDownloadEnd;
	Vui->OnUploadEnd = Vui_OnUploadEnd;
	Vui->OnRecorderChanged = Vui_OnRecorderChanged;
	Vui->OnDragFile = Vui_OnDragFile;
	Vui->OnSaveDialog = Vui_OnSaveDialog;
	Vui->OnDragFile2 = Vui_OnDragFile2;
	Vui->OnDropFile = Vui_OnDropFile;

	PrepareTestDir();
	
	CString logFName;
	DWORD pid = GetCurrentProcessId();
	logFName.Format(L"VirtualUI_Events_%u.txt", pid);
	LogfileName = AppDir + std::wstring(logFName);
	CheckSaveLog.SetWindowText(L"Save log to " + logFName);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CVirtualUIEventsDlg::OnPaint()
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
HCURSOR CVirtualUIEventsDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CVirtualUIEventsDlg::OnClose()
{
	if (CheckRemoveTestDir.GetCheck() == BST_CHECKED) {
		RemoveTestDir();
	}
	CDialogEx::OnClose();
}

void CVirtualUIEventsDlg::OnBnClickedButtonDownload()
{
	Vui->DownloadFile(TestDir + L"test.txt");
}

void CVirtualUIEventsDlg::OnBnClickedButtonUpload()
{
	CFileDialog dlgFile(TRUE);
	OPENFILENAME& ofn = dlgFile.GetOFN();
	ofn.Flags |= OFN_ALLOWMULTISELECT;
	dlgFile.DoModal();


	//Vui->Uploadfile();
}

void CVirtualUIEventsDlg::OnBnClickedButtonPrintPDF()
{
	Vui->PrintPdf(TestDir + L"test.pdf");
}
