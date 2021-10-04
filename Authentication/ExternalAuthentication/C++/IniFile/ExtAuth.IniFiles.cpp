// ExtAuth.IniFiles.cpp : Defines the exported functions for the DLL application.
//
#include "stdafx.h"
EXTERN_C IMAGE_DOS_HEADER __ImageBase;
#define THINFINITY_API extern "C" __declspec(dllexport)
#include "Shlwapi.h"

THINFINITY_API DWORD __stdcall ValidateUser(LPWSTR lpUserName, LPWSTR lpPassword, LPWSTR lpMetadata,
  LPWSTR lpSecurityRole, LPWSTR lpWinUser, LPWSTR lpWinPass, LPWSTR lpCustomData,
  PBOOLEAN pHandled)
{
	*pHandled = true;

	// Get the current DLL pathname
	WCHAR lpFileName[MAX_PATH];
	ZeroMemory(&lpFileName[0], MAX_PATH);
	GetModuleFileName((HINSTANCE)&__ImageBase, (LPWSTR) &lpFileName[0], MAX_PATH);
	// Sample ini file location: ../../IniFile/AllowedUsers.ini
	PathRemoveFileSpecW(lpFileName); // Remove FileName
	PathRemoveFileSpecW(lpFileName); // Remove the two parent directories
	PathRemoveFileSpecW(lpFileName);
	wcscat(lpFileName, L"\\IniFile\\AllowedUsers.ini");

	// Append the default domain to the requested user if it has no one
	WCHAR lpStoredUsr[256];
	if (wcsstr(lpUserName, L"\\") != NULL)
	{
		wcscpy(lpStoredUsr, lpUserName);
	}
	else
	{
		wcscpy(lpStoredUsr, L"cybelesoft\\");
		wcscat(lpStoredUsr, lpUserName);
	}

	// Read the stored password for the requested user
	WCHAR lpStoredPwd[256];
	ZeroMemory(&lpStoredPwd[0], 256);
	if (GetPrivateProfileString(L"USERS", lpStoredUsr, NULL, lpStoredPwd, 256, lpFileName) == 0)
	{
		return ERROR_BAD_USERNAME;
	};

	// Verify if the requested password is correct
	if (wcscmp(lpPassword, lpStoredPwd) == 0)
	{
		wcscpy(lpSecurityRole, lpStoredUsr);
		wcscpy(lpWinUser, lpStoredUsr);
		wcscpy(lpWinPass, lpPassword);
		wcscpy(lpCustomData, L"{\"AuthenticatedBy\":\"ExtAuth.IniFiles\"}");
		return NO_ERROR;
	}

	return ERROR_INVALID_PASSWORD;
}
