# Gudang Super Market App

## Deskripsi
Aplikasi Gudang Super Market adalah aplikasi manajemen gudang sederhana yang dibangun dengan menggunakan ASP.NET Core dan PostgreSQL. Aplikasi ini memiliki fitur pendaftaran pengguna, login, manajemen barang, dan manajemen gudang.

## Persyaratan

Sebelum menjalankan aplikasi, pastikan Anda telah menginstall:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

## Konfigurasi

1. Buka file `appsettings.json` dan sesuaikan koneksi database PostgreSQL Anda:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=gudangsupermarket;Username=YOU_USERNAME;Password=YOUR_PASSWORD;"
    },
    ```

2. Sesuaikan konfigurasi JWT:

    ```json
    "Jwt": {
        "Issuer": "YOUR_ISSUER",
        "Audience": "YOUR_TARGET_AUDIENCE",
        "SecretKey": "YOUR_SECRETKEY"
    },
    ```

## Menjalankan Aplikasi

1. Buka terminal dan navigasi ke direktori proyek:

    ```bash
    cd /path/to/Gudang_Super_Market
    ```

2. Jalankan aplikasi:

    ```bash
    dotnet run
    ```

3. Buka browser dan akses [http://localhost:5000](http://localhost:5000).

## Migrasi Database

Untuk membuat dan memperbarui skema database, gunakan perintah berikut:

```bash
dotnet ef database update
```

Jika terdapat masalah, pastikan untuk memeriksa konfigurasi koneksi dan izin akses database.

## Swagger

Dokumentasi API dapat diakses menggunakan Swagger. Saat aplikasi berjalan, akses [http://localhost:5000/swagger](http://localhost:5000/swagger) untuk melihat dan menguji endpoint API.

## Troubleshooting

- Jika terjadi kesalahan autentikasi PostgreSQL, pastikan kata sandi dan izin akses benar.
- Pastikan server PostgreSQL berjalan dan dapat diakses di `localhost`.

## Kontribusi

Jika Anda ingin berkontribusi pada proyek ini, silakan buat _pull request_ dan laporkan _issue_ di [repository GitHub](https://github.com/kvn-media/Gudang_Super_Market).

```

Gantilah "/path/to/Gudang_Super_Market" dengan lokasi aktual proyek Anda. Anda juga dapat menyesuaikan kontennya sesuai dengan kebutuhan spesifik aplikasi Anda.