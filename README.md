<h1>JSON Result Upload Demo</h1>

- 這是一個用於 JSON資料上傳測試結果的專案。
- 透過 HTTP Server + Client，模擬將JSON POST 到 Server 的完整流程。

---

<h2>🔧 專案功能</h2>

- ✔ 內建 HTTP Server（HttpListener）

- ✔ Client 自動讀取 JSON 並送出 POST

- ✔ Server 顯示收到的 JSON 內容

- ✔ 完整模擬設備「結果上報 API」

---

<h2>📂 專案結構</h2>

```
json-result-upload-demo/
 ├── src/
 │    ├── Program.cs            # 啟動 Server + Client
 │    ├── ResultServer.cs       # HTTP Server
 │    ├── ResultUploader.cs     # 上傳 JSON 的 Client
 ├── sample-result.json         # 模擬用 JSON 檔案
 ├── README.md
 ├── LICENSE
 └── .gitignore
```

---

<h2>🚀 使用方式（Run Demo）</h2>

1️⃣ 準備 sample JSON

請確保根目錄有：
sample-result.json

內容示例：

```
{
  "sn": "ABC123456",
  "station": "TEST",
  "result": "PASS",
  "values": {
    "voltage": 3.31,
    "current": 0.12
  },
  "timestamp": "2025-01-01 12:30:00"
}
```

2️⃣ 執行專案

在 src/ 目錄執行：

```
dotnet run
```

程式會自動：

- 啟動 HTTP Server (localhost:5000/upload)

- 讀取 sample-result.json

- 用 Client 發送 POST

- Server 顯示收到的 JSON 內容

📡 Server 收到的示例輸出

```
[SERVER] server started on http://localhost:5000/upload
=== [SERVER] Received JSON ===
{
  "sn": "ABC123456",
  "station": "TEST",
  "result": "PASS",
  "values": {
    "voltage": 3.31,
    "current": 0.12
  },
  "timestamp": "2025-01-01 12:30:00"
}
================================
```

---

<h2>🧠 技術亮點</h2>

- 使用 HttpListener 建立REST API

- 完整模擬設備 Result Upload API（POST JSON）

- HttpClient 送出 JSON 並解析回應

- 啟動同時啟動 Server + Client

- 資源管理完整（Listener、Stream、Client 都能 Stop）

---

<h2>🏭 適用場景</h2>

- JSON 格式上傳 Demo

- Client → Server測試結果上報流程展示

<h2>👤 作者</h2>

HungHsiang, Lin（林弘翔）

Software Engineer — MES / Equipment Communication / Automation
