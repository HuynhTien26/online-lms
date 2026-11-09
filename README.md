# online-lms
Hệ thống Quản lý Học tập Trực tuyến (LMS) – Nền tảng học trực tuyến toàn diện hỗ trợ quản lý khóa học, bài giảng video, thi trắc nghiệm tự động, theo dõi tiến độ và phân quyền RBAC (Admin, Instructor, Student).

## 1. Cấu trúc thư mục

```text
online-lms/
├── docs/
│   ├── common/                  # Tài liệu chung toàn hệ thống (SYS)
│   │   ├── architecture/        # Kiến trúc, Use Case tổng quát, Domain Class, Component, Style Guide, Báo cáo
│   │   └── database/            # Lược đồ CSDL quan hệ, ERD
│   ├── module-1-user-rbac/      # Cụm 1: Quản lý Người dùng & RBAC
│   ├── module-2-course/         # Cụm 2: Khóa học & Bài giảng
│   ├── module-3-exam/           # Cụm 3: Ngân hàng Đề & Thi trắc nghiệm
│   └── module-4-progress/       # Cụm 4: Tiến độ & Tương tác
└── src/                         # Mã nguồn demo (SYS-04.3)
    ├── backend/
    └── frontend/
```

## 2. Quy tắc đặt tên file

Tất cả các file đặt tên theo cú pháp: `[Mã-Task]-[Tên-Tài-Liệu]` (viết liền hoặc nối bằng dấu gạch ngang, không dấu).

Ví dụ:
- File đặc tả: `UC2-01-UseCase-Course.pdf`
- File sơ đồ gốc: `UC1-02-Activity-Login.drawio`
- File sơ đồ xuất PDF: `UC1-02-Activity-Login.pdf`
- File hệ thống chung: `SYS-01.1-ERD.pdf`

## 3. Quy trình làm việc với Git

Các thành viên không đẩy bài trực tiếp lên nhánh `main`. Mỗi người làm việc trên nhánh riêng của cụm mình theo các bước sau:

### Bước 1: Chấp nhận lời mời
Kiểm tra email hoặc thông báo GitHub và chọn **Accept invitation** để có quyền truy cập repo.

### Bước 2: Tải dự án về máy (chỉ làm lần đầu)
Mở Git Bash tại thư mục muốn lưu bài và chạy:

```bash
git clone [https://github.com/HuynhTien26/online-lms.git](https://github.com/HuynhTien26/online-lms.git)
cd online-lms
```

### Bước 3: Chuyển sang nhánh phụ trách
Ai phụ trách cụm nào thì chạy lệnh tương ứng của cụm đó:
- Cụm 1 (User & RBAC): `git checkout feature/module-1-user`
- Cụm 2 (Khóa học & Bài giảng): `git checkout feature/module-2-course`
- Cụm 3 (Ngân hàng đề & Thi): `git checkout feature/module-3-exam`
- Cụm 4 (Tiến độ & Tương tác): `git checkout feature/module-4-progress`

### Bước 4: Thêm file và đẩy lên GitHub
Sau khi copy các file tài liệu, sơ đồ vào đúng thư mục quy định ở Mục 1, mở lại Git Bash và chạy:

```bash
git add .
git commit -m "docs(cum-X): cap nhat tai lieu va so do"
git push origin <ten-nhanh-cua-ban>
```

Lưu ý: Thay `X` bằng số cụm và `<ten-nhanh-cua-ban>` bằng tên nhánh ở Bước 3 (Ví dụ: `git push origin feature/module-2-course`). Sau khi push thành công, nhắn vào nhóm để nhóm trưởng kiểm tra và gộp (merge) vào nhánh `main`.
