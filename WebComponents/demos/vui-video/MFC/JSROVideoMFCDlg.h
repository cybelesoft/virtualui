
// JSROVideoMFCDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "afxcmn.h"


// CJSROVideoMFCDlg dialog
class CJSROVideoMFCDlg : public CDialogEx
{
// Construction
public:
	CJSROVideoMFCDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_JSROVIDEOMFC_DIALOG };

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
	CComboBox ComboUrl;
	CButton BtnGo;
	CButton BtnPlay;
	CButton BtnStop;
	CSliderCtrl Slider;
	CStatic StatusText;
	CStatic PanelXVideo;
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
};
