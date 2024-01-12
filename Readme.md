# Gudang Super Market API

## Deskripsi
Ini adalah API untuk manajemen gudang pada Gudang Super Market. API ini menyediakan endpoint untuk manajemen pengguna, gudang, dan barang.

## Prasyarat
Pastikan Anda telah menginstal:
- [.NET Core](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

## Cara Menjalankan Aplikasi
1. Clone repositori ini.
2. Buka terminal dan pindah ke direktori proyek.
3. Buka file `appsettings.json` dan sesuaikan string koneksi database.
4. Jalankan perintah berikut:
   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   ```
5. Aplikasi akan berjalan di `http://localhost:5000` atau `https://localhost:5001`.

## Endpoints API
- **/auth/register**: Endpoint untuk registrasi pengguna baru.
- **/auth/login**: Endpoint untuk login pengguna dan mendapatkan token JWT.
- **/gudang**: Endpoint CRUD untuk gudang.
- **/barang**: Endpoint CRUD untuk barang.
- **/barang/monitoring**: Endpoint untuk mendapatkan data pemantauan barang.

## Penggunaan dengan Postman
1. **Registrasi Pengguna:**
   - Endpoint: `POST /auth/register`
   - Body: Informasi pengguna (username, password, dll.).

2. **Login Pengguna:**
   - Endpoint: `POST /auth/login`
   - Body: Kredensial pengguna (username, password).

3. **Mendapatkan Token:**
   - Gunakan token yang diperoleh dari langkah login pada header setiap permintaan API yang memerlukan otentikasi.

4. **Manajemen Gudang dan Barang:**
   - Gunakan endpoint CRUD untuk manajemen gudang dan barang.
   - Endpoint: `/gudang`, `/barang`, `/barang/monitoring`.
   - Sertakan token di header untuk otorisasi.
