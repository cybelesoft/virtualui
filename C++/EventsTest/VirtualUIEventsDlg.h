
// VirtualUIEventsDlg.h : header file
//

#pragma once

#include <string>

// CVirtualUIEventsDlg dialog
class CVirtualUIEventsDlg : public CDialogEx
{
// Construction
public:
	CVirtualUIEventsDlg(CWnd* pParent = nullptr);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_VIRTUALUIEVENTS_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	CButton CheckRemoveTestDir;
	CButton CheckSaveLog;
	CEdit EditLog;
	CStatic TxtTestDir;
	void PrepareTestDir();
	void RemoveTestDir();
	void Log(std::wstring data);
	afx_msg void OnClose();
	afx_msg void OnBnClickedButtonDownload();
	afx_msg void OnBnClickedButtonUpload();
	afx_msg void OnBnClickedButtonPrintPDF();
};
