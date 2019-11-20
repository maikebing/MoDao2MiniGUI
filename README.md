# MoDao2MiniGUI
是一个将https://modao.cc/ 生成的离线包生成MiniGUI代码的工具， 我们在实际工作中使用的是MiniGUI2.0.4 
后期我们会逐步完善一些C的代码
关键方法：

```c

void    CreateControls(PCTRLDATA controls, HWND hMainWin, LPARAM lParam)
{
	int i;
	PCTRLDATA pCtrlData;
	HWND hCtrl = 0;
	HWND hFocus;
	int controlnr = sizeof(CtrlYourTaste) / sizeof(CTRLDATA);
	if (controlnr > 0 && !controls)
	{
		echo_ui("error");
	}
	else
	{
		for (i = 0; i < controlnr; i++) {
			pCtrlData = controls + i;
			hCtrl = CreateWindowEx(pCtrlData->class_name,
				pCtrlData->caption,
				pCtrlData->dwStyle | WS_CHILD,
				pCtrlData->dwExStyle | WS_EX_TRANSPARENT,
				pCtrlData->id,
				pCtrlData->x,
				pCtrlData->y,
				pCtrlData->w,
				pCtrlData->h,
				hMainWin,
				pCtrlData->dwAddData);
			if (hCtrl == HWND_INVALID) {
				DestroyMainWindow(hMainWin);
				MainWindowThreadCleanup(hMainWin);
				return;
			}

			if (pCtrlData->dwAddData == HWND_NULL)
			{
				pCtrlData->dwAddData = (DWORD)&CTLExtDefault;
			}
			PCTRLDATAExt  cdea = (PCTRLDATAExt)pCtrlData->dwAddData;
			ApplyPCTRLDATAToCtl(cdea, hCtrl);
			if (strncmp(pCtrlData->class_name, CTRL_STATIC, strlen(CTRL_STATIC) != 0))
			{
				UpdateWindow(hCtrl, TRUE);
			}
		}

		hFocus = GetNextDlgTabItem(hMainWin, (HWND)0, FALSE);
		if (SendMessage(hMainWin, MSG_INITDIALOG, hFocus, lParam)) {
			if (hFocus)
				SetFocus(hFocus);
		}
	}
}
void  ApplyPCTRLDATAToCtl(PCTRLDATAExt cdea, HWND hCtrl)
{
	if (cdea->FontSize > 0)
	{
		SetWindowFont(hCtrl, CreateLogFont(cdea->FontType, cdea->FontName, FONT_CHARSET_GB2312_0,
			cdea->FontWeight, FONT_SLANT_ROMAN, FONT_SETWIDTH_NORMAL,
			FONT_SPACING_CHARCELL, FONT_UNDERLINE_NONE, FONT_STRUCKOUT_NONE,
			cdea->FontSize, 0));

	}
	if (cdea->ForeColor >= 0)
	{
		SetWindowElementColorEx(hCtrl, FGC_CAPTION_NORMAL, cdea->ForeColor);
		SetWindowElementColorEx(hCtrl, FGC_MENUITEM_NORMAL, cdea->ForeColor);
		SetWindowElementColorEx(hCtrl, WEC_3DBOX_NORMAL, cdea->ForeColor);
		SetWindowElementColorEx(hCtrl, FGC_CONTROL_NORMAL, cdea->ForeColor);
		SetWindowElementColorEx(hCtrl, FGC_BUTTON_NORMAL, cdea->ForeColor);
	}
	if (cdea->BackColor >= 0)
	{
		SetWindowBkColor(hCtrl, cdea->BackColor);
	}
}

```
