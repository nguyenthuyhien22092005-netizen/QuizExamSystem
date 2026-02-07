# Quiz Exam System

**Quiz Exam System** là ứng dụng Desktop (**Windows Forms**) hỗ trợ **luyện thi trắc nghiệm**, được xây dựng bằng **C# & .NET Framework**, áp dụng **kiến trúc 3-Tier (Presentation – Business – Data Access)** giúp hệ thống dễ bảo trì, mở rộng và làm việc nhóm hiệu quả.

---

## Mục lục
1. [Giới thiệu](#-giới-thiệu)
2. [Chức năng hệ thống](#-chức-năng-hệ-thống)
3. [Kiến trúc & Luồng dữ liệu](#-kiến-trúc--luồng-dữ-liệu)
4. [Cấu trúc dự án](#-cấu-trúc-dự-án)
5. [Công nghệ sử dụng](#-công-nghệ-sử-dụng)
6. [Hướng dẫn cài đặt](#️-hướng-dẫn-cài-đặt-setup)
7. [Cấu hình Database](#-cấu-hình-database)
8. [Quy chuẩn Code](#-quy-chuẩn-code-coding-convention)
9. [Quy trình Git](#-quy-trình-làm-việc-git-bắt-buộc)
10. [Phân công chức năng](#-phân-công-chức-năng)
11. [Thành viên nhóm](#-thành-viên-nhóm)

---

## Giới thiệu

Hệ thống hỗ trợ **quản lý và luyện thi trắc nghiệm** cho sinh viên/học sinh, bao gồm:

- Xác thực người dùng: Đăng nhập, đăng ký  
- Quản lý môn học  
- Quản lý đề thi  
- Quản lý câu hỏi & đáp án  
- Làm bài thi trắc nghiệm  
- Xem kết quả, lịch sử thi, xếp hạng  

Ứng dụng được thiết kế theo hướng **kéo thả giao diện (WinForms Designer)**, tập trung vào **logic nghiệp vụ** và **xử lý dữ liệu**.

---

## Chức năng hệ thống

### Người dùng
- Đăng nhập / Đăng ký
- Làm bài thi trắc nghiệm
- Xem kết quả và lịch sử làm bài
- Xem bảng xếp hạng

### Quản trị
- Quản lý môn học
- Quản lý câu hỏi & đáp án
- Quản lý đề thi
- Xem thống kê và kết quả thi

---

## Kiến trúc & Luồng dữ liệu

Hệ thống áp dụng **3-Tier Architecture**:
```
Forms (WinForms UI)
↓
BUS (Business Logic)
↓
DAL (Data Access Layer)
↓
Database (SQL Server)
```

### Nguyên tắc bắt buộc
- Không viết SQL trong Form  
- Không xử lý giao diện trong BUS  
- Không đặt nghiệp vụ trong DAL  

---

## Cấu trúc dự án
```
QuizExamSystem
├── Database/
│ └── QuizExamDB.sql # Script tạo CSDL (chạy đầu tiên)
│
├── DAL/ # Data Access Layer
│ ├── UserDAL.cs
│ ├── SubjectDAL.cs
│ ├── QuestionDAL.cs
│ ├── ExamDAL.cs
│ └── ResultDAL.cs
│
├── BUS/ # Business Logic
│ ├── UserBUS.cs
│ ├── SubjectBUS.cs
│ ├── QuestionBUS.cs
│ ├── ExamBUS.cs
│ └── ResultBUS.cs
│
├── Models/ # Entity / DTO
│ ├── User.cs
│ ├── Subject.cs
│ ├── Question.cs
│ ├── Answer.cs
│ ├── Exam.cs
│ └── ExamResult.cs
│
├── Forms/ # WinForms UI
│ ├── Auth/
│ │ ├── FrmLogin.cs
│ │ └── FrmRegister.cs
│ ├── ExamManagement/
│ │ ├── FrmExam.cs
│ │ └── FrmExamManager.cs
│ ├── QuestionManagement/
│ │ └── FrmQuestionManager.cs
│ ├── SubjectManagement/
│ │ └── FrmSubjectManager.cs
│ ├── ResultManagement/
│ │ ├── FrmResult.cs
│ │ ├── FrmHistory.cs
│ │ └── FrmRanking.cs
│ └── FrmMain.cs
│
├── Utils/
│ └── DbHelper.cs # Kết nối & execute SQL
│
├── Reports/ # Báo cáo (mở rộng)
├── App.config # Connection String
├── Program.cs # Entry point
├── .gitignore
└── README.md
```

---

## Công nghệ sử dụng

| Thành phần | Công nghệ | Ghi chú |
|---------|----------|--------|
| Ngôn ngữ | C# | .NET Framework |
| Giao diện | Windows Forms | Kéo thả |
| Database | SQL Server | LocalDB / SQL Express |
| Kết nối | ADO.NET | SqlConnection |
| IDE | Visual Studio 2022+ | Khuyên dùng |
| Quản lý mã nguồn | Git + GitHub | Làm việc nhóm |

---

## Hướng dẫn cài đặt (Setup)

### Bước 1: Chuẩn bị Database
1. Cài **SQL Server**
2. Mở **SQL Server Management Studio**
3. Tạo database: `QuizExamDB`
4. Chạy file: Database/QuizExamDB.sql

---

### Bước 2: Clone & mở project
```bash
git clone https://github.com/<your-username>/QuizExamSystem.git
```
- Mở Visual Studio
- Chọn Open a project or solution
- Trỏ tới thư mục vừa clone
---
### Bước 3: Cấu hình App.config
```
<connectionStrings>
  <add name="QuizExamDB"
       connectionString="Data Source=.;Initial Catalog=QuizExamDB;Integrated Security=True"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```
---
### Bước 4: Chạy chương trình
- Mở Program.cs
- Nhấn F5
## Quy chuẩn Code (Coding Convention)
### 1.Đặt tên Form & Control

| Thành phần   | Quy ước | Ví dụ       |
| ------------ | ------- | ----------- |
| Form         | Frm     | FrmLogin    |
| Button       | btn     | btnLogin    |
| TextBox      | txt     | txtUsername |
| Label        | lbl     | lblTitle    |
| DataGridView | dgv     | dgvQuestion |

### 2.Quy tắc C#
- Class: PascalCase
- Biến & hàm: camelCase
- Không hard-code connection string
- BUS không truy cập DB trực tiếp
### Quy trình làm việc Git (BẮT BUỘC)
- Không commit trực tiếp vào main
- Mỗi thành viên:
```
git checkout -b feature-<ten-chuc-nang>
```

## Phân công chức năng

| Thành viên   | Chức năng              |
| ------------ | ---------------------- |
| Thành viên 1 | Xác thực & Người dùng  |
| Thành viên 2 | Quản lý môn học        |
| Thành viên 3 | Quản lý câu hỏi        |
| Thành viên 4 | Quản lý đề thi         |
| Thành viên 5 | Kết quả & Thống kê     |
