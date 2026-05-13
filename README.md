# 🎹 簡易電子琴 (Simple WinForms Piano)

> 視窗程式設計 (II) - 上課練習作業
> 透過 C# WinForms 與 Windows 底層 API 實作的互動式電子琴應用程式。

## 💡 專案簡介
本專案為一個極簡風格的桌面版電子琴。主要練習重點在於**動態 UI 縮放計算**、**按鈕事件共用 (Event Handler)** 以及**外部系統 API (`kernel32.dll`) 的呼叫**。使用者可以透過點擊介面上的實體按鍵，彈奏出標準音階。

## ✨ 核心功能
* **🎵 基礎音階發聲**
  * 實作 Do、Re、Mi、Fa、Sol、La、Si、Do 共 8 個音階按鍵。
  * 呼叫 Windows 系統 API `Beep(int frequency, int duration)`，動態抓取對應頻率發出精準音效（設定持續時間為 0.3 秒）。
* **⚡ 高效程式架構**
  * 運用 `TabIndex` 屬性作為音頻陣列的索引值。
  * 8 個琴鍵共用同一個 `Click` 事件處理常式，大幅減少冗長重複的程式碼。
* **🪟 動態視窗縮放 (Responsive UI)**
  * 實作 `SizeChanged` 事件。
  * 當使用者任意拖曳、放大或縮小視窗時，內部的面板 (`Panel`) 與所有琴鍵會即時計算長寬比例，自動完美縮放不跑位。

## 🛠️ 開發與執行環境
* **開發工具**: Visual Studio 2022
* **框架**: Windows Forms App (.NET Framework)
* **程式語言**: C#
* **系統限制**: 僅限 Windows 作業系統執行（因依賴作業系統底層蜂鳴器 API 發聲）。

## 📸 執行畫面截圖
*(這是一個佔位符，請將執行截圖命名為 screenshot.png 並放在專案根目錄，圖片就會顯示在這裡)*
![電子琴執行畫面](screenshot.png)

---
**📝 備註**：如無法發出聲音，請確認電腦的系統音量是否開啟，且未被靜音。
