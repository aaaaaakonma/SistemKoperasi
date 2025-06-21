# Siskop - Sistem Informasi Koperasi

Siskop adalah aplikasi desktop berbasis .NET WinForms yang dikembangkan untuk membantu proses digitalisasi sistem pinjaman di Koperasi Artha Putra Mandiri. Sistem ini dirancang untuk meningkatkan efisiensi dan akurasi pengelolaan data karyawan, nasabah, serta proses pengajuan pinjaman berbasis dana pensiun.

## 📌 Daftar Isi
- [Latar Belakang](#latar-belakang)
- [Fitur Utama](#fitur-utama)
- [Teknologi yang Digunakan](#teknologi-yang-digunakan)
- [Cara Menjalankan](#cara-menjalankan)
- [Struktur Pengguna](#struktur-pengguna)
- [Kontributor](#kontributor)
- [Lisensi](#lisensi)

---

## Latar Belakang
Koperasi Artha Putra Mandiri sebelumnya melakukan seluruh proses administrasi pinjaman secara manual, dari pengisian formulir hingga pencatatan survei. Hal ini mengakibatkan proses yang lambat dan rentan terhadap kesalahan atau kehilangan data. Oleh karena itu, dibutuhkan sistem informasi koperasi yang terintegrasi agar seluruh proses bisa terdokumentasi secara digital dan efisien.

## Fitur Utama
- **Login dan Logout untuk Admin & Karyawan**
- **Manajemen Data Karyawan** (CRUD + akun login)
- **Manajemen Data Nasabah** (CRUD)
- **Pengajuan Pinjaman** berdasarkan survei aset dan dana pensiun
- **Verifikasi dan Proses Pinjaman**
- **Pencatatan Pembayaran Angsuran**
- **Monitoring Riwayat Pinjaman**

## Teknologi yang Digunakan
- Bahasa Pemrograman: **C#**
- Framework: **.NET Framework (WinForms)**
- Database: **MySQL**
- Arsitektur: **Object-Oriented Programming (OOP)**
- Library/Tools: Custom UserControl, Event-driven Programming

## Cara Menjalankan
1. Clone repositori ini:
   bash
   git clone https://github.com/username/siskop.git

2. Buka proyek menggunakan Visual Studio.
3. Sesuaikan koneksi database di file konfigurasi atau di dalam `AuthModel`.
4. Jalankan migrasi database jika diperlukan (disediakan SQL dump).
5. Build dan jalankan aplikasi.

## Struktur Pengguna

* **Admin**

  * Kelola data karyawan & akun
  * Kelola data nasabah
  * Monitoring data pinjaman

* **Karyawan**

  * Input pengajuan pinjaman
  * Proses verifikasi pinjaman
  * Input pembayaran angsuran

## Kontributor

Kelompok 5 - Tugas Besar PBO (2024/2025 Genap)

* Adelio Frizky (242410102064)
* Ihza Akbari Shoma (242410102066)
* Adi Cahyo Misphoenix (242410102089)
