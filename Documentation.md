# Dokumentasi Gudang Super Market

## Deskripsi Singkat
Aplikasi Gudang Super Market adalah sebuah sistem manajemen gudang sederhana yang memungkinkan pengguna untuk melakukan operasi CRUD (Create, Read, Update, Delete) pada entitas Gudang dan Barang. Aplikasi ini juga menyediakan fitur autentikasi menggunakan token JWT.

## Struktur Proyek
1. **Gudang_Super_Market:** Direktori utama proyek.
   - **Controllers:** Mengandung file-file controller untuk operasi CRUD dan autentikasi.
   - **Data:** Mengandung file konfigurasi database dan implementasi DbContext.
   - **Middleware:** Mengandung middleware khusus untuk menangani kesalahan.
   - **Models:** Mendefinisikan model entitas seperti User, Gudang, dan Barang.
   - **obj:** Direktori objek terkompilasi.
   - **Properties:** Mengandung file-file konfigurasi.
   - **Migrations:** Mengandung file-file migrasi database.
   - **wwwroot:** Direktori untuk menyimpan file statis (jika diperlukan).
   - **appsettings.json:** File konfigurasi utama.

2. **Postman:** Direktori yang berisi file Postman Collection untuk diimpor dan diuji.

## Konfigurasi
1. **appsettings.json:** Konfigurasi utama aplikasi, termasuk koneksi database dan pengaturan JWT.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=gudangsupermarket;Username=YOUR_USERNAME;Password=YOUR_PASSWORD;"
  },
  "Jwt": {
    "Issuer": "GudangSuperMarketApp",
    "Audience": "GudangSuperMarketClient",
    "SecretKey": "YOUR_SECRETKEY"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

## Menjalankan Aplikasi
1. Pastikan Anda memiliki .NET SDK terinstal.
2. Buka terminal di direktori proyek dan jalankan perintah berikut:

```bash
dotnet run
```

3. Aplikasi akan dijalankan pada `https://localhost:5001` (gunakan `http://localhost:5000` untuk non-HTTPS).

## Pengujian API Menggunakan Postman
1. Impor file Postman Collection yang disediakan di direktori "Postman".
2. Akses token JWT dengan menjalankan permintaan login di Postman.

### Login
- **URL:** `https://localhost:5001/auth/login`
- **Metode:** `POST`
- **Body:**
  ```json
  {
    "username": "user123",
    "password": "securepassword"
  }
  ```

3. Salin token JWT yang diterima.
4. Tambahkan token ke header `Authorization` untuk permintaan lainnya.

## Endpoint API
### AuthController
1. **Register User:**
   - **URL:** `https://localhost:5001/auth/register`
   - **Metode:** `POST`
   - **Body:**
     ```json
     {
       "username": "newuser",
       "password": "newpassword"
     }
     ```

2. **Login User:**
   - **URL:** `https://localhost:5001/auth/login`
   - **Metode:** `POST`
   - **Body:**
     ```json
     {
       "username": "user123",
       "password": "securepassword"
     }
     ```

### GudangController
1. **Get All Gudangs:**
   - **URL:** `https://localhost:5001/gudang`
   - **Metode:** `GET`

2. **Get Gudang by ID:**
   - **URL:** `https://localhost:5001/gudang/{id}`
   - **Metode:** `GET`

3. **Create Gudang:**
   - **URL:** `https://localhost:5001/gudang`
   - **Metode:** `POST`
   - **Body:**
     ```json
     {
       "NamaGudang": "Gudang Baru",
       "Lokasi": "Lokasi Baru"
     }
     ```

4. **Update Gudang by ID:**
   - **URL:** `https://localhost:5001/gudang/{id}`
   - **Metode:** `PUT`
   - **Body:**
     ```json
     {
       "NamaGudang": "Gudang Terupdate",
       "Lokasi": "Lokasi Terupdate"
     }
     ```

5. **Delete Gudang by ID:**
   - **URL:** `https://localhost:5001/gudang/{id}`
   - **Metode:** `DELETE`

### BarangController
1. **Get All Barangs:**
   - **URL:** `https://localhost:5001/barang`
   - **Metode:** `GET`

2. **Get Barang by ID:**
   - **URL:** `https://localhost:5001/barang/{id}`
   - **Metode:** `GET`

3. **Create Barang:**
   - **URL:** `https://localhost:5001/barang`
   - **Metode:** `POST`
   - **Body:**
     ```json
     {
       "NamaBarang": "Barang Baru",
       "HargaBarang": 100,
       "ExpiredDate": "2023-01-01",
       "GudangId": 1
     }
     ```

4. **Update Barang by ID:**
   - **URL:** `https

://localhost:5001/barang/{id}`
   - **Metode:** `PUT`
   - **Body:**
     ```json
     {
       "NamaBarang": "Barang Terupdate",
       "HargaBarang": 150,
       "ExpiredDate": "2023-01-02",
       "GudangId": 2
     }
     ```

5. **Delete Barang by ID:**
   - **URL:** `https://localhost:5001/barang/{id}`
   - **Metode:** `DELETE`

### Monitoring Barang
1. **Get Monitoring Barangs:**
   - **URL:** `https://localhost:5001/barang/Monitoring`
   - **Metode:** `GET`
   - **Query Parameters:**
     - `namaGudang`: Nama gudang (opsional).
     - `expiredDate`: Tanggal kadaluwarsa (opsional).

## Kesimpulan
Dokumentasi ini memberikan panduan untuk menjalankan dan menguji aplikasi Gudang Super Market. Pastikan untuk memahami keamanan dan praktik terbaik pengembangan aplikasi sebelum memasukkan ke produksi. Juga, sesuaikan konfigurasi seperti koneksi database dan pengaturan JWT sesuai kebutuhan Anda.