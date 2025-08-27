MESProject - 製造執行系統
專案簡介
這是一個基於 ASP.NET Core MVC 所開發的製造執行系統（Manufacturing Execution System, MES）初版。本專案旨在提供一個簡易的平台，用來管理工廠內的工單（Work Order），實現從工單建立到完成的基本生命週期管理。
專案使用 Entity Framework Core 作為資料庫操作的 ORM 工具，並搭配 SQL Server LocalDB 作為資料儲存庫。
主要功能
 * 工單管理：提供完整的工單管理功能，包括：
   * 新增工單：創建新的工單，並輸入產品代碼、數量、計劃開始/實際開始時間、完成時間、生產線和備註等資訊。
   * 查看工單：以表格方式顯示所有工單的列表。
   * 編輯工單：修改現有工單的資訊並保存到資料庫。
   * 刪除工單：從資料庫中刪除不再需要的工單。
   * 詳細資料：查看單一工單的完整詳細資料。
 * 資料庫同步：透過 Entity Framework Core Migration 機制，確保程式碼中的模型（Model）與資料庫結構保持同步。
技術棧
 * 後端:
   * ASP.NET Core MVC
   * Entity Framework Core
   * C#
 * 資料庫:
   * SQL Server LocalDB
 * 前端:
   * Razor 語法 (.cshtml)
   * Bootstrap (用於樣式與排版)
   * jQuery (用於客戶端互動)
 * 版本控制:
   * Git & GitHub
如何運行專案
 * 克隆儲存庫：
   git clone https://github.com/你的GitHub帳號/MESProject.git
cd MESProject

 * 開啟專案：
   * 使用 Visual Studio 2022 開啟 .sln 解決方案檔案。
 * 更新資料庫：
   * 在 Visual Studio 中，進入 工具 -> NuGet 套件管理員 -> 套件管理員主控台。
   * 確保 預設專案(J) 選項為 MESProject。
   * 執行以下命令，以確保你的資料庫與專案模型同步：
     Update-Database

 * 運行專案：
   * 在 Visual Studio 中按下 F5 或點擊綠色箭頭 IIS Express 來運行專案。
   * 瀏覽器將自動開啟並導航至首頁。
未來功能擴充
本專案為一個基礎版本，未來可考慮擴充以下功能以增加其實用性：
 * 操作歷史記錄：追蹤每一筆工單的變更，方便稽核與問題追蹤。
 * 使用者認證：實作登入功能，並為不同使用者角色設定不同的權限。
 * 數據儀表板：透過圖表（如圓餅圖、折線圖）可視化工單狀態、產能等數據。
 * 電子郵件通知：在工單狀態變更時，自動發送通知給相關人員。
 * API 接口：將後端邏輯與前端介面分離，為未來的前端框架（如 Vue.js 或 React）整合做準備。
